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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlCommand cdCountry;
        SqlCommand cdCity;
        SqlCommand cdState;
        SqlDataAdapter da;
        SqlDataAdapter daCountry;
        SqlDataAdapter daCity;
        SqlDataAdapter daState;
        DataTable dt;
        DataTable dtCountry;
        DataTable dtCity;
        DataTable dtState;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
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
                cdCountry = new SqlCommand("getCountry", con);
                cdCountry.CommandType = CommandType.StoredProcedure;

                cdState = new SqlCommand("getState", con);
                cdState.Parameters.AddWithValue("@CID", 1);
                cdState.CommandType = CommandType.StoredProcedure;

                cd = new SqlCommand("getspelization", con);
                cd.CommandType = CommandType.StoredProcedure;
                
                cdCity = new SqlCommand("getCity", con);
                cdCity.Parameters.AddWithValue("@sid", 1);
                cdCity.CommandType = CommandType.StoredProcedure;


                daCountry = new SqlDataAdapter(cdCountry);
                dtCountry = new DataTable();
                daCountry.Fill(dtCountry);

                daState = new SqlDataAdapter(cdState);
                dtState = new DataTable();
                daState.Fill(dtState);

                daCity = new SqlDataAdapter(cdCity);
                dtCity = new DataTable();
                daCity.Fill(dtCity);

                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                ddl.DataSource = dt;
                ddl.DataTextField = "des_name";
                ddl.DataValueField = "id";
                ddl.DataBind();

                ddl3.DataSource = dtCountry;
                ddl3.DataTextField = "CountryName";
                ddl3.DataValueField = "CountryID";
                ddl3.DataBind();

                ddl5.DataSource = dtCity;
                ddl5.DataTextField = "CityName";
                ddl5.DataValueField = "CityID";
                ddl5.DataBind();

                ddl4.DataSource = dtState;
                ddl4.DataTextField = "StateName";
                ddl4.DataValueField = "StateID";
                ddl4.DataBind();



                da = new SqlDataAdapter("select * from role",con);
                dt = new DataTable();
                da.Fill(dt);
                ddl2.DataSource = dt;
                ddl2.DataTextField = "Role";
                ddl2.DataValueField = "RoleID";
                ddl2.DataBind();



                ListItem li = new ListItem();
                li.Text = "Select Country";
                li.Value = 0.ToString();
                ddl3.Items.Insert(0, li);

                ListItem li1 = new ListItem();
                li1.Text = "Select State";
                li1.Value = 0.ToString();
                ddl4.Items.Insert(0, li1);

                ListItem li2 = new ListItem();
                li2.Text = "Select City";
                li2.Value = 0.ToString();
                ddl5.Items.Insert(0, li2);

                ListItem li3 = new ListItem();
                li3.Text = "Select Position";
                li3.Value = 0.ToString();
                ddl2.Items.Insert(0, li3);

                ListItem li4 = new ListItem();
                li4.Text = "Select Specialization";
                li4.Value = 0.ToString();
                ddl.Items.Insert(0, li4);
            }
           


            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            cd = new SqlCommand("addemp", con);
            cd.Parameters.AddWithValue("@ename", TextBox6.Text);
            cd.Parameters.AddWithValue("@eemail", TextBox7.Text);
            cd.Parameters.AddWithValue("@econtact", TextBox8.Text);

            if (RadioButton1.Checked==true)
	{
        cd.Parameters.AddWithValue("@egender", RadioButton1.Text);
	}
            else
            {
                cd.Parameters.AddWithValue("@egender", RadioButton2.Text);
            }

            if (Convert.ToInt16(ddl3.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select Country!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (!FileUpload1.HasFile)
            {
                string script = "alert(\"Please Select Project Image!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (Convert.ToInt16(ddl4.SelectedItem.Value) == 0)
            {
                string script = "alert(\"Please Select State!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (Convert.ToInt16(ddl5.SelectedItem.Value) == 0)
	{
        string script = "alert(\"Please Select City!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
	}
            else if (Convert.ToInt16(ddl.SelectedItem.Value) == 0)
	{
        string script = "alert(\"Please Select Specialization!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
	}
            else if (Convert.ToInt16(ddl2.SelectedItem.Value) == 0)
	{
        string script = "alert(\"Please Select Position!\");";
        ScriptManager.RegisterStartupScript(this, GetType(),
                              "ServerControlScript", script, true);
	}


            else
            {
                cd.Parameters.AddWithValue("@cid", ddl3.SelectedItem.Value);
                cd.Parameters.AddWithValue("@sid", ddl4.SelectedItem.Value);
                cd.Parameters.AddWithValue("@cityid", ddl5.SelectedItem.Value);
                cd.Parameters.AddWithValue("@spid", ddl.SelectedItem.Value);
                cd.Parameters.AddWithValue("@eposition", ddl2.SelectedItem.Value);
                string imgpath = "~/assets/img/" + FileUpload1.FileName;
                cd.Parameters.AddWithValue("@img_url", imgpath);
                FileUpload1.SaveAs(Server.MapPath("~/assets/img/") + FileUpload1.FileName);
                cd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cd.ExecuteNonQuery();
                con.Close();

                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";

                string script = "alert(\"Successfully added Employee!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

            }

        }

        protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd = new SqlCommand("getState", con);
            cd.Parameters.AddWithValue("@cid", Convert.ToInt16(ddl3.SelectedItem.Value));
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            ddl4.DataSource = dt;
            ddl4.DataTextField = "StateName";
            ddl4.DataValueField = "StateID";
            ddl4.DataBind();
            

            cd = new SqlCommand("getCity", con);
            cd.Parameters.AddWithValue("@sid", Convert.ToInt16(ddl4.SelectedItem.Value));
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            ddl5.DataSource = dt;
            ddl5.DataTextField = "CityName";
            ddl5.DataValueField = "CityID";
            ddl5.DataBind();
        }

        protected void ddl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd = new SqlCommand("getCity", con);
            cd.Parameters.AddWithValue("@sid", Convert.ToInt16(ddl4.SelectedItem.Value));
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            ddl5.DataSource = dt;
            ddl5.DataTextField = "CityName";
            ddl5.DataValueField = "CityID";
            ddl5.DataBind();
        }
    }
}