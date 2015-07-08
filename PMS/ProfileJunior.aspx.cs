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
    public partial class ProfileJunior : System.Web.UI.Page
    {
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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand cd;
                SqlDataAdapter da;
                DataTable dt;
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
                cd.Parameters.AddWithValue("@Empemail", Session["email"].ToString());
                dt = new DataTable();
                da = new SqlDataAdapter(cd);
                da.Fill(dt);

                //int eid = 0;
                //foreach (DataRow item in dt.Rows)
                //{
                //    eid = Convert.ToInt16(item[0]);
                //    EmpName.Text = item[1].ToString();
                //    Email.Text = item[2].ToString();
                //    Contact.Text = item[3].ToString();
                //    Gender.Text = item[4].ToString();
                //    Specialization.Text = item[5].ToString();
                //    Position.Text = item[6].ToString();
                //    pimg.ImageUrl = item[7].ToString();
                //    EmpCountry.Text = item[8].ToString();
                //    State.Text = item[9].ToString();
                //    City.Text = item[10].ToString();

                //}

                dt12.DataSource = dt;
                dt12.DataBind();
            }
        }

        protected void dt12_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dt12.ChangeMode(e.NewMode);
            SqlCommand cd;
            SqlDataAdapter da;
            DataTable dt;
            cd = new SqlCommand("getProfileDetails", con);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@Empemail", Session["email"].ToString());
            dt = new DataTable();
            da = new SqlDataAdapter(cd);
            da.Fill(dt);

            //int eid = 0;
            //foreach (DataRow item in dt.Rows)
            //{
            //    eid = Convert.ToInt16(item[0]);
            //    EmpName.Text = item[1].ToString();
            //    Email.Text = item[2].ToString();
            //    Contact.Text = item[3].ToString();
            //    Gender.Text = item[4].ToString();
            //    Specialization.Text = item[5].ToString();
            //    Position.Text = item[6].ToString();
            //    pimg.ImageUrl = item[7].ToString();
            //    EmpCountry.Text = item[8].ToString();
            //    State.Text = item[9].ToString();
            //    City.Text = item[10].ToString();

            //}

            dt12.DataSource = dt;
            dt12.DataBind();



        }

        protected void dt12_DataBound(object sender, EventArgs e)
        {
            if (dt12.CurrentMode == DetailsViewMode.Edit)
            {



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

               











                DropDownList DropDownList1 = (DropDownList)dt12.Rows[8].FindControl("DropDownList1");

                DropDownList DropDownList2 = (DropDownList)dt12.Rows[9].FindControl("DropDownList2");
                DropDownList DropDownList3 = (DropDownList)dt12.Rows[10].FindControl("DropDownList3");





                DropDownList1.DataSource = dtCountry;
                DropDownList1.DataTextField = "CountryName";
                DropDownList1.DataValueField = "CountryID";
                DropDownList1.DataBind();

                DropDownList3.DataSource = dtCity;
                DropDownList3.DataTextField = "CityName";
                DropDownList3.DataValueField = "CityID";
                DropDownList3.DataBind();

                DropDownList2.DataSource = dtState;
                DropDownList2.DataTextField = "StateName";
                DropDownList2.DataValueField = "StateID";
                DropDownList2.DataBind();







             
                //ListItem li1 = new ListItem();
                //li1.Text = "Please Select State";
                //li1.Value = 0.ToString();
                //DropDownList2.Items.Insert(0, li1);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt12.CurrentMode == DetailsViewMode.Edit)
            {

                DropDownList DropDownList1 = (DropDownList)dt12.Rows[8].FindControl("DropDownList1");

                 DropDownList DropDownList3 = (DropDownList)dt12.Rows[10].FindControl("DropDownList3");

                DropDownList DropDownList2 = (DropDownList)dt12.Rows[9].FindControl("DropDownList2");






                cd = new SqlCommand("getState", con);
                cd.Parameters.AddWithValue("@cid", Convert.ToInt16(DropDownList1.SelectedItem.Value));
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "StateName";
                DropDownList2.DataValueField = "StateID";
                DropDownList2.DataBind();


                cd = new SqlCommand("getCity", con);
                cd.Parameters.AddWithValue("@sid", Convert.ToInt16(DropDownList2.SelectedItem.Value));
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "CityName";
                DropDownList3.DataValueField = "CityID";
                DropDownList3.DataBind();
            }


           
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt12.CurrentMode == DetailsViewMode.Edit)
            {



                DropDownList DropDownList3 = (DropDownList)dt12.Rows[10].FindControl("DropDownList3");

                DropDownList DropDownList2 = (DropDownList)dt12.Rows[9].FindControl("DropDownList2");


                cd = new SqlCommand("getCity", con);
                cd.Parameters.AddWithValue("@sid", Convert.ToInt16(DropDownList2.SelectedItem.Value));
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "CityName";
                DropDownList3.DataValueField = "CityID";
                DropDownList3.DataBind();
            }



         


        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void dt12_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            FileUpload fu = (FileUpload)dt12.Rows[0].FindControl("FileUpload1");
            TextBox txtename = (TextBox)dt12.Rows[1].FindControl("txtename");
            TextBox txtemail = (TextBox)dt12.Rows[2].FindControl("txtemail");
            TextBox txtcon = (TextBox)dt12.Rows[3].FindControl("txtcontact");
            Label gender = (Label)dt12.Rows[4].FindControl("txtgender");
            Label txtspe = (Label)dt12.Rows[5].FindControl("txtspe");
            Label txtspe1 = (Label)dt12.Rows[6].FindControl("txtspe1");
            DropDownList t4 = (DropDownList)dt12.Rows[7].FindControl("DropDownList1");
            DropDownList t5 = (DropDownList)dt12.Rows[8].FindControl("DropDownList2");
            DropDownList t6 = (DropDownList)dt12.Rows[9].FindControl("DropDownList3");
            string imageurl = "";
            


            if (fu.HasFile)
            {

                imageurl = "~/assets/img" + fu.FileName;
                fu.SaveAs(Server.MapPath(imageurl));
                
                
            }
            else
            {
                cd = new SqlCommand("select image_url from employee where eemail=@email",con);
                cd.Parameters.AddWithValue("@email", Session["email"].ToString());
                da = new SqlDataAdapter(cd);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    imageurl = item[0].ToString();
                }
            }

           

            cd = new SqlCommand("updateemp",con);
            cd.Parameters.AddWithValue("@cemail", Session["email"].ToString());
            cd.Parameters.AddWithValue("@ename",txtename.Text);
            cd.Parameters.AddWithValue("@email", txtemail.Text);
            cd.Parameters.AddWithValue("@contact", txtcon.Text);
            cd.Parameters.AddWithValue("@country", t4.Text);
            cd.Parameters.AddWithValue("@state", t5.Text);
            cd.Parameters.AddWithValue("@city", t6.Text);
            cd.Parameters.AddWithValue("@imgurl", imageurl);
            cd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cd.ExecuteNonQuery();
            con.Close();

            cd = new SqlCommand("getProfileDetails", con);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@Empemail", Session["email"].ToString());
            dt = new DataTable();
            da = new SqlDataAdapter(cd);
            da.Fill(dt);
            dt12.DataSource = dt;
            dt12.DataBind();


            dt12.ChangeMode(DetailsViewMode.ReadOnly);

            cd = new SqlCommand("getProfileDetails", con);
            cd.CommandType = CommandType.StoredProcedure;
            cd.Parameters.AddWithValue("@Empemail", Session["email"].ToString());
            dt = new DataTable();
            da = new SqlDataAdapter(cd);
            da.Fill(dt);

            dt12.DataSource = dt;
            dt12.DataBind();

        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }



      
    }

  
}