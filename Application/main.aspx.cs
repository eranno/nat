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
        private Employee watchEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {
            //is auth?
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            //reset
            showUserDetails.Visible = false;
            Div1.Visible = false;


            //get user details
            bl = new EmployeeBL();
            employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));

            //if admin
            if (employee.Rank == 1)
            {
                //watch employee
                if (Request.QueryString["id"] != null)
                {
                    watchEmployee = bl.GetEmployeeId(int.Parse("" + Request.QueryString["id"]));
                    showUserDetails.Visible = true;
                    view.InnerHtml += "תעודת זהות: " + watchEmployee.Id
                                  + "<br />שם פרטי: " + watchEmployee.FirstName                                   
                                  + "<br />שם משפחה: " + watchEmployee.LastName
                                  + "<br />דרגה: " + watchEmployee.Rank
                                  + "<br />ימי מחלה: " + watchEmployee.Sick
                                  + "<br />ימי חופשה: " + watchEmployee.Vacation;

                    links.Style.Add("background-color", "#e8ffaf");
                }

                //show admin extra info
                Div1.Visible = true;
            }

            //msgs
            LinkedList<Massege> msgList = bl.GetMassege(int.Parse("" + Session["id"]));
            msgs.Text = "" + msgList.Count;

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;

        }
    }
}