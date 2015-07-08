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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        SqlCommand cd1;
        SqlCommand cd2;
        SqlCommand cd;
        SqlDataAdapter da2;
        SqlDataAdapter da1;
        SqlDataAdapter da;
        DataTable dt1;
        DataTable dt2;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (IsPostBack == false)
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


                cd1 = new SqlCommand("getprojectsteamleader", con);
                cd1.CommandType = CommandType.StoredProcedure;
                cd1.Parameters.AddWithValue("@empid", id);
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "pname";
                DropDownList1.DataValueField = "pid";
                DropDownList1.DataBind();

                cd2 = new SqlCommand("getJuniors", con);
                cd2.CommandType = CommandType.StoredProcedure;

                da2 = new SqlDataAdapter(cd2);
                dt2 = new DataTable();
                da2.Fill(dt2);

                DropDownList3.DataSource = dt2;
                DropDownList3.DataTextField = "ename";
                DropDownList3.DataValueField = "eid";
                DropDownList3.DataBind();

                DropDownListProject.DataSource = dt1;
                DropDownListProject.DataTextField = "pname";
                DropDownListProject.DataValueField = "pid";
                DropDownListProject.DataBind();


                ListItem li = new ListItem();
                li.Text = "Select Project";
                li.Value = 0.ToString();
                DropDownList1.Items.Insert(0, li);

                ListItem li1 = new ListItem();
                li1.Text = "Select Module";
                li1.Value = 0.ToString();
                DropDownList2.Items.Insert(0, li1);

                ListItem li2 = new ListItem();
                li2.Text = "Select Junior";
                li2.Value = 0.ToString();
                DropDownList3.Items.Insert(0, li2);

                ListItem li3 = new ListItem();
                li3.Text = "Select Project";
                li3.Value = 0.ToString();
                DropDownListProject.Items.Insert(0, li3);

                ListItem li4 = new ListItem();
                li4.Text = "Select Module";
                li4.Value = 0.ToString();
                DropDownListModules.Items.Insert(0, li4);



            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        
        {
            SqlCommand cd3;
            SqlDataAdapter da3;
            DataTable dt3;
            cd3 = new SqlCommand("getModuleFromProject",con);
            cd3.CommandType = CommandType.StoredProcedure;
            cd3.Parameters.AddWithValue("@ProjectID", DropDownList1.SelectedItem.Value);

            da3 = new SqlDataAdapter(cd3);
            dt3 = new DataTable();
            da3.Fill(dt3);

            DropDownList2.DataSource = dt3;
            DropDownList2.DataTextField = "ModuleName";
            DropDownList2.DataValueField = "ModuleID";
            DropDownList2.DataBind();

        }

        protected void DropDownListProject_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            SqlCommand cd4;
            SqlDataAdapter da4;
            DataTable dt4;
            cd4 = new SqlCommand("getModuleFromProject", con);
            cd4.CommandType = CommandType.StoredProcedure;
            cd4.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);

            da4 = new SqlDataAdapter(cd4);
            dt4 = new DataTable();
            da4.Fill(dt4);

            

            DropDownListModules.DataSource = dt4;
            DropDownListModules.DataTextField = "ModuleName";
            DropDownListModules.DataValueField = "ModuleID";
            DropDownListModules.DataBind();


            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;

            cd = new SqlCommand("getTask", con);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);
            cd.Parameters.AddWithValue("@ModuleID", DropDownListModules.SelectedItem.Value);
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }

        protected void Button1_Click_InsertTaskAndAssign(object sender, EventArgs e)
        {
            if (Convert.ToInt16(DropDownList1.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select Project!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (Convert.ToInt16(DropDownList2.SelectedItem.Value) == 0)
            {
                string script = "alert(\"Please Select Module!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (Convert.ToInt16(DropDownList3.SelectedItem.Value) == 0)
            {
                string script = "alert(\"Please Select Junior!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }


            else
            {
                SqlCommand cd;

                cd = new SqlCommand("inserttask", con);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@pid", DropDownList1.SelectedItem.Value);
                cd.Parameters.AddWithValue("@mid", DropDownList2.SelectedItem.Value);
                cd.Parameters.AddWithValue("@tname", TextBox1.Text);
                cd.Parameters.AddWithValue("@eid", DropDownList3.SelectedItem.Value);
                con.Open();
                cd.ExecuteNonQuery();
                con.Close();
                TextBox1.Text = "";
            }
        }
        
        protected void DropDownListModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;

            cd = new SqlCommand("getTask", con);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);
            cd.Parameters.AddWithValue("@ModuleID", DropDownListModules.SelectedItem.Value);
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();







        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cd;
            
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            cd = new SqlCommand("deleteTask",con);
            cd.Parameters.AddWithValue("@TaskID", id);
            cd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();

            SqlCommand cd1;
            SqlDataAdapter da;
            DataTable dt;

            cd1 = new SqlCommand("getTask", con);
            cd1.CommandType = CommandType.StoredProcedure;
            cd1.Parameters.AddWithValue("@ProjectID", DropDownListProject.SelectedItem.Value);
            cd1.Parameters.AddWithValue("@ModuleID", DropDownListModules.SelectedItem.Value);
            da = new SqlDataAdapter(cd1);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            
        }
    }
}