using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PMS
{
    public partial class DashboardTeamleader : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cd = new SqlCommand("getprojectlist", con);
                cd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);





                dt.Columns.Add("status1", typeof(System.String));

                foreach (DataRow item in dt.Rows)
                {
                    if (item[5].ToString()=="True")
                    {
                        item[6] = "Complete";
                    }
                    else
                    {
                        item[6] = "Pending";
                    }
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();

                cd = new SqlCommand("select image_url,ename from employee where eemail=@email",con);
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

                cd = new SqlCommand("select Project_Master.pid,Project_Master.pname,Project_Master.ps_date,Project_Master.ps_enddate,Project_Master.budget from Project_Master where Project_Master.notification='False' and eid=@eid", con);
                cd.Parameters.AddWithValue("@eid",id);
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);

                gdnoti.DataSource = dt;
                gdnoti.DataBind();

            }
            cd = new SqlCommand("getrecentproject", con);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            datalist1.DataSource = dt1;
            datalist1.DataBind();


        }




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            cd = new SqlCommand("getprojectlist", con);
            cd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("status1", typeof(System.String));

            foreach (DataRow item in dt.Rows)
            {
                if (item[5].ToString() == "True")
                {
                    item[6] = "Complete";
                }
                else
                {
                    item[6] = "Pending";
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label pname = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("Label1");
            Session["spid"] = pname.Text;
            Response.Redirect("ProjectDetailsTeamLeader.aspx");

        }
    

        protected void image12_Command1(object sender, CommandEventArgs e)
        {
            Session["spid"] = e.CommandArgument.ToString();
            Response.Redirect("ProjectDetailsTeamLeader.aspx");
        }

        protected void gdnoti_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            gdnoti.PageIndex = e.NewPageIndex;
            cd = new SqlCommand("select  Project_Master.pid,Project_Master.pname,Project_Master.ps_date,Project_Master.ps_enddate,Project_Master.budget from Project_Master where Project_Master.notification='False' and eid=@eid", con);
            cd.Parameters.AddWithValue("@eid", id);
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);

            gdnoti.DataSource = dt;
            gdnoti.DataBind();
        }

        protected void button_Command(object sender, CommandEventArgs e)
        {
            int pid = Convert.ToInt16(e.CommandArgument);

            cd = new SqlCommand("update Project_Master set notification=1 where pid=@pid",con);
            cd.Parameters.AddWithValue("@pid",pid);
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();


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
            cd = new SqlCommand("select Project_Master.pid,Project_Master.pname,Project_Master.ps_date,Project_Master.ps_enddate,Project_Master.budget from Project_Master where Project_Master.notification='False' and eid=@eid", con);
            cd.Parameters.AddWithValue("@eid", id);
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);

            gdnoti.DataSource = dt;
            gdnoti.DataBind();

            Response.Redirect("TaskandModuleManagement.aspx");

        }
    }
}