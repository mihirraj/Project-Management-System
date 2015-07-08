using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;

namespace PMS
{
    public partial class Analysis : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cd1;
        SqlCommand cd2;
        SqlCommand cd;
        SqlDataAdapter da2;
        SqlDataAdapter da1;
        
        DataTable dt1;
        DataTable dt2;
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
              
                //da = new SqlDataAdapter("select * from Project_Master", con);

                //ds = new DataSet();

                //da.Fill(ds);

                ////Chart1.DataSource = ds;

                ////Chart1.DataBind();

                

                

                cd1 = new SqlCommand("getprojectnames", con);
                cd1.CommandType = CommandType.StoredProcedure;
               
                da1 = new SqlDataAdapter(cd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "pname";
                DropDownList1.DataValueField = "pid";
                DropDownList1.DataBind();

                DropDownList3.DataSource = dt1;
                DropDownList3.DataTextField = "pname";
                DropDownList3.DataValueField = "pid";
                DropDownList3.DataBind();
                DataTable custom1 = new DataTable();
                custom1.Columns.Add("projectname", typeof(System.String));
                custom1.Columns.Add("projectprg", typeof(System.Double));
               
                foreach (DataRow item in dt1.Rows)
                {
                    DataTable custom = new DataTable();
                    custom.Columns.Add("mid", typeof(System.Int16));
                    custom.Columns.Add("prg", typeof(System.Int16));

                    cd = new SqlCommand("select ModuleID  from ProjectModule where ProjectID=@pid",con);
                    cd.Parameters.AddWithValue("@pid", Convert.ToInt16(item[0]));
                    da = new SqlDataAdapter(cd);
                    DataTable mydt = new DataTable();
                    da.Fill(mydt);

                    foreach (DataRow item1 in mydt.Rows)
                    {
                        cd = new SqlCommand("getmoduleprogress",con);
                        cd.Parameters.AddWithValue("@mid",Convert.ToInt16(item1[0]));
                        cd.CommandType = CommandType.StoredProcedure;
                        da = new SqlDataAdapter(cd);
                        DataTable mydt1 = new DataTable();
                        da.Fill(mydt1);
                        DataRow dr = custom.NewRow();
                        dr[0] = item1[0].ToString();
                        foreach (DataRow item2 in mydt1.Rows)
                        {

                            dr[1] = Convert.ToInt16(item2[0]);
                           
                        }

                        custom.Rows.Add(dr);

                    }

                    double sum=0;

                    foreach (DataRow item3 in custom.Rows)
                    {
                        int newsum=Convert.ToInt16(item3[1]);
                        sum = sum + newsum;

                    }


                    DataRow dr1 = custom1.NewRow();
                    dr1[0] = item[1].ToString();
                    dr1[1] = (sum/custom.Rows.Count);
                    custom1.Rows.Add(dr1);
                
                }


                Chart3.DataSource = custom1;
                Chart3.DataBind();



                ListItem li = new ListItem();
                li.Text = "Select Project";
                li.Value = 0.ToString();
                DropDownList1.Items.Insert(0, li);



                ListItem li1 = new ListItem();
                li1.Text = "Select Modul";
                li1.Value = 0.ToString();
                DropDownList2.Items.Insert(0, li1);


                ListItem li2 = new ListItem();
                li2.Text = "Select Project";
                li2.Value = 0.ToString();
                DropDownList3.Items.Insert(0, li2);

            }
            
        }

        public void bindchart()
        {
            cd1 = new SqlCommand("getprojectnames", con);
            cd1.CommandType = CommandType.StoredProcedure;

            da1 = new SqlDataAdapter(cd1);
            dt1 = new DataTable();
            da1.Fill(dt1);

            DataTable custom1 = new DataTable();
            custom1.Columns.Add("projectname", typeof(System.String));
            custom1.Columns.Add("projectprg", typeof(System.Double));

            foreach (DataRow item in dt1.Rows)
            {
                DataTable custom = new DataTable();
                custom.Columns.Add("mid", typeof(System.Int16));
                custom.Columns.Add("prg", typeof(System.Int16));

                cd = new SqlCommand("select ModuleID  from ProjectModule where ProjectID=@pid", con);
                cd.Parameters.AddWithValue("@pid", Convert.ToInt16(item[0]));
                da = new SqlDataAdapter(cd);
                DataTable mydt = new DataTable();
                da.Fill(mydt);

                foreach (DataRow item1 in mydt.Rows)
                {
                    cd = new SqlCommand("getmoduleprogress", con);
                    cd.Parameters.AddWithValue("@mid", Convert.ToInt16(item1[0]));
                    cd.CommandType = CommandType.StoredProcedure;
                    da = new SqlDataAdapter(cd);
                    DataTable mydt1 = new DataTable();
                    da.Fill(mydt1);
                    DataRow dr = custom.NewRow();
                    dr[0] = item1[0].ToString();
                    foreach (DataRow item2 in mydt1.Rows)
                    {

                        dr[1] = Convert.ToInt16(item2[0]);

                    }

                    custom.Rows.Add(dr);

                }

                double sum = 0;

                foreach (DataRow item3 in custom.Rows)
                {
                    int newsum = Convert.ToInt16(item3[1]);
                    sum = sum + newsum;

                }


                DataRow dr1 = custom1.NewRow();
                dr1[0] = item[1].ToString();
                dr1[1] = (sum / custom.Rows.Count);
                custom1.Rows.Add(dr1);

            }

            Chart3.DataSource = custom1;
            Chart3.DataBind();

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cd3;
            SqlDataAdapter da3;
            DataTable dt3;
            cd3 = new SqlCommand("getModuleFromProject", con);
            cd3.CommandType = CommandType.StoredProcedure;
            cd3.Parameters.AddWithValue("@ProjectID", DropDownList1.SelectedItem.Value);

            da3 = new SqlDataAdapter(cd3);
            dt3 = new DataTable();
            da3.Fill(dt3);

            DropDownList2.DataSource = dt3;
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
            bindchart();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd = new SqlCommand("counttask", con);
            cd.Parameters.AddWithValue("@mid", DropDownList2.SelectedItem.Value);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            Chart1.DataSource = dt;
            Chart1.DataBind();


            bindchart();
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
                li.Text = "Select Project";
                li.Value = 0.ToString();
                DropDownList3.Items.Insert(0, li);
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd2 = new SqlCommand("getModuleFromProject", con);
            cd2.CommandType = CommandType.StoredProcedure;
            cd2.Parameters.AddWithValue("@ProjectID", DropDownList3.SelectedItem.Value);
            da2 = new SqlDataAdapter(cd2);
            dt2 = new DataTable();
            da2.Fill(dt2);

            DataTable mydt = new DataTable();
            mydt.Columns.Add("modulname",typeof(System.String));
            mydt.Columns.Add("prg", typeof(System.Int16));



            foreach (DataRow item in dt2.Rows)
            {
                DataRow dr = mydt.NewRow();
                dr[0] = item[0].ToString();
                cd = new SqlCommand("getmoduleprogress", con);
                cd.Parameters.AddWithValue("@mid",Convert.ToInt16(item[1]));
                cd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cd);
                DataTable newdt = new DataTable();
                da.Fill(newdt);
                foreach (DataRow item1 in newdt.Rows)
                {
                    dr[1] =Convert.ToInt16(item1[0]);
                }
                mydt.Rows.Add(dr);


                Chart2.DataSource = mydt;
                Chart2.DataBind();
            }



            bindchart();
            cd = new SqlCommand("counttask", con);
            cd.Parameters.AddWithValue("@mid", DropDownList2.SelectedItem.Value);
            cd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);
            Chart1.DataSource = dt;
            Chart1.DataBind();
        }

         
   
    }


}