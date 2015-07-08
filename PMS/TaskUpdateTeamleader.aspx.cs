using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace PMS
{
    public partial class TaskUpdateTeamleader : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
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
            }
            cd = new SqlCommand("getreport", con);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);




            foreach (DataRow item in dt.Rows)
            {

                string s1 = item[7].ToString();


                string[] newarray = s1.Split('/');


                item[7] = newarray[3].ToString();

            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            cd = new SqlCommand("getreport", con);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {

                string s1 = item[7].ToString();


                string[] newarray = s1.Split('/');


                item[7] = newarray[3].ToString();

            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Label5_Command(object sender, CommandEventArgs e)
        {
            cd = new SqlCommand("select FileURL from Task_Details where ReportID=@id", con);
            cd.Parameters.AddWithValue("@id", Convert.ToInt16(e.CommandArgument));
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);

            string furl = "";


            foreach (DataRow item in dt.Rows)
            {
                furl = item[0].ToString();
            }


            string PATH = furl;
            string type = Path.GetFileName(PATH);
            string[] str = type.Split('.');
            if (str[1] == "pdf")
            {
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "pptx")
            {
                Response.ContentType = "Application/vnd.ms-powerpoint";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "ppt")
            {

                Response.ContentType = "Application/vnd.ms-powerpoint";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "text")
            {
                Response.ContentType = "Application/vnd.ms-word";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();

            }
            else if (str[1] == "zip")
            {
                Response.ContentType = "application/x-zip-compressed";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "png")
            {
                Response.ContentType = "image/png";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "jpeg")
            {
                Response.ContentType = "image/jpeg";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "jpg")
            {
                Response.ContentType = "image/jpg";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }
            else if (str[1] == "gif")
            {
                Response.ContentType = "image/gif";
                Response.AppendHeader("Content-Dispotion", "attchment;filename=" + Path.GetFileName(PATH));
                Response.WriteFile(PATH);
                Response.End();
            }

        }


    }
}