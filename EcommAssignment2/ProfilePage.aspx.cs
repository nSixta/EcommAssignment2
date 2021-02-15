using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Label5.Visible = true;
            profilePassInput.Visible = true;
            Label6.Visible = true;
            profileConfirmPassInput.Visible = true;
        }

        protected void changeProfileButton_Click(object sender, EventArgs e)
        {
            bool validDetails = true;
            string firstName = profileFirstNameInput.Text;
            string lastName = profileFirstNameInput.Text;
            string email = profileFirstNameInput.Text;
            string username = profileFirstNameInput.Text;
            string password = profileFirstNameInput.Text;
            string confirmPass = profileFirstNameInput.Text;

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

            if (!verifyEmail(email))
            {
                validDetails = false;
            }
            else
            {
                labelSuccessMessage(profileEmailLabel, "Email is Valid");
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

        //Check Email Input
        public bool verifyEmail(string email)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(email))
            {
                labelErrorMessage(profileEmailLabel, "Email Cannot Be Empty");
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