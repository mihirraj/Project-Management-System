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
    public partial class MyTasks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cd1;
        SqlDataAdapter da1;
        DataTable dt1;
        SqlCommand cd2;
        SqlDataAdapter da2;
        DataTable dt2;

        protected void Page_Load(object sender, EventArgs e)
        {
            

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
                int id = 0;
                
                cd = new SqlCommand("findEid", con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                string email = Session["email"].ToString();
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    id =Convert.ToInt16(item[0]);
                }

                cd1 = new SqlCommand("myTask", con);
                cd1.Parameters.AddWithValue("@eid", id);
                cd1.CommandType = CommandType.StoredProcedure;
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();

                ListItem li = new ListItem();
                li.Text = "Select";
                li.Value = 0.ToString();
                DropDownList1.Items.Insert(0, li);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text.Equals("done"))
            {
                int id = 0;
                cd = new SqlCommand("findEid", con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                string email = Session["email"].ToString();
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    id = Convert.ToInt16(item[0]);
                }

                cd2 = new SqlCommand("mytaskdone", con);
                cd2.Parameters.AddWithValue("@eid", id);
                cd2.CommandType = CommandType.StoredProcedure;
                da2 = new SqlDataAdapter(cd2);
                dt2 = new DataTable();
                da2.Fill(dt2);
                GridView1.DataSource = dt2;
                GridView1.DataBind();

                
            }
            else
            {

                int id = 0;

                cd = new SqlCommand("findEid", con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                string email = Session["email"].ToString();
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    id = Convert.ToInt16(item[0]);
                }

                cd1 = new SqlCommand("myTask", con);
                cd1.Parameters.AddWithValue("@eid", id);
                cd1.CommandType = CommandType.StoredProcedure;
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int id = 0;

            cd = new SqlCommand("findEid", con);
            cd.Parameters.AddWithValue("@email", Session["email"].ToString());
            string email = Session["email"].ToString();
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                id = Convert.ToInt16(item[0]);
            }

            cd1 = new SqlCommand("myTask", con);
            cd1.Parameters.AddWithValue("@eid", id);
            cd1.CommandType = CommandType.StoredProcedure;
            da1 = new SqlDataAdapter(cd1);
            dt1 = new DataTable();
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

        }


    }
}