using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class vacations : System.Web.UI.Page
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
            totalSum.Text = ""+employee.Vacation;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            //validate
            //missing data?
            if (start.Text == "" || end.Text == "")
            {
                //Label.Text = "נא למלא את כל השדות";
                return;
            }


            bl.SetMassege(1, int.Parse("" + Session["id"]), 2, start.Text + "," + end.Text);


        }
    }
}