using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            loadComments();
        }

        public void loadComments()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from comments_table");
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "commment");

                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerHtml = dataSet.Tables[0].Rows[c]["name"].ToString() + " - " + dataSet.Tables[0].Rows[c]["date_sent"].ToString() + "<br>" + 
                              dataSet.Tables[0].Rows[c]["message"].ToString();
                div.Controls.Add(p);

                HtmlGenericControl hr = new HtmlGenericControl("hr");
                div.Controls.Add(hr);

                messageSection.Controls.Add(div);
            }
            con.Close();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string message = messageInput.Text;
            //string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(source);
            connection.Open();
            SqlCommand insert = new SqlCommand("INSERT INTO comments_table VALUES (@name, @date_sent, @message)", connection);
            insert.Parameters.AddWithValue("name", usernameString);
            insert.Parameters.AddWithValue("date_sent", DateTime.Now.ToString("MM/dd/yyyy"));
            insert.Parameters.AddWithValue("message", message);
            insert.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("ContactPage.aspx", false);
        }
        private SqlConnection createConnectionDB()
        {

            //string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            return con;
        }

        private DataSet fillDataSet(SqlConnection con, string command)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = command;
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            return dataSet;
        }
    }
}