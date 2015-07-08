using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace PMS
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                da = new SqlDataAdapter("select * from employee",con);
                dt = new DataTable();
                da.Fill(dt);
                gd1.DataSource = dt;
                gd1.DataBind();
            }
           
        }

        protected void gd1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}