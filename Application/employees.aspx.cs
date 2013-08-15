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
        private LinkedList<Employee> eList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("index.aspx");

            bl = new EmployeeBL();
            Employee employee = bl.GetEmployeeId(int.Parse("" + Session["id"]));

            //user info
            last.Text = employee.LastName;
            first.Text = employee.FirstName;


            //get all employees list
            eList = bl.GetAllEmployee();
            foreach (Employee emp in eList)
            {
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                TableCell tCell3 = new TableCell();
                TableCell tCell4 = new TableCell();

                tCell1.Text = ""+emp.Id;
                tCell2.Text = emp.FirstName;
                tCell3.Text = emp.LastName;
                tCell4.Text = ""+emp.Rank;

                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                tRow.Cells.Add(tCell3);
                tRow.Cells.Add(tCell4);
                Table1.Rows.Add(tRow);
            }


            //get current employees list
            eList = bl.GetAllEmployeeInWork();
            foreach (Employee emp in eList)
            {
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                TableCell tCell3 = new TableCell();
                TableCell tCell4 = new TableCell();
                TableCell tCell5 = new TableCell();

                tCell1.Text = "" + emp.Id;
                tCell2.Text = emp.FirstName;
                tCell3.Text = emp.LastName;
                tCell4.Text = "" + emp.Rank;
                tCell5.Text = (emp.Timeheworkonday / 60) + ":" + emp.Timeheworkonday;

                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                tRow.Cells.Add(tCell3);
                tRow.Cells.Add(tCell4);
                tRow.Cells.Add(tCell5);
                Table2.Rows.Add(tRow);
            }


        }

        protected void button_Click4(object sender, EventArgs e)
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

        protected void button_Click3(object sender, EventArgs e)
        {
            Employee emp;

            //id
            if (int.Parse(js_select.Value) == 1)
            {
                int id = bl.toInt(opt_id.Text);
                emp = bl.GetEmployeeId(id);
            }

            //first + last name
            else
            {
                emp = bl.GetEmployeeName(opt_first.Text, opt_last.Text);
            }

            if (emp == null)
            {
                msgs.InnerText = "שגיאה: העובד לא נמצא!";
                msgs.Visible = true;

                opt_id.Text = "";
                opt_first.Text = "";
                opt_last.Text = "";
            }
            else
            {
                Response.Redirect("main.aspx?id="+emp.Id);
            }
        }
    }
}