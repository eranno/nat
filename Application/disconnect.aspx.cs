using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class disconnect : System.Web.UI.Page
    {
        private EmployeeBL bl = new EmployeeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            id.Text = ""+Session["id"];
        }

        protected void button_Click(object sender, EventArgs e)
        {

            //missing data?
            if (password.Text == "")
            {
                Label.Text = "יש למלא סיסמה";
                return;
            }

            //everything is ok
            if (bl.LogInorOut(int.Parse("" + Session["id"]), password.Text, 0))
            {
                Session["id"] = null;
                Response.Redirect("index.aspx");
            }

            //bad username or password
            else
            {
                Label.Text = "סיסמא שגויה.";
            }

        }
    }
}