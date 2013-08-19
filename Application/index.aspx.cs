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
        private EmployeeBL bl= new EmployeeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = 55555;
            Response.Redirect("clockReport.aspx");

            if (Session["id"] != null)
            {
                if (Request.QueryString["r"] == "outoftime")
                id.Text = "" + Session["id"];
                Session["id"] = null;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
     
            //missing data?
            if (id.Text == "" || password.Text == "")
            {
                Label.Text = "נא למלא את כל השדות";
                return;
            }

            //everything is ok
            if ( bl.LogInorOut(int.Parse(id.Text), password.Text, 1) )
            {
                if (bl.IsManger(int.Parse(id.Text)))
                    Session["admin"] = true;

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