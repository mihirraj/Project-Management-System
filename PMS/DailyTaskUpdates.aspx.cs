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
    public partial class DailyTaskUpdates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        SqlCommand cd1;


        SqlDataAdapter da1;
        DataTable dt1;
        SqlCommand cd;
        SqlDataAdapter da;
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


                ViewState["id"] = id;
                cd1 = new SqlCommand("getProjects", con);
                cd1.CommandType = CommandType.StoredProcedure;
                cd1.Parameters.AddWithValue("@eid", id);
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "pname";
                DropDownList1.DataValueField = "ProjectID";
                DropDownList1.DataBind();


                ListItem li = new ListItem();
                li.Text = "Select Module";
                li.Value = 0.ToString();
                DropDownList2.Items.Insert(0, li);

                ListItem li1 = new ListItem();
                li1.Text = "Select Project";
                li1.Value = 0.ToString();
                DropDownList1.Items.Insert(0, li1);

                ListItem li2 = new ListItem();
                li2.Text = "Select Task";
                li2.Value = 0.ToString();
                DropDownList3.Items.Insert(0, li2);
            }

            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

           


            cd1 = new SqlCommand("getmodulebyproject", con);
            cd1.Parameters.AddWithValue("@pid", DropDownList1.SelectedItem.Value);
            cd1.Parameters.AddWithValue("@eid", Convert.ToInt16(ViewState["id"]));
            cd1.CommandType = CommandType.StoredProcedure;
            dt1 = new DataTable();
            da1 = new SqlDataAdapter(cd1);
            da1.Fill(dt1);
            DropDownList2.DataSource = dt1;
            DropDownList2.DataTextField = "ModuleName";
            DropDownList2.DataValueField = "ModuleID";
            DropDownList2.DataBind();
            bool b = false;

            for (int i = 0; i < DropDownList2.Items.Count; i++)
            {
                if (Convert.ToInt16(DropDownList2.Items[i].Value) == 0)
                {
                    b = true;
                    break;
                }
            }

            if (!b)
            {
                ListItem li = new ListItem();
                li.Text = "Select Module";
                li.Value = 0.ToString();
                DropDownList2.Items.Insert(0, li);
            }

            //cd1 = new SqlCommand("getTask", con);
            //cd1.Parameters.AddWithValue("@ProjectID", DropDownList1.SelectedItem.Value);
            //cd1.Parameters.AddWithValue("@ModuleID", DropDownList2.SelectedItem.Value);
            //cd1.CommandType = CommandType.StoredProcedure;
            //dt1 = new DataTable();
            //da1 = new SqlDataAdapter(cd1);
            //da1.Fill(dt1);
            //DropDownList3.DataSource = dt1;
            //DropDownList3.DataBind();



        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            


            cd1 = new SqlCommand("gettaskbyeid", con);
            cd1.Parameters.AddWithValue("@mid", DropDownList2.SelectedItem.Value);
            cd1.Parameters.AddWithValue("@eid", Convert.ToInt16(ViewState["id"]));
           
            cd1.CommandType = CommandType.StoredProcedure;
            dt1 = new DataTable();
            da1 = new SqlDataAdapter(cd1);
            da1.Fill(dt1);
            DropDownList3.DataSource = dt1;
            DropDownList3.DataTextField = "TaskName";
            DropDownList3.DataValueField = "TaskID";
            DropDownList3.DataBind();
            bool b = false;

            for (int i = 0; i < DropDownList3.Items.Count; i++)
            {
                if (Convert.ToInt16(DropDownList3.Items[i].Value) == 0)
                {
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                 ListItem li = new ListItem();
                li.Text = "Select Module";
                li.Value = 0.ToString();
                DropDownList3.Items.Insert(0, li);
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt16(DropDownList1.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select Project!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            
            else if (Convert.ToInt16(DropDownList2.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select Module!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (Convert.ToInt16(DropDownList3.SelectedItem.Value)==0)
            {
                string script = "alert(\"Please Select Task!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            else if (!FileUpload1.HasFile)
            {
                string script = "alert(\"Please Select File to Upload!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            else
            {
                FileUpload1.SaveAs(Server.MapPath("~/assets/dailyrpt/") + FileUpload1.FileName);
                string url = "~/assets/dailyrpt/" + FileUpload1.FileName;
                int id = 0;

                cd1 = new SqlCommand("findEid", con); string email = Session["email"].ToString();
                cd1.Parameters.AddWithValue("@email", email);

                cd1.CommandType = CommandType.StoredProcedure;
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                foreach (DataRow item in dt1.Rows)
                {
                    id = Convert.ToInt16(item[0]);
                }



                DateTime date1 = DateTime.Now;
                string sdate = date1.ToString("yyyy-MM-dd HH':'mm':'ss");

                cd1 = new SqlCommand("insertreport", con);
                cd1.CommandType = CommandType.StoredProcedure;
                cd1.Parameters.AddWithValue("@pid", DropDownList1.SelectedItem.Value);
                cd1.Parameters.AddWithValue("@eid", id);
                cd1.Parameters.AddWithValue("@date", sdate);
                cd1.Parameters.AddWithValue("@desc", TextArea1.Text);
                cd1.Parameters.AddWithValue("@furl", url);

                cd1.Parameters.AddWithValue("@prg", TextBox1.Text);
                cd1.Parameters.AddWithValue("@mid", DropDownList2.SelectedItem.Value);
                cd1.Parameters.AddWithValue("@tid", DropDownList3.SelectedItem.Value);

                con.Open();
                cd1.ExecuteNonQuery();
                con.Close();

                TextArea1.Text = "";
                TextBox1.Text = "";
                string script = "alert(\"Task Updated Successfully!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }


        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b = false;

            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (Convert.ToInt16(DropDownList1.Items[i].Value) == 0)
                {
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                ListItem li = new ListItem();
                li.Text = "Select Module";
                li.Value = 0.ToString();
                DropDownList2.Items.Insert(0, li);
            }
        }
    }
}