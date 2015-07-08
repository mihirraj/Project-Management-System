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
    
    public partial class WebForm6 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    TextBox1.Text = Request.Cookies["UserName"].Value;
                    TextBox2.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }


        }
        protected void Login_Click(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = TextBox1.Text.Trim();
            Response.Cookies["Password"].Value = TextBox2.Text.Trim();

            int loginrole = 0;

            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                if (RadioButtonList1.Items[i].Selected==true)
                {
                    loginrole = Convert.ToInt16(RadioButtonList1.Items[i].Value);
                }
            }


            //int userrole = 0;

            
            //cd = new SqlCommand("loginemp", con);
            //cd.Parameters.AddWithValue("@email", TextBox1.Text);
            //cd.Parameters.AddWithValue("@password", TextBox2.Text);
            //cd.CommandType = CommandType.StoredProcedure;
            //da = new SqlDataAdapter(cd);
            //dt = new DataTable();
            //da.Fill(dt);
            //foreach (DataRow item in dt.Rows)
            //{

            //    userrole =Convert.ToInt16(item[6]);
            //}





            if (loginrole == 1)
            {
                cd = new SqlCommand("loginemp", con);
                cd.Parameters.AddWithValue("@email", TextBox1.Text);
                cd.Parameters.AddWithValue("@password", TextBox2.Text);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count==0)
                {
                     string script = "alert(\"Please Enter Correct Details!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                }
                foreach (DataRow item in dt.Rows)
                {
                   
                    int userrole = Convert.ToInt16(item[1]);


                    if (loginrole==userrole)
                    {
                        Session["loginrole"] = userrole;
                        Session["email"] = item[0].ToString();
                        Session["pass"] = item[2].ToString();
                        
                        if (item[2].ToString() == "reset123")
                        {
                            Response.Redirect("ChangePassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("DashboardManager.aspx");
                        }
                    }
                    else
                    {
                        string script = "alert(\"Please Enter Correct Details!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }


                    
                }
            }

            if (loginrole == 2)
            {
                cd = new SqlCommand("loginemp", con);
                cd.Parameters.AddWithValue("@email", TextBox1.Text);
                cd.Parameters.AddWithValue("@password", TextBox2.Text);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    string script = "alert(\"Please Enter Correct Details!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                foreach (DataRow item in dt.Rows)
                {
                    
                    int userrole = Convert.ToInt16(item[1]);


                    if (loginrole == userrole)
                    {
                        Session["loginrole"] = userrole;
                        Session["email"] = item[0].ToString();
                        Session["pass"] = item[2].ToString();

                        

                        if (item[2].ToString() == "reset123")
                        {
                            Response.Redirect("ChangePassword.aspx");
                        }
                        else
                        {
                            Response.Redirect("DashboardTeamleader.aspx");
                        }

                    }
                    else
                    {
                        string script = "alert(\"Please Enter Correct Details!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }

                }

            }

            if (loginrole == 3)
            {
                cd = new SqlCommand("loginemp", con);
                cd.Parameters.AddWithValue("@email", TextBox1.Text);
                cd.Parameters.AddWithValue("@password", TextBox2.Text);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    string script = "alert(\"Please Enter Correct Details!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                foreach (DataRow item in dt.Rows)
                {int userrole = Convert.ToInt16(item[1]);
               

                if (loginrole == userrole)
                {
                    Session["loginrole"] = userrole;
                    Session["email"] = item[0].ToString();
                    Session["pass"] = item[2].ToString();
                    
                    if (item[2].ToString() == "reset123")
                    {
                        Response.Redirect("ChangePassword.aspx");
                    }
                    else
                    {
                        Response.Redirect("DashboardJunior.aspx");
                    }
                }
                else
                {
                    string script = "alert(\"Please Enter Correct Details!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                }

            }

            if (loginrole == 4)
            {
                cd = new SqlCommand("loginemp", con);
                cd.Parameters.AddWithValue("@email", TextBox1.Text);
                cd.Parameters.AddWithValue("@password", TextBox2.Text);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count==0)
                {
                    string script = "alert(\"Please Enter Correct Details!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }

                foreach (DataRow item in dt.Rows)
                {
                   
                    
                    int userrole = Convert.ToInt16(item[1]);


                if (loginrole == userrole)
                {
                    Session["loginrole"] = userrole;
                    Session["email"] = item[0].ToString();
                    Session["pass"] = item[2].ToString();
                   
                    if (item[2].ToString() == "reset123")
                    {
                        Response.Redirect("ChangePassword.aspx");
                    }
                    else
                    {
                        Response.Redirect("DashboardAdmin.aspx");
                    }
                }
                else
                {
                    string script = "alert(\"Please Enter Correct Details!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                }

            }
		 
	
               



           
            
        }
    }
}