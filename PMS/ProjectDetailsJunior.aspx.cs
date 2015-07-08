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
    public partial class ProjectDetailsJunior : System.Web.UI.Page
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
                cd = new SqlCommand("select * from Project_Master where pname=@pname", con);
                cd.Parameters.AddWithValue("@pname",Session["spid"].ToString());
                dt = new DataTable();
                da = new SqlDataAdapter(cd);
                da.Fill(dt);

                int pid = 0;
                foreach (DataRow item in dt.Rows)
                {
                    pid = Convert.ToInt16(item[0]);
                    ProjectName.Text = item[1].ToString();
                    pstdate.Text = item[2].ToString();
                    penddate.Text = item[3].ToString();
                    pbudget.Text = item[4].ToString();
                    des.Text = item[5].ToString();
                    proteam.Text = item[6].ToString();
                    pimg.ImageUrl = item[7].ToString();
                }




                cd = new SqlCommand("mysp1", con);
                cd.Parameters.AddWithValue("@pid", pid);
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                gd1.DataSource = dt;
                gd1.DataBind();
            }
        }
    }
}