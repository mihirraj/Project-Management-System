using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS
{
    public partial class PMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Header.DataBind(); 
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
           


        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void GetMemberSearchData(string searchString)
        {

            //int role = Convert.ToInt16(Session["loginrole"]);
            //if (role == 1)
            //{
            //    Response.Redirect("ProfileAdmin.aspx");
            //}
            //else if (role == 2)
            //{
            //    Response.Redirect("ProfileManager.aspx");
            //}
            //else if (role == 3)
            //{
            //    Response.Redirect("ProfileTeamLeader.aspx");
            //}
            //else
            //{
            //    Response.Redirect("ProfileJunior.aspx");
            //}


        }
    }
       
}