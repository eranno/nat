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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                return;


            //Request.QueryString["id"]
            //Request.QueryString["t"]
            //xmlHttpRequest.open("GET", "update.aspx?id=" + id + "&day=" + day + "&reason=" + reason + "&type=" + type, true);

            Response.Write( "arg" );
        }
    }
}