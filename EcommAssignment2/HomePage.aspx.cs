using System;
using System.Collections.Generic;
using System.Data;
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
            string idString = "";
            string firstNameString = "";
            string lastNameString = "";
            string usernameString = "";
            string passwordString = "";
            string addressString = "";
            try
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(source);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM client_table WHERE username = '" + username + "' AND password = '" + password + "'", connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    connection.Close();
                    connection.Open();
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        idString = dataSet.Tables[0].Rows[0]["client_id"].ToString();
                        firstNameString = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                        lastNameString = dataSet.Tables[0].Rows[0]["last_name"].ToString();
                        usernameString = dataSet.Tables[0].Rows[0]["username"].ToString();
                        passwordString = dataSet.Tables[0].Rows[0]["password"].ToString();
                        addressString = dataSet.Tables[0].Rows[0]["address"].ToString();
                    }
                    /*Session["idString"] = idString;
                    Session["firstNameString"] = firstNameString;
                    Session["lastNameString"] = lastNameString;
                    Session["passwordString"] = passwordString;*/

                    Session["usernameString"] = usernameString;
                    Session["addressString"] = addressString;
                    Session["idString"] = idString;

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