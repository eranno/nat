using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class info : System.Web.UI.Page
    {
        private EmployeeBL bl;
        private Employee employee;          //the logged in user
        private Employee watchEmployee;     //if admin, show him other users

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();
            employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;

            //watch details
            if (Request.QueryString["id"] != null)
            {
                watchEmployee = bl.GetEmployeeId(int.Parse("" + Request.QueryString["id"]));
                if (watchEmployee == null)
                    Response.Redirect("error.aspx?e=משתמש אינו קיים!");

                new_id.Text = "" + watchEmployee.Id;
                new_first.Text = "" + watchEmployee.FirstName;
                new_last.Text = "" + watchEmployee.LastName;
                new_rank.Text = "" + watchEmployee.Rank;
                new_wage.Text = "" + watchEmployee.Wage;
                new_minhours.Text = "" + watchEmployee.Minhours;
                new_maxhours.Text = "" + watchEmployee.Maxhours;
                new_sick.Text = "" + watchEmployee.Sick;
                new_vacation.Text = "" + watchEmployee.Vacation;
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            //update user info
            if (Request.QueryString["id"] != null)
            {

                //validate info
                int id = int.Parse(new_id.Text);
                string firstName = new_first.Text;
                string lastName = new_last.Text;
                int rank = int.Parse(new_rank.Text);
                int wage = int.Parse(new_wage.Text);
                int minhours = int.Parse(new_minhours.Text);
                int maxhours = int.Parse(new_maxhours.Text);
                int sick = int.Parse(new_sick.Text);
                int vacation = int.Parse(new_vacation.Text);


                Employee employee = new Employee(
                    id,
                    firstName,
                    lastName,
                    rank,
                    wage,
                    minhours,
                    maxhours,
                    -1,
                    -1,
                    sick,
                    vacation,
                    -1,
                    -1
                );

                bl.UpdateEmployee(employee);
                msgs.InnerText = "הפרטים עודכנו בהצלחה";
                msgs.Visible = true;
            }

            //update password
            else
            {

                bool ok = bl.ChangePassword(int.Parse("" + Session["id"]), oldpass.Text, pass1.Text, pass2.Text);

                if (ok)
                    msgs.InnerText = "הסיסמה עודכנה בהצלחה";
                else
                    msgs.InnerText = "הסיסמה או אימות השישמה שגויים";
                msgs.Visible = true;
            }
        }
    }
}