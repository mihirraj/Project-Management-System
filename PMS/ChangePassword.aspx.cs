using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PMS
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            cd = new SqlCommand("checklogin",con);

            cd.Parameters.AddWithValue("@email", Session["email"].ToString());
            cd.Parameters.AddWithValue("@pass", TextBox1.Text);

            cd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            bool b = false;
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Valid Password');", true);
            }


            if (b)
            {
                cd = new SqlCommand("changepass", con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                cd.Parameters.AddWithValue("@pass", TextBox2.Text);
                cd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password Changed Successfully');", true);
                TextBox1.Text = "";
                Session.Remove("email");
                Session.Remove("pass");
                Session.Remove("loginrole");
                Response.Redirect("Login.aspx");
            }
           
            

}
        
    }
}