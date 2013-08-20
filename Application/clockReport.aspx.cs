using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class clockReport : System.Web.UI.Page
    {
        private EmployeeBL bl;
        private Employee employee;          //the logged in user
        private Employee watchEmployee;     //if admin, show him other users
        private LinkedList<Report> repList; //report days list
        DateTime time;                      //report date

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();
            employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));


            //timeing
            if (Request.QueryString["year"] != null && Request.QueryString["month"] != null)
            {
                time = Convert.ToDateTime("01/" + Request.QueryString["month"] + "/" + Request.QueryString["year"]);
            } else time = DateTime.Now;

            user_month.Text = time.ToString("MMMM");
            user_year.Text = time.ToString("yyyy");

            //  set directions  //
            //past
            past.Text = "<a href=\"clockReport.aspx?";
            if (Request.QueryString["id"] != null)
                past.Text += "id=" + Request.QueryString["id"] + "&";
            past.Text += "year=" + time.AddMonths(-1).ToString("yyyy") + "&month=" + time.AddMonths(-1).ToString("MM") + "\"><<</a>";
            //next
            if (time.AddMonths(1) < DateTime.Now)      //DateTime.Now.AddMonths(1).Equals(time))
            {
                next.Text = "<a href=\"clockReport.aspx?";
                if (Request.QueryString["id"] != null)
                    next.Text += "id=" + Request.QueryString["id"] + "&";
                next.Text += "year=" + time.AddMonths(1).ToString("yyyy") + "&month=" + time.AddMonths(1).ToString("MM") + "\">>></a>";
            }

            //if admin & watch employee
            if (employee.Rank == 1 && Request.QueryString["id"] != null)
            {
                repList = bl.Reports(bl.toInt("" + Request.QueryString["id"]), time);
                if (repList == null)
                    Response.Redirect("error.aspx?e=משתמש אינו קיים!");

                watchEmployee = bl.GetEmployeeId(int.Parse("" + Request.QueryString["id"]));
                user_first.Text = watchEmployee.FirstName;
                user_last.Text = watchEmployee.LastName;
            } else {
                repList = bl.Reports(int.Parse("" + Session["id"]), time);
            }


            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;

            //report
            int totalHoursThisMonth = 0;
            int count = 0;
            foreach (Report r in repList)
            {
                TableRow tRow = new TableRow();
                TableCell date1 = new TableCell();
                TableCell type1 = new TableCell();
                TableCell note1 = new TableCell();
                TableCell entry1 = new TableCell();
                TableCell exit1 = new TableCell();
                TableCell sumhours = new TableCell();
                TableCell excesshours = new TableCell();
                TableCell lackhours = new TableCell();


                date1.Text = "" + r.Date.ToString("dd/MM/yyyy");
                type1.Text = "" + bl.Type(r.Type);
                type1.CssClass = "type";
                type1.ID = "type" + count;
                note1.Text = "" + r.Note;
                note1.CssClass = "note";
                note1.ID = "note" + count;


                entry1.Text = "" + r.Entry.ToString("HH:mm:ss");
                if (DateTime.MinValue == r.Exit)
                    exit1.Text = "day not close";
                else
                    exit1.Text = "" + r.Exit.ToString("HH:mm:ss");

                if (DateTime.MinValue == r.Exit)
                {
                    sumhours.Text       = "00:00";
                    excesshours.Text    = "00:00";
                    lackhours.Text      = "00:00";
                }
                else
                {
                    //count total hours
                    totalHoursThisMonth += r.Hours;

                    sumhours.Text = "" + zeroLead(r.Hours / 60) + ":" + zeroLead(r.Hours - (r.Hours / 60) * 60);//"" + r.Hours;
                    excesshours.Text = "" + zeroLead(r.Excesshours / 60) + ":" + zeroLead(r.Excesshours - (r.Excesshours / 60) * 60);
                    lackhours.Text = "" + zeroLead(r.Lackhours / 60) + ":" + zeroLead(r.Lackhours - (r.Lackhours / 60) * 60) + "-";
                }

                tRow.Cells.Add(date1);
                tRow.Cells.Add(type1);
                tRow.Cells.Add(note1);
                tRow.Cells.Add(entry1);
                tRow.Cells.Add(exit1);
                tRow.Cells.Add(sumhours);
                tRow.Cells.Add(excesshours);
                tRow.Cells.Add(lackhours);
                Table1.Rows.Add(tRow);

                count++;
            }

            //summery
            totalHours.Text = "" + zeroLead(totalHoursThisMonth / 60) + ":" + zeroLead(totalHoursThisMonth - (totalHoursThisMonth / 60) * 60);

        }

        private string zeroLead(int num) {
            if (num < 10)
                return "0" + num;
            return "" + num;
        }
    }
}