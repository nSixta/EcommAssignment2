using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class ProfilePage : System.Web.UI.Page
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
            profileFirstNameInput.Text = firstNameString;
            profileLastNameInput.Text = lastNameString;
            profileUsernameInput.Text = usernameString;
            profilePassInput.Text = passwordString;
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);
        }

        protected void changeProfileButton_Click(object sender, EventArgs e)
        {
            bool validDetails = true;
            string firstName = profileFirstNameInput.Text;
            string lastName = profileLastNameInput.Text;
            string username = profileUsernameInput.Text;
            string password = profilePassInput.Text;
            string confirmPass = profileConfirmPassInput.Text;

            if (!verifyFirstName(firstName))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(profileFirstNameLabel, "First Name is Valid");
            }

            if (!verifyLastName(lastName))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(profileLastNameLabel, "Last Name is Valid");
            }

            if (!verifyUsername(username))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(profileUsernameLabel, "Username is Valid");
            }

            if (!verifyPassword(password))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(profilePasswordLabel, "Password is Valid");
            }

            if (String.IsNullOrEmpty(confirmPass))
            {
                labelErrorMessage(profileConfirmPassLabel, "This Field Cannot Be Empty");
                validDetails = false;
            }
            else if (!password.Equals(confirmPass))
            {
                labelErrorMessage(profileConfirmPassLabel, "Does not match password");
                validDetails = false;
            }
            else
            {
                profileConfirmPassLabel.Visible = false;
            }
            if (validDetails)
            {
                //string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
                string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(source);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE client_table SET first_name ='" + firstNameString +
                                        "', last_name = '" + lastNameString +
                                        "', username = '" + usernameString +
                                        "', password = '" + passwordString +
                                        "' WHERE client_id = " + idString;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Check First Name Input
        public bool verifyFirstName(string name)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(name))
            {
                labelErrorMessage(profileFirstNameLabel, "First Name Cannot Be Empty");
                valid = false;
            }
            else if (!Char.IsUpper(name[0]))
            {
                labelErrorMessage(profileFirstNameLabel, "First Name Should Start With a Capital");
                valid = false;
            }
            else if (name.Any(char.IsDigit))
            {
                labelErrorMessage(profileFirstNameLabel, "First Name Should NOT Contain Numbers");
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
                labelErrorMessage(profileLastNameLabel, "Last Name Cannot Be Empty");
                valid = false;
            }
            else if (!Char.IsUpper(name[0]))
            {
                labelErrorMessage(profileLastNameLabel, "Last Name Should Start With a Capital");
                valid = false;
            }
            else if (name.Any(char.IsDigit))
            {
                labelErrorMessage(profileLastNameLabel, "Last Name Should NOT Contain Numbers");
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
                labelErrorMessage(profileUsernameLabel, "Username Cannot Be Empty");
                valid = false;
            }
            else if (username.Length < 5)
            {
                labelErrorMessage(profileUsernameLabel, "Username should be at least 5 characters long");
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
                labelErrorMessage(profilePasswordLabel, "Password Cannot Be Empty");
                valid = false;
            }
            else if (password.Length < 10)
            {
                labelErrorMessage(profilePasswordLabel, "Password should be at least 10 characters long");
                valid = false;
            }
            else if (!password.Any(char.IsDigit))
            {
                labelErrorMessage(profilePasswordLabel, "Password should contain at least 1 number");
                valid = false;
            }
            return valid;
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
    }
}