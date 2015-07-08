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
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cd1;
        SqlDataAdapter da1;
        DataTable dt1;

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
                cd1 = new SqlCommand("getteamleader", con);
                cd1.CommandType = CommandType.StoredProcedure;

                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                ddl2.DataSource = dt1;
                ddl2.DataTextField = "ename";
                ddl2.DataValueField = "eid";
                ddl2.DataBind();
 
            }

            if (!IsPostBack)
            {
                Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            }

            ListItem li = new ListItem();
            li.Text = "Select Team Leader";
            li.Value = 0.ToString();
            ddl2.Items.Insert(0, li);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt16(ddl2.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select TeamLeader!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (!FileUpload1.HasFile)
            {
                string script = "alert(\"Please Select Project Image!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }


            else { 




            cd = new SqlCommand("insert_project",con);
            cd.CommandType = CommandType.StoredProcedure;

            cd.Parameters.AddWithValue("@pname", TextBox1.Text);
            cd.Parameters.AddWithValue("@psdate", TextBox2.Text);
            cd.Parameters.AddWithValue("@pedate", TextBox3.Text);
            cd.Parameters.AddWithValue("@budget", TextBox4.Text);
            cd.Parameters.AddWithValue("@description", TextBox5.Text);
            cd.Parameters.AddWithValue("@team_leader", ddl2.SelectedItem.Text);

            cd.Parameters.AddWithValue("@empid", Convert.ToInt16(ddl2.SelectedItem.Value));
           




            string imgpath = "~/assets/img/project/" + FileUpload1.FileName;
            cd.Parameters.AddWithValue("@image", imgpath);
            FileUpload1.SaveAs(Server.MapPath("~/assets/img/project/") + FileUpload1.FileName);

            con.Open();
            cd.ExecuteNonQuery();
            con.Close();
            string script = "alert(\"Successfully added Project!\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";


        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
   
        }
    }
}