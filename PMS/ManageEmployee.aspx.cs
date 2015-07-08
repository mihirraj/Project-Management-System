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
    public partial class ManageEmployee : System.Web.UI.Page
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
                cd = new SqlCommand("getempdetails",con);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;

            GridView1.PageIndex = e.NewPageIndex;
            cd = new SqlCommand("getempdetails", con);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ButtonAdd_Employee(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label Empemail = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("Label2");
            Session["spid"] = Empemail.Text;
            Response.Redirect("MyProfile.aspx");
        }
    }
}