using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class sick : System.Web.UI.Page
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
            int[] array = bl.SickVactionMonth(int.Parse("" + Session["id"]),year,1);
            int[] arraysum = bl.Sum(int.Parse("" + Session["id"]),1, year);
            totalSum.Text = "" + arraysum[0];
            havesum.Text = "" + arraysum[3];
            lass.Text = "" + arraysum[2];
            use.Text = "" + arraysum[1];
               for(int i=0; i<array.Length;i++)
               {
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();
                int x=i+1;
            
                string str = x.ToString() +"/"+ year.ToString();
                tCell1.Text = str;
                tCell2.Text = array[i].ToString();


                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);
                Table1.Rows.Add(tRow);
             }
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


           // bl.SetMassege(1, int.Parse("" + Session["id"]), 2, start.Text + "," + end.Text);


        }
    }
}