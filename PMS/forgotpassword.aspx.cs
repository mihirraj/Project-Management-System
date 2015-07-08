using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace PMS
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string emails = txtpass.Text;
            string pass = "";

            
            cd = new SqlCommand("select RegPassword from Registration where EmailID=@email",con);
            cd.Parameters.AddWithValue("@email",txtpass.Text);
            da = new SqlDataAdapter(cd);
            dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                pass = item[0].ToString();
            }

            MailMessage Msg = new MailMessage();
            // Sender e-ml ail address.
            Msg.From = new MailAddress("raj.mihir103@gmail.com");
            // Recipient e-mail address.
            Msg.To.Add(emails);
            Msg.Subject = "Your Password";
            string msgbody = "Dear User Your Password is <b>" + pass + "</b> please login with this password";
            Msg.Body = msgbody;
            Msg.IsBodyHtml = true;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("raj.mihir103@gmail.com", "mlk166269");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            Msg = null;

            pwdmsg.Visible = true;
            pwdmsg.Text = "Your Password is sent successfully on your email id";
        }
    }
}