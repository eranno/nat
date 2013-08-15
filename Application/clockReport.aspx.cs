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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();
            Employee employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;



            //report
           LinkedList<Report> repList = bl.Reports(int.Parse("" + Session["id"]), DateTime.Now);

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





                date1.Text = "" + r.Date.ToString("MM/dd/yyyy");
                type1.Text = "" + bl.Type(r.Type);
                note1.Text = "" + r.Note;
                entry1.Text = "" + r.Entry.ToString("HH:mm:ss");
                if (DateTime.MinValue == r.Exit)
                    exit1.Text = "day not close";
                else
                    exit1.Text = "" + r.Exit.ToString("HH:mm:ss");

                if (DateTime.MinValue == r.Exit)
                {
                    sumhours.Text = "00:00";
                    excesshours.Text = "00:00";
                    lackhours.Text = "00:00";
                }
                else
                {
                    sumhours.Text = "" + (r.Hours / 60) + ":" + (r.Hours - (r.Hours / 60) * 60);//"" + r.Hours;
                    excesshours.Text = "" + (r.Excesshours / 60) + ":" + (r.Excesshours - (r.Excesshours / 60) * 60);
                    lackhours.Text = "" + (r.Lackhours / 60) + ":" + (r.Lackhours - (r.Lackhours / 60) * 60) + "-";
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
            }

        }
    }
}