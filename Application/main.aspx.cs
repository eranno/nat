using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class main : System.Web.UI.Page
    {
        private EmployeeBL bl;
        private Employee employee;
        private Employee admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            //is auth?
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            //get user details
            bl = new EmployeeBL();
            if (Request.QueryString["id"] != null) {
                admin = bl.GetEmployeeId(int.Parse("" + Session["id"]));
                employee = bl.GetEmployeeId(int.Parse("" + Request.QueryString["id"]));
            }
            else {
                employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));
            }

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;

            //msgs
            LinkedList<Massege> msgList = bl.GetMassege(int.Parse("" + Session["id"]));
            msgs.Text = ""+msgList.Count;
            /* show msgs?
            foreach (Massege m in msgList)
            {
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                TableCell tCell3 = new TableCell();

                tCell1.Text = "" + m.Date;
                tCell2.Text = "" + m.FirstName + " " + m.LastName;
                tCell3.Text = "" + m.Type;

                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                tRow.Cells.Add(tCell3);
                Table1.Rows.Add(tRow);
            }
             */


            //Admin
            if (employee.Rank == 1) {

                //view user details
                admin.Visible = true;
                view.InnerText = "אתה מחוב"

                //show admin extra info
                Div1.Visible = true;
            }

            else {
                admin.Visible = false;
                Div1.Visible = false;
            }

        }
    }
}