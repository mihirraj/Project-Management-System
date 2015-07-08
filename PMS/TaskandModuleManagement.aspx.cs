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
    public partial class TaskandModuleManagement : System.Web.UI.Page

    {

        SqlCommand cd;
        SqlCommand cd1;
        SqlDataAdapter da1;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt1;
        SqlCommand cd2;
        SqlDataAdapter da2;
        DataTable dt2;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack== false)
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
                    id = Convert.ToInt16(item[0]);
                }
                cd2 = new SqlCommand("getprojectsteamleader", con);
                cd2.CommandType = CommandType.StoredProcedure;
                cd2.Parameters.AddWithValue("@empid", id);
                da2 = new SqlDataAdapter(cd2);
                dt2 = new DataTable();
                da2.Fill(dt2);

                DropDownListproject1.DataSource= dt2;
                DropDownListproject1.DataTextField = "pname";
                DropDownListproject1.DataValueField = "pid";
                DropDownListproject1.DataBind();

                cd1 = new SqlCommand("getprojectsteamleader", con);
                cd1.CommandType = CommandType.StoredProcedure;
                cd1.Parameters.AddWithValue("@empid", id);
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                DropDownListProject.DataSource = dt1;
                DropDownListProject.DataTextField = "pname";
                DropDownListProject.DataValueField = "pid";
                DropDownListProject.DataBind();

                ListItem li = new ListItem();
                li.Text = "Select Project";
                li.Value = 0.ToString();
                DropDownListproject1.Items.Insert(0, li);

                ListItem li1 = new ListItem();
                li1.Text = "Select Project";
                li1.Value = 0.ToString();
                DropDownListProject.Items.Insert(0, li1);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt16(DropDownListproject1.SelectedItem.Value) == 0)
            {
                string script = "alert(\"Please Select Project!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            


            else
            {
                cd = new SqlCommand("createmodule", con);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@pid", DropDownListproject1.SelectedItem.Value);
                cd.Parameters.AddWithValue("@mname", TextBox1.Text);
                con.Open();
                cd.ExecuteNonQuery();
                con.Close();
                TextBox1.Text = "";
            }

        }

        protected void DropDownListProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cd3;
            SqlDataAdapter da3;
            DataTable dt3;
            cd3 = new SqlCommand("getmodules", con);

            cd3.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);
            cd3.CommandType = CommandType.StoredProcedure;
            da3 = new SqlDataAdapter(cd3);
            dt3 = new DataTable();
            da3.Fill(dt3);
            GridView1.DataSource = dt3;
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);


            cd = new SqlCommand("deleteModule", con);
            cd.Parameters.AddWithValue("@mid", id);
            cd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();


            SqlCommand cd3;
            SqlDataAdapter da3;
            DataTable dt3;
            cd3 = new SqlCommand("getmodules", con);

            cd3.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);
            cd3.CommandType = CommandType.StoredProcedure;
            da3 = new SqlDataAdapter(cd3);
            dt3 = new DataTable();
            da3.Fill(dt3);
            GridView1.DataSource = dt3;
            GridView1.DataBind();
        }
    }
}