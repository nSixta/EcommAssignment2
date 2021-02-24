using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        //String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
        string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
        string idString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            idString = Session["idString"].ToString();
            using (var connection = new SqlConnection(mycon))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM curr_orders_table WHERE client_id = " + idString, connection))
                {
                    int rowsAmount = (int)command.ExecuteScalar(); // get the value of the count
                    cardCountLabel.Text = rowsAmount.ToString();
                }
            }
        }
    }
}