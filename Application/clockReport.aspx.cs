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
        private Employee employee;
        //private Employee watchEmployee;
        private LinkedList<Report> repList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();
            employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));

            //if admin & watch employee
            if (employee.Rank == 1 && Request.QueryString["id"] != null)
            {
                repList = bl.Reports(int.Parse("" + Request.QueryString["id"]), DateTime.Now);
            } else {
                repList = bl.Reports(int.Parse("" + Session["id"]), DateTime.Now);
            }


            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;


            //report
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

        }

        private string zeroLead(int num) {
            if (num < 10)
                return "0" + num;
            return "" + num;
        }
    }
}