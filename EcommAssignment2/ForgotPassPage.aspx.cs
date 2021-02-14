using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class ForgotPassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendEmailButton_Click(object sender, EventArgs e)
        {
            string email = forgotPassEmailInput.Text;
            string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(source);
            connection.Open();
            //Find row with email
            SqlCommand exists = new SqlCommand("SELECT * FROM client_table WHERE email = '" + email + "'", connection);
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(exists);
            sqlDataAdapter.Fill(dataSet);
            //See if account exists
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                string firstName = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                string lastName = dataSet.Tables[0].Rows[0]["last_name"].ToString();
                string password = dataSet.Tables[0].Rows[0]["password"].ToString();
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = "bulmafastfood@gmail.com",
                        Password = "yuehbakwnjmfonmh"
                    }
                };

                //Initialize Email Sending the message
                MailAddress fromEmail = new MailAddress("bulmafastfood@gmail.com", "Bulma Fast Food Development Team");

                //Initialze Email Receiving the massage 
                MailAddress toEmail = new MailAddress(email, firstName + " " + lastName);

                //Initialize Message being sent
                MailMessage message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = "Bulma Fast Food Account Created",
                    Body = "Your password is " + password,
                };

                //Attach message to Sender Email
                message.To.Add(toEmail);

                //Send Email
                try
                {
                    smtpClient.Send(message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CHECK YOUR EMAIL')", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert({ex.Message})", true);
                }
                connection.Close();
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no account associated with this email.')", true);
            }
        }

        protected void goBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}