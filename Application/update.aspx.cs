using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class update : System.Web.UI.Page
    {
        private EmployeeBL bl;
        private DateTime dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                return;

            bl = new EmployeeBL();
            
            //validate
            //bl.SetMassege(, , int.Parse("" + Request.QueryString["type"]), Request.QueryString["txt"], Request.QueryString["day"]);
            int idreceiver = 55555;
            int idsender = int.Parse("" + Session["id"]);
            int type = bl.toInt("" + Request.QueryString["type"]);
            string note = Request.QueryString["txt"];
            string day = Request.QueryString["day"];
            string month = Request.QueryString["month"];
            string year = Request.QueryString["year"];

            if (day == "" || month == "" || year == "")
                dt = Convert.ToDateTime(day+"/"+month+"/"+year);
            else
                dt = DateTime.Now;

            bl.SetMassege(idreceiver, idsender, type, note, dt.ToString("dd/MM/yyyy"));
            Response.Write( "arg" );
        }
    }
}