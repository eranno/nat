using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class employees : System.Web.UI.Page
    {
        private EmployeeBL bl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();

            //get employees list
            LinkedList<Employee> eList = bl.GetAllEmployeeInWork();
            //foreach (Employee emp in eList)
            //{
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                TableCell tCell3 = new TableCell();
                TableCell tCell4 = new TableCell();

                tCell1.Text = "1";
                tCell2.Text = "2";
                tCell3.Text = "3";
                tCell4.Text = "4";

                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                tRow.Cells.Add(tCell3);
                tRow.Cells.Add(tCell4);
                Table1.Rows.Add(tRow);
            //}


        }

        protected void button_Click(object sender, EventArgs e)
        {
            //validate info
            int id                  = int.Parse(new_id.Text);
            string firstName        = new_first.Text;
            string lastName         = new_last.Text;
            int rank                = int.Parse(new_rank.Text);
            int wage                = int.Parse(new_wage.Text);
            int minhours            = int.Parse(new_minhours.Text);
            int maxhours            = int.Parse(new_maxhours.Text);
            int overtimeinday       = int.Parse(new_overtimeinday.Text);
            int overtimeinmonth     = int.Parse(new_overtimeinmonth.Text);
            int sick                = int.Parse(new_sick.Text);
            int vacation            = int.Parse(new_vacation.Text);
            int timeheworkonday     = int.Parse(new_timeheworkonday.Text);
            int timeheworkonmonth   = int.Parse(new_timeheworkonmonth.Text);

            //add new employee
            Employee employee = new Employee(
                id,
                firstName,
                lastName,
                rank,
                wage,
                minhours,
                maxhours,
                overtimeinday,
                overtimeinmonth,
                sick,
                vacation,
                timeheworkonday,
                timeheworkonmonth
            );

            bool ok = bl.AddEmployee(employee);
            if (ok)
                msgs.InnerText = "העובד: " + firstName + " " + lastName + " הוסף בהצלחה!";
            else
                msgs.InnerText = "שגיאה: העובד כבר קיים במערכת";
            msgs.Visible = true;
        }
    }
}