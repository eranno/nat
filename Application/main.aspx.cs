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

        protected void Page_Load(object sender, EventArgs e)
        {
            //is auth?
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            //get user details
            bl = new EmployeeBL();
            Employee employee = bl.GetEmployee(int.Parse("" + Session["id"]));

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;

            //manager info
            if (employee.Rank == 1)
                Div1.Visible = true;
            else
                Div1.Visible = false;
        }
    }
}