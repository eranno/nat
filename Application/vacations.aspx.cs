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

       
            int year = 2013;
            int[] array = bl.SickVactionMonth(int.Parse("" + Session["id"]), year, 2);
            int[] arraysum = bl.Sum(int.Parse("" + Session["id"]), 2, year);
            totalSum.Text = "" + arraysum[0];
            havesum.Text = "" + arraysum[3];
            lass.Text = "" + arraysum[2];
            use.Text = "" + arraysum[1];
            for (int i = 0; i < array.Length; i++)
            {
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                int x = i + 1;

                string str = x.ToString() + "/" + year.ToString();
                tCell1.Text = str;
                tCell2.Text = array[i].ToString();


                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                Table1.Rows.Add(tRow);
            }

        }

        protected void button_Click(object sender, EventArgs e)
        {
            err.Style.Add("width", "400px");
            toggle.Style.Remove("disply");


            //validate
            //missing data?
            if (start.Text == "" || end.Text == "")
            {
                err.Text = "נא למלא את כל השדות";
                return;
            }

           string start1 =start.Text;
           string end1 =end.Text;
            
        
            //התאריכים שביקש חוקים
         bool ok = bl.VacLegal(start1, end1);

         if (ok == true)
         {
             int year = DateTime.Parse("" + start1).Year;

             //מספר ימי חופשה שביקש
             int sumday = bl.SumDays(start1, end1);

             //חריגים
             int dayslass = bl.CheckVac(int.Parse("" + Session["id"]), sumday, year, 2);
             if (dayslass != 0 && !check1.Checked)
             {
                 err.Text = "חרגת ממספר ימי החופשה ב:" + dayslass.ToString() + "אם ברצונך לאשר בכל זאת את הבקשה לחץ בשנית על שלח";
                 check1.Visible = true;

             }
             else
             {
                 string stri = "from" + start1 + ", to" + end1;
                 bl.SetMassege(55555, int.Parse("" + Session["id"]), 2, stri,DateTime.Now.ToString());
                 start.Text = "";
                 end.Text = "";
             }
         }
         else
         {
             err.Text = "יש שגיאה בהכנסת התאריכים, וודא שהתאריכים שנכנסו חוקיים";
             start.Text="";
             end.Text="";
         }
        }
    }
}