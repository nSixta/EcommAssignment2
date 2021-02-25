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
    public partial class orders : System.Web.UI.Page
    {
        string idString = "";
        string usernameString = "";
        string addressString = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usernameString"] == null && Session["idString"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            idString = Session["idString"].ToString();
            usernameString = Session["usernameString"].ToString();
            addressString = Session["addressString"].ToString();
            loadCurrentOrders();
            loadPreviousOrders();
            loadDeliveringOrders();
        }

        private void loadDeliveringOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from delivery_table where client_id=" + idString);
            double totalPayment = 0;

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                deliveredButton.Enabled = false;
                deliveredButton.Visible = false;
            }
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                //createDiv
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "orders");

                //menu_name
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);
                Label lbl = new Label();
                lbl.Text = temp.Tables[0].Rows[0]["name"].ToString();
                div.Controls.Add(lbl);

                //delivery_date
                Label dd1 = new Label();
                dd1.Text = "Delivery Date:";
                div.Controls.Add(dd1);

                Label dd = new Label();
                dd.Text = dataSet.Tables[0].Rows[c]["delivery_date"].ToString();
                div.Controls.Add(dd);
                //store_Address
                Label str1 = new Label();
                str1.Text = "Store Address:";
                div.Controls.Add(str1);

                DataSet temp2 = fillDataSet(con, "select * from store_table where store_id=" + dataSet.Tables[0].Rows[c]["store_id"]);

                Label str = new Label();
                str.Text = temp2.Tables[0].Rows[0]["address"].ToString();
                div.Controls.Add(str);
                //quantity
                Label quan1 = new Label();
                quan1.Text = "Quantity:";
                div.Controls.Add(quan1);

                Label quan = new Label();
                quan.Text = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                div.Controls.Add(quan);

                //totalPrice
                Label price1 = new Label();
                price1.Text = "Total:";
                div.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                Label price = new Label();
                price.Text = "" + priceTemp;
                totalPayment += priceTemp;
                div.Controls.Add(price);

                //TODO put this in the being delivered
                /*//Btn
                Button btn = new Button();
                btn.Text = "Click if items are delivered";
                btn.Click += itemsDelivered;
                btn.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                div.Controls.Add(btn);*/

                deliveryOrders.Controls.Add(div);

            }
            closeConnectionDB(con);
        }

        private void loadPreviousOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from prev_orders_table where client_id=" + idString + "ORDER BY delivery_date DESC");
            double totalPayment = 0;

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                //createDiv
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "orders");

                //menu_name
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);
                Label lbl = new Label();
                lbl.Text = temp.Tables[0].Rows[0]["name"].ToString();
                div.Controls.Add(lbl);

                //delivery_date
                Label dd1 = new Label();
                dd1.Text = "Delivery Date:";
                div.Controls.Add(dd1);

                Label dd = new Label();
                dd.Text = dataSet.Tables[0].Rows[c]["delivery_date"].ToString();
                div.Controls.Add(dd);
                //store_Address
                Label str1 = new Label();
                str1.Text = "Store Address:";
                div.Controls.Add(str1);

                DataSet temp2 = fillDataSet(con, "select * from store_table where store_id=" + dataSet.Tables[0].Rows[c]["store_id"]);

                Label str = new Label();
                str.Text = temp2.Tables[0].Rows[0]["address"].ToString();
                div.Controls.Add(str);
                //quantity
                Label quan1 = new Label();
                quan1.Text = "Quantity:";
                div.Controls.Add(quan1);

                Label quan = new Label();
                quan.Text = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                div.Controls.Add(quan);

                //totalPrice
                Label price1 = new Label();
                price1.Text = "Total:";
                div.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                Label price = new Label();
                price.Text = "" + priceTemp;
                totalPayment += priceTemp;
                div.Controls.Add(price);

                //TODO put this in the being delivered
                /*//Btn
                Button btn = new Button();
                btn.Text = "Click if items are delivered";
                btn.Click += itemsDelivered;
                btn.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                div.Controls.Add(btn);*/

                previousOrders.Controls.Add(div);

            }
            closeConnectionDB(con);
            overAllTotal.Text = "" + totalPayment;
        }

        private void loadCurrentOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from curr_orders_table where client_id=" + idString);
            double totalPayment = 0;
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                Button1.Enabled = false;
                Button1.Visible = false;
                overAllTotal.Visible = false;
                Label1.Visible = false;
            }

            HtmlGenericControl br1 = new HtmlGenericControl("br");
            HtmlGenericControl br2 = new HtmlGenericControl("br");
            HtmlGenericControl br3 = new HtmlGenericControl("br");
            HtmlGenericControl br4 = new HtmlGenericControl("br");
            HtmlGenericControl br5 = new HtmlGenericControl("br");

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                //createDiv
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "orders");


                //menu_name
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);
                Label lbl = new Label();
                lbl.Text = temp.Tables[0].Rows[0]["name"].ToString();
                div.Controls.Add(lbl);

                div.Controls.Add(br1);

                /*Image image = new Image();
                image.ImageUrl = dataSet.Tables[0].Rows[c]["photo"].ToString();
                image.Width = 50;
                image.Height = 50;
                div.Controls.Add(image);*/

                //delivery_date
                Label dd1 = new Label();
                dd1.Text = "Delivery Date: " + dataSet.Tables[0].Rows[c]["delivery_date"].ToString();
                div.Controls.Add(dd1);

                div.Controls.Add(br2);

                //store_Address
                DataSet temp2 = fillDataSet(con, "select * from store_table where store_id=" + dataSet.Tables[0].Rows[c]["store_id"]);
                Label str1 = new Label();
                str1.Text = "Store Address: " + temp2.Tables[0].Rows[0]["address"].ToString();
                div.Controls.Add(str1);

                div.Controls.Add(br3);

                //quantity
                Label quan1 = new Label();
                quan1.Text = "Quantity: " + dataSet.Tables[0].Rows[c]["quantity"].ToString();
                div.Controls.Add(quan1);

                div.Controls.Add(br4);

                //totalPrice
                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                Label price1 = new Label();
                price1.Text = "Total: " + "$" + priceTemp;
                div.Controls.Add(price1);
                totalPayment += priceTemp;

                div.Controls.Add(br5);

                Button deleteButton = new Button();
                deleteButton.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                deleteButton.Text = "Delete";
                deleteButton.Click += deleteButton_Click;
                div.Controls.Add(deleteButton);

                //TODO put this in the being delivered
                /*//Btn
                Button btn = new Button();
                btn.Text = "Click if items are delivered";
                btn.Click += itemsDelivered;
                btn.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                div.Controls.Add(btn);*/

                currentOrders.Controls.Add(div);

            }
            closeConnectionDB(con);
            overAllTotal.Text = "" + totalPayment;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //TODO delete the correct row
            /*SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM curr_orders_table WHERE menu_id = " + (sender as Button).Attributes["idValue"].ToString() + " AND client_id = " + idString;
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);*/
        }

        private void itemsDelivered(object sender, EventArgs e)
        {
            //remove from curr orders
            //add to 
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

        private SqlConnection createConnectionDB()
        {

            string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            //string mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            return con;
        }
        private void closeConnectionDB(SqlConnection con)
        {
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //paying the totalPayment
            //add to delivery_table

            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from curr_orders_table where client_id=" + idString);
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into delivery_table values(@client_id, @menu_id, @delivery_date, @delivery_address, @store_id, @quantity)";
                cmd.Parameters.AddWithValue("client_id", idString);
                cmd.Parameters.AddWithValue("menu_id", dataSet.Tables[0].Rows[c]["menu_id"]);
                cmd.Parameters.AddWithValue("delivery_date", dataSet.Tables[0].Rows[c]["delivery_date"]);
                cmd.Parameters.AddWithValue("delivery_address", dataSet.Tables[0].Rows[c]["delivery_address"]);
                cmd.Parameters.AddWithValue("store_id", dataSet.Tables[0].Rows[c]["store_id"]);
                cmd.Parameters.AddWithValue("quantity", dataSet.Tables[0].Rows[c]["quantity"]);
                cmd.ExecuteNonQuery();
            }
            //remove from curr_orders_table
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = $"DELETE from curr_orders_table";
            cmd2.ExecuteNonQuery();
            closeConnectionDB(con);
            //reload screen
            Response.Redirect("orders.aspx", false);
        }

        protected void deliveredButton_Click(object sender, EventArgs e)
        {
            //transfer from delivery_table to previous table
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from delivery_table where client_id=" + idString);
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into prev_orders_table values(@client_id, @menu_id, @delivery_date, @delivery_address, @store_id, @quantity)";
                cmd.Parameters.AddWithValue("client_id", idString);
                cmd.Parameters.AddWithValue("menu_id", dataSet.Tables[0].Rows[c]["menu_id"]);
                cmd.Parameters.AddWithValue("delivery_date", dataSet.Tables[0].Rows[c]["delivery_date"]);
                cmd.Parameters.AddWithValue("delivery_address", dataSet.Tables[0].Rows[c]["delivery_address"]);
                cmd.Parameters.AddWithValue("store_id", dataSet.Tables[0].Rows[c]["store_id"]);
                cmd.Parameters.AddWithValue("quantity", dataSet.Tables[0].Rows[c]["quantity"]);
                cmd.ExecuteNonQuery();
            }
            //remove from delivery_table
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = $"DELETE from delivery_table";
            cmd2.ExecuteNonQuery();
            closeConnectionDB(con);
            //reload screen
            Response.Redirect("orders.aspx", false);
        }

        protected void clearPreivousTable_Click(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE from prev_orders_table WHERE client_id = " + idString;
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}