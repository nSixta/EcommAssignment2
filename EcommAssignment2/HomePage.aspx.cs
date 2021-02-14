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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(source);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM client_table WHERE username = '" + username + "' AND password = '" + password + "'", connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    Response.Redirect("MainMenu.aspx");
                }
                else
                {
                    labelErrorMessage(usernameLabel, "Username or Password is Incorrect.");
                    labelErrorMessage(passwordLabel, "Username or Password is Incorrect.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert({ex.Message})", true);
            }
        }

        public void labelErrorMessage(Label label, string text)
        {
            label.ForeColor = Color.FromArgb(198, 33, 33);
            label.Text = text;
            label.Visible = true;
        }

        protected void forgotPassLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassPage.aspx");
        }
    }
}