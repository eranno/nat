using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class messages : System.Web.UI.Page
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

            //msgs
            LinkedList<Massege> msgList = bl.GetMassege(int.Parse("" + Session["id"]));
            msgs.Text = "" + msgList.Count;
            int count = 0;
            foreach (Massege m in msgList)
            {
                //new rows and cells
                TableRow tRow2 = new TableRow();
                TableCell tCell = new TableCell();

                TableRow tRow1 = new TableRow();
                tRow1.CssClass = "title";
                tRow1.ID = "jstoggle_" + count;
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                TableCell tCell3 = new TableCell();
                TableCell tCell4 = new TableCell();

                //button
                Button dButton = new Button();
                if (m.Approve == 0)
                    dButton.Text = "אשר";
                else
                    dButton.Text = "בטל";
                dButton.ID = "r_" + count;
                dButton.Click += new EventHandler(btnApprove);

                //title
                tCell1.Text = "" + m.Date;
                tCell2.Text = "" + m.FirstName + " " + m.LastName;
                tCell3.Text = "" + m.Type;
                tCell4.Text = "" + (m.Approve==1?"מאושר":"לא מאושר");

                //show only to admin
                if (employee.Rank==1)
                    tCell4.Controls.Add(dButton);

                //body
                tCell.Text = "" + m.Note;
                tCell.ColumnSpan = 4;
                tCell.ID = "toggle_" + count;
                tCell.CssClass = "toggle";

                //add all to table
                tRow1.Cells.Add(tCell1);
                tRow1.Cells.Add(tCell2);
                tRow1.Cells.Add(tCell3);
                tRow1.Cells.Add(tCell4);
                tRow2.Cells.Add(tCell);
                Table1.Rows.Add(tRow1);
                Table1.Rows.Add(tRow2);

                count++;
            }
        }

        protected void btnApprove(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Text = (clickedButton.Text == "אשר" ? "בטל" : "אשר");
        }
    }
}