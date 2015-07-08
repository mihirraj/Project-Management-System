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
    public partial class RemoveEmployee : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.EnableViewState = true;
            if (!IsPostBack)
            {
                cd = new SqlCommand("select image_url,ename from employee where eemail=@email", con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    userimage.ImageUrl = item[0].ToString();
                    username.Text = item[1].ToString();


                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Search_Click(object sender, EventArgs e)
        {
            cd = new SqlCommand("getempdetailsnamere", con);
            cd.Parameters.AddWithValue("@EmpName", Name.Text);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                gd1.DataSource = dt;
                gd1.DataBind();    
                
            }
            else
            {

              
                string script = "alert(\"Data Not Found!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                Name.Text = "";
                gd1.DataSource = "";
                gd1.DataBind();  

            }

            
        }

        protected void gd1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(gd1.DataKeys[e.RowIndex].Value);


            cd = new SqlCommand("deleteemp",con);
            cd.Parameters.AddWithValue("@sid", id);
            cd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();


            cd = new SqlCommand("getempdetailsnamere", con);
            cd.Parameters.AddWithValue("@EmpName", Name.Text);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            gd1.DataSource = dt;
            gd1.DataBind();

        }

       
    }
}