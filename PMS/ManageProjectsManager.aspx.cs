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
    public partial class WebForm4 : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);


       
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;
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
            da = new SqlDataAdapter("select * from Project_master", con);
            dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("status1", typeof(System.String));

            foreach (DataRow item in dt.Rows)
            {
                if (item[8].ToString() == "True")
                {
                    item[11] = "Complete";
                }
                else
                {
                    item[11] = "Pending";
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

           
         
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            SqlDataAdapter da = new SqlDataAdapter("select * from Project_master", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("status1", typeof(System.String));

            foreach (DataRow item in dt.Rows)
            {
                if (item[8].ToString() == "True")
                {
                    item[11] = "Complete";
                }
                else
                {
                    item[11] = "Pending";
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label pnmae = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("Label1");
            Session["spid"] = pnmae.Text;
            Response.Redirect("ProjectDetailsManager.aspx");
        }

        protected void ButtonAdd_Project(object sender, EventArgs e)
        {
            Response.Redirect("AddProject.aspx");
        }
    }
}
