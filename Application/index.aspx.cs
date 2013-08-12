using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class index : System.Web.UI.Page
    {
        private EmployeeBL bl = new EmployeeBL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
     
            //missing data?
            if (id.Text == "" || password.Text == "")
            {
                Label.Text = "נא למלא את כל השדות";
                return;
            }


            bl = new EmployeeBL();
            //everything is ok
            if ( bl.LogInorOut(int.Parse(id.Text), password.Text, 1) )
            {
                Session["id"] = id.Text;
                Response.Redirect("main.aspx");
            }

            //bad username or password
            else
            {
                Label.Text = "ת\"ז או סיסמה שגויים";
            }

        }
    }
}