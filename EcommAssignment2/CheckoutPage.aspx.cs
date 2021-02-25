using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        //string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
        string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
        string lastNameString = "";
        string firstNameString = "";
        string passwordString = "";
        string idString = "";
        string usernameString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usernameString"] == null && Session["idString"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            idString = Session["idString"].ToString();
            firstNameString = Session["firstNameString"].ToString();
            lastNameString = Session["lastNameString"].ToString();
            usernameString = Session["usernameString"].ToString();
            passwordString = Session["passwordString"].ToString();
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);
            nameCheckOutText.Text = firstNameString + " " + lastNameString;
            using (var connection = new SqlConnection(mycon))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM cart_table WHERE client_id = " + idString, connection))
                {
                    int rowsAmount = (int)command.ExecuteScalar(); // get the value of the count
                    checkOutCartNumber.Text = rowsAmount.ToString();
                }
            }
            loadCartItems();
            System.Diagnostics.Debug.WriteLine(shippingCostLabel.Text);
        }

        public void loadCartItems()
        {
            double subtotal = 0.00;
            double taxes = 0.00;
            double shippingCost = 10.00;
            double totalCost = 0.00;


            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from cart_table where client_id=" + idString);
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {

                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);

                HtmlGenericControl divLeft = new HtmlGenericControl("div");
                divLeft.Attributes.Add("class", "divLeft");

                HtmlGenericControl divName = new HtmlGenericControl("div");
                divName.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl lbl = new HtmlGenericControl("h4");
                lbl.InnerHtml = temp.Tables[0].Rows[0]["name"].ToString();
                divName.Controls.Add(lbl);

                itemCheckOutList.Controls.Add(divName);


                //quantity
                HtmlGenericControl divQuan = new HtmlGenericControl("div");
                divQuan.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl quan1 = new HtmlGenericControl("h4");
                quan1.InnerHtml = "Quantity: " + dataSet.Tables[0].Rows[c]["quantity"].ToString();
                divQuan.Controls.Add(quan1);
                itemCheckOutList.Controls.Add(divQuan);

                //totalPrice

                HtmlGenericControl divTotal = new HtmlGenericControl("div");
                divTotal.Attributes.Add("class", "oneOrderDiv");

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                HtmlGenericControl price1 = new HtmlGenericControl("h4");
                price1.InnerHtml = "Price:" + priceTemp.ToString() + "$";
                divTotal.Controls.Add(price1);
                subtotal += priceTemp;
                itemCheckOutList.Controls.Add(divTotal);

                HtmlGenericControl hr = new HtmlGenericControl("hr");
                itemCheckOutList.Controls.Add(hr);
                if (subtotal >= 25.00)
                {
                    shippingCost = 0.00;
                }
                taxes = subtotal * 0.15;
                totalCost = subtotal + taxes + shippingCost;
            }
            subtotalLabel.Text = "$" + Math.Round(subtotal, 2);
            taxesLabel.Text = "$" + Math.Round(taxes, 2);
            shippingCostLabel.Text = "$" + Math.Round(shippingCost, 2);
            checkOutPriceLabel.Text = "$" + Math.Round(totalCost, 2);
        }

        private SqlConnection createConnectionDB()
        {

            //string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            return con;
        }
        private void closeConnectionDB(SqlConnection con)
        {
            con.Close();
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

        protected void payCheckOutButton_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = dt1.AddHours(1);
            string fullName = nameCheckOutText.Text;
            string address = addressCheckOutText.Text;
            string city = cityCheckOutText.Text;
            string postalCode = postalCodeText.Text;
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from cart_table where client_id=" + idString);
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO order_table VALUES(@client_id, @menu_id, @quantity, @client_name, @delivery_date, @delivery_address, @postal_code)";
                cmd.Parameters.AddWithValue("client_id", idString);
                cmd.Parameters.AddWithValue("menu_id", dataSet.Tables[0].Rows[c]["menu_id"]);
                cmd.Parameters.AddWithValue("quantity", dataSet.Tables[0].Rows[c]["quantity"]);
                cmd.Parameters.AddWithValue("client_name", fullName);
                cmd.Parameters.AddWithValue("delivery_date", dt2);
                cmd.Parameters.AddWithValue("delivery_address", address + ", " + city);
                cmd.Parameters.AddWithValue("postal_code", postalCode);
                cmd.ExecuteNonQuery();
            }

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = $"DELETE FROM cart_table WHERE client_id = " + idString;
            cmd2.ExecuteNonQuery();
            closeConnectionDB(con);
            Response.Redirect("orders_cart.aspx", false);
        }
    }
}