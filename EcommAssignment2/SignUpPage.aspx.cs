using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class SignInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void confirmSignUpButton_Click(object sender, EventArgs e)
        {
            bool validDetails = true;
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string email = emailInput.Text;
            string username = usernameInput.Text;
            string password = passwordInput.Text;
            string confirmPass = confirmPasswordInput.Text;

            if (!verifyFirstName(firstName))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(firstNameLabel, "First Name is Valid");
            }

            if (!verifyLastName(lastName))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(lastNameLabel, "Last Name is Valid");
            }

            if (!verifyEmail(email))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(emailLabel, "Email is Valid");
            }

            if (!verifyUsername(username))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(usernameLabel, "Username is Valid");
            }

            if (!verifyPassword(password))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(passwordLabel, "Password is Valid");
            }

            if (String.IsNullOrEmpty(confirmPass))
            {
                labelErrorMessage(confirmPassLabel, "This Field Cannot Be Empty");
                validDetails = false;
            }
            else if (!password.Equals(confirmPass))
            {
                labelErrorMessage(confirmPassLabel, "Does not match password");
                validDetails = false;
            }
            else
            {
                confirmPassLabel.Visible = false;
            }

            if (validDetails)
            {
                string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(source);
                connection.Open();
                //Find row with email
                SqlCommand exists = new SqlCommand("SELECT * FROM client_table WHERE email = '" + email + "'", connection);
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(exists);
                sqlDataAdapter.Fill(dataSet);
                //See if an account already has the email entered
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email already linked to another account.')", true);
                }
                else
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO client_table VALUES (@first_name, @last_name, @email, @username, @password)", connection);
                    insert.Parameters.AddWithValue("first_name", firstName);
                    insert.Parameters.AddWithValue("last_name", lastName);
                    insert.Parameters.AddWithValue("email", email);
                    insert.Parameters.AddWithValue("username", username);
                    insert.Parameters.AddWithValue("password", password);
                    insert.ExecuteNonQuery();

                    //Create SMTP client
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
                        Body = "Hey There! Thank you for joining the Bulma Fast Food Family! Your username is " + username + " and your password is " + password,
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
                }
                connection.Close();

                firstNameInput.Text = "";
                lastNameInput.Text = "";
                emailInput.Text = "";
                usernameInput.Text = "";
                passwordInput.Text = "";
                confirmPasswordInput.Text = "";
                clearLabels();
            }
        }

        //Check First Name Input
        public bool verifyFirstName(string name)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(name))
            {
                labelErrorMessage(firstNameLabel, "First Name Cannot Be Empty");
                valid = false;
            }
            else if (!Char.IsUpper(name[0]))
            {
                labelErrorMessage(firstNameLabel, "First Name Should Start With a Capital");
                valid = false;
            }
            else if (name.Any(char.IsDigit))
            {
                labelErrorMessage(firstNameLabel, "First Name Should NOT Contain Numbers");
                valid = false;
            }
            return valid;
        }

        //Check Last Name Input
        public bool verifyLastName(string name)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(name))
            {
                labelErrorMessage(lastNameLabel, "Last Name Cannot Be Empty");
                valid = false;
            }
            else if (!Char.IsUpper(name[0]))
            {
                labelErrorMessage(lastNameLabel, "Last Name Should Start With a Capital");
                valid = false;
            }
            else if (name.Any(char.IsDigit))
            {
                labelErrorMessage(lastNameLabel, "Last Name Should NOT Contain Numbers");
                valid = false;
            }
            return valid;
        }

        //Check Email Input
        public bool verifyEmail(string email)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(email))
            {
                labelErrorMessage(emailLabel, "Email Cannot Be Empty");
                valid = false;
            }
            return valid;
        }

        //Check Username Input
        public bool verifyUsername(string username)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(username))
            {
                labelErrorMessage(usernameLabel, "Username Cannot Be Empty");
                valid = false;
            }
            else if (username.Length < 5)
            {
                labelErrorMessage(usernameLabel, "Username should be at least 5 characters long");
                valid = false;
            }
            return valid;
        }

        //Check Password Input
        public bool verifyPassword(string password)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(password))
            {
                labelErrorMessage(passwordLabel, "Password Cannot Be Empty");
                valid = false;
            }
            else if (password.Length < 10)
            {
                labelErrorMessage(passwordLabel, "Password should be at least 10 characters long");
                valid = false;
            }
            else if (!password.Any(char.IsDigit))
            {
                labelErrorMessage(passwordLabel, "Password should contain at least 1 number");
                valid = false;
            }
            return valid;
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        public void labelErrorMessage(Label label, string text)
        {
            label.ForeColor = Color.FromArgb(198, 33, 33);
            label.Text = text;
            label.Visible = true;
        }

        public void labelSuccessMessage(Label label, string text)
        {
            label.ForeColor = Color.FromArgb(33, 198, 33);
            label.Text = text;
            label.Visible = true;
        }

        public void clearLabels()
        {
            firstNameLabel.Text = "";
            lastNameLabel.Text = "";
            emailLabel.Text = "";
            usernameLabel.Text = "";
            passwordLabel.Text = "";
            confirmPassLabel.Text = "";
            firstNameLabel.Visible = false;
            lastNameLabel.Visible = false;
            emailLabel.Visible = false;
            usernameLabel.Visible = false;
            passwordLabel.Visible = false;
            confirmPassLabel.Visible = false;
        }
    }
}