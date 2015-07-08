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
    public partial class MyProfile : System.Web.UI.Page
    {
        

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;
            if(!IsPostBack)

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
                
                cd = new SqlCommand("getProfileDetails", con);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Empemail", Session["spid"].ToString());
                dt = new DataTable();
                da = new SqlDataAdapter(cd);
                da.Fill(dt);

                int eid = 0;
                foreach (DataRow item in dt.Rows)
                {
                    eid = Convert.ToInt16(item[0]);
                    EmpName.Text = item[1].ToString();
                    Email.Text = item[2].ToString();
                    Contact.Text = item[3].ToString();
                    Gender.Text = item[4].ToString();
                    Specialization.Text = item[5].ToString();
                    Position.Text = item[6].ToString();
                    pimg.ImageUrl = item[7].ToString();
                    EmpCountry.Text = item[8].ToString();
                    State.Text = item[9].ToString();
                    City.Text = item[10].ToString();

                }


            }
        }
    }
}