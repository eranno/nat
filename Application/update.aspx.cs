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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                return;

            

            //Request.QueryString["id"]
            //Request.QueryString["t"]
            //Request.QueryString["t"]
            //
            //xmlHttpRequest.open("GET", "update.aspx?id=" + id + "&day=" + day + "&txt=" + txt + "&type=" + type, true);


            /*
        private int idreceiver;
        private int idsender;
        private int type;
        private string note;
        private int approve;
        private string date;
        private int read;
        private string lastName;
        private string firstName; 
             */



            //Massege msg = new Massege(55555, int.Parse("" + Session["id"]), int.Parse("" + Request.QueryString["type"]), Request.QueryString["txt"], 0, Request.QueryString["day"], 0, "", "");
            bl.SetMassege(55555, int.Parse("" + Session["id"]), int.Parse("" + Request.QueryString["type"]), Request.QueryString["txt"], Request.QueryString["day"]);
            Response.Write( "arg" );
        }
    }
}