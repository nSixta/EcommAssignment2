using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class ContactPage : System.Web.UI.Page
    {
        string idString = "";
        string firstNameString = "";
        string lastNameString = "";
        string usernameString = "";
        string passwordString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            idString = Session["idString"].ToString();
            firstNameString = Session["firstNameString"].ToString();
            lastNameString = Session["lastNameString"].ToString();
            usernameString = Session["usernameString"].ToString();
            passwordString = Session["passwordString"].ToString();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameContactInput.Text;
            string lastName = lastNameContactInput.Text;
            string email = emailContactInput.Text;
            string subject = subjectInput.Text;
            string message = messageInput.Text;

            /*//Create SMTP client
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            //Initialize Email Sending the message
            MailAddress fromEmail = new MailAddress(email, firstName + " " + lastName);

            //Initialze Email Receiving the massage 
            MailAddress toEmail = new MailAddress("bulmafastfood@gmail.com");

            //Initialize Message being sent
            MailMessage emailMessage = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = message
            };

            //Attach message to Sender Email
            emailMessage.To.Add(toEmail);

            //Send Email
            try
            {
                smtpClient.Send(emailMessage);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Message was sent.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert({ex.Message})", true);
            }*/
        }
    }
}