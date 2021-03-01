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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            idString = Session["idString"].ToString();
        }

        protected void deleteProfileButton_Click(object sender, EventArgs e)
        {
            //string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            string source = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(source);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            SqlCommand deleteCartData = connection.CreateCommand();
            SqlCommand deleteOrdersData = connection.CreateCommand();
            SqlCommand deletePrevData = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            deleteCartData.CommandType = System.Data.CommandType.Text;
            deleteOrdersData.CommandType = System.Data.CommandType.Text;
            deletePrevData.CommandType = System.Data.CommandType.Text;

            command.CommandText = "DELETE FROM client_table WHERE client_id = " + idString;
            deleteCartData.CommandText = "DELETE FROM cart_table WHERE client_id = " + idString;
            deleteOrdersData.CommandText = "DELETE FROM order_table WHERE client_id = " + idString;
            deletePrevData.CommandText = "DELETE FROM cart_table WHERE client_id = " + idString;

            command.ExecuteNonQuery();
            deleteCartData.ExecuteNonQuery();
            deleteOrdersData.ExecuteNonQuery();
            deletePrevData.ExecuteNonQuery();

            connection.Close();
            Response.Redirect("LoginPage.aspx");
        }
    }
}