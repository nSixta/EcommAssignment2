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
    public partial class orders_cart : System.Web.UI.Page
    {
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
            lastNameString = Session["lastNameString"].ToString();
            usernameString = Session["usernameString"].ToString();
            passwordString = Session["passwordString"].ToString();
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);
            if (Session["currentTab"] == null || Session["currentTab"].ToString().Equals("current"))
            {
                currentOrders.Style.Add("display", "block");
                deliveringOrders.Style.Add("display", "none");
                previousOrders.Style.Add("display", "none");
                removeButtonClass();
                ButtonCurr.Attributes.Add("class", "btn btn-dark");
                ButtonDel.Attributes.Add("class", "btn btn-outline-secondary");
                ButtonPrev.Attributes.Add("class", "btn btn-outline-secondary");
            }
            else if (Session["currentTab"].ToString().Equals("delivery"))
            {
                currentOrders.Style.Add("display", "none");
                deliveringOrders.Style.Add("display", "block");
                previousOrders.Style.Add("display", "none");
                removeButtonClass();
                ButtonCurr.Attributes.Add("class", "btn btn-outline-secondary");
                ButtonDel.Attributes.Add("class", "btn btn-dark");
                ButtonPrev.Attributes.Add("class", "btn btn-outline-secondary");
            }
            else
            {
                currentOrders.Style.Add("display", "none");
                deliveringOrders.Style.Add("display", "none");
                previousOrders.Style.Add("display", "block");
                removeButtonClass();
                ButtonCurr.Attributes.Add("class", "btn btn-outline-secondary");
                ButtonDel.Attributes.Add("class", "btn btn-outline-secondary");
                ButtonPrev.Attributes.Add("class", "btn btn-dark");
            }
            loadCurrentOrders();
            loadDeliveringOrders();
            loadPreviousOrders();
        }
        private void loadCurrentOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from cart_table where client_id=" + idString);
            double totalPayment = 0;

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);
                //version4*******
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "anOrder");
                //twoDivs for label and value


                HtmlGenericControl divLeft = new HtmlGenericControl("div");
                divLeft.Attributes.Add("class", "divLeft");

                HtmlGenericControl divName = new HtmlGenericControl("div");
                divName.Attributes.Add("class", "oneOrderDiv");

                //image
                Image img = new Image();
                img.ImageUrl = temp.Tables[0].Rows[0]["photo"].ToString();
                img.Height = 50;
                img.Width = 50;
                divName.Controls.Add(img);

                HtmlGenericControl lbl = new HtmlGenericControl("h4");
                lbl.InnerHtml = temp.Tables[0].Rows[0]["name"].ToString();
                divName.Controls.Add(lbl);

                divLeft.Controls.Add(divName);


                //quantity

                HtmlGenericControl divQuan = new HtmlGenericControl("div");
                divQuan.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl quan1 = new HtmlGenericControl("h6");
                quan1.InnerHtml = "Quantity: ";
                divQuan.Controls.Add(quan1);

                HtmlGenericControl quan = new HtmlGenericControl("p");
                quan.InnerHtml = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                divQuan.Controls.Add(quan);
                divLeft.Controls.Add(divQuan);

                //totalPrice

                HtmlGenericControl divTotal = new HtmlGenericControl("div");
                divTotal.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl price1 = new HtmlGenericControl("h6");
                price1.InnerHtml = "Price:";
                divTotal.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                HtmlGenericControl price = new HtmlGenericControl("p");
                price.InnerHtml = "$" + priceTemp.ToString();
                totalPayment += priceTemp;
                divTotal.Controls.Add(price);
                divLeft.Controls.Add(divTotal);


                Button deleteItem = new Button();
                deleteItem.Text = "Remove Item";
                deleteItem.Attributes.Add("class", "btn btn-danger");
                deleteItem.Attributes.Add("itemId", dataSet.Tables[0].Rows[c]["cart_id"].ToString());
                deleteItem.Click += removeItem;
                divLeft.Controls.Add(deleteItem);

                currentOrders.Controls.Add(divLeft);

            }
            closeConnectionDB(con);

            HtmlGenericControl totalPriceDiv = new HtmlGenericControl("div");
            HtmlGenericControl totalPrice = new HtmlGenericControl("h3");
            totalPrice.InnerHtml = "$" + totalPayment;
            totalPriceDiv.Attributes.Add("class", "totalPayment");
            totalPriceDiv.Controls.Add(totalPrice);
            currentOrders.Controls.Add(totalPriceDiv);

            Button payItems = new Button();
            payItems.Text = "Proceed to Checkout";
            payItems.Attributes.Add("class", "btn btn-success");
            payItems.Click += payAllItems;
            currentOrders.Controls.Add(payItems);
        }

        private void loadPreviousOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from prev_orders_table where client_id=" + idString);
            double totalPayment = 0;

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {

                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "anOrder");

                HtmlGenericControl divLeft = new HtmlGenericControl("div");
                divLeft.Attributes.Add("class", "divLeft");

                HtmlGenericControl divName = new HtmlGenericControl("div");
                divName.Attributes.Add("class", "oneOrderDiv");

                //image
                Image img = new Image();
                img.ImageUrl = temp.Tables[0].Rows[0]["photo"].ToString();
                img.Height = 50;
                img.Width = 50;
                divName.Controls.Add(img);

                HtmlGenericControl lbl = new HtmlGenericControl("h4");
                lbl.InnerHtml = temp.Tables[0].Rows[0]["name"].ToString();
                divName.Controls.Add(lbl);

                divLeft.Controls.Add(divName);

                //quantity
                HtmlGenericControl divQuan = new HtmlGenericControl("div");
                divQuan.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl quan1 = new HtmlGenericControl("h6");
                quan1.InnerHtml = "Quantity: ";
                divQuan.Controls.Add(quan1);

                HtmlGenericControl quan = new HtmlGenericControl("p");
                quan.InnerHtml = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                divQuan.Controls.Add(quan);
                divLeft.Controls.Add(divQuan);

                //totalPrice
                HtmlGenericControl divTotal = new HtmlGenericControl("div");
                divTotal.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl price1 = new HtmlGenericControl("h6");
                price1.InnerHtml = "Price:";
                divTotal.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                HtmlGenericControl price = new HtmlGenericControl("p");
                price.InnerHtml = "$" + priceTemp.ToString();
                totalPayment += priceTemp;
                divTotal.Controls.Add(price);
                divLeft.Controls.Add(divTotal);

                previousOrders.Controls.Add(divLeft);

            }
            closeConnectionDB(con);

            HtmlGenericControl totalPriceDiv = new HtmlGenericControl("div");
            HtmlGenericControl totalPrice = new HtmlGenericControl("h3");
            totalPrice.InnerHtml = "$" + totalPayment;
            totalPriceDiv.Attributes.Add("class", "totalPayment");
            totalPriceDiv.Controls.Add(totalPrice);
            previousOrders.Controls.Add(totalPriceDiv);

            Button deleteAllPrev = new Button();
            deleteAllPrev.Text = "Delete All Previous Orders";
            deleteAllPrev.Attributes.Add("class", "btn btn-success");
            deleteAllPrev.Click += deleteAllPreviousItems;
            previousOrders.Controls.Add(deleteAllPrev);
        }

        private void deleteAllPreviousItems(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE from prev_orders_table WHERE client_id = " + idString;
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            Session["currentTab"] = "previous";
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }

        private void loadDeliveringOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from order_table where client_id=" + idString);
            double totalPayment = 0;

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {

                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "anOrder");

                HtmlGenericControl divLeft = new HtmlGenericControl("div");
                divLeft.Attributes.Add("class", "divLeft");

                HtmlGenericControl divName = new HtmlGenericControl("div");
                divName.Attributes.Add("class", "oneOrderDiv");

                //image
                Image img = new Image();
                img.ImageUrl = temp.Tables[0].Rows[0]["photo"].ToString();
                img.Height = 50;
                img.Width = 50;
                divName.Controls.Add(img);

                HtmlGenericControl lbl = new HtmlGenericControl("h4");
                lbl.InnerHtml = temp.Tables[0].Rows[0]["name"].ToString();
                divName.Controls.Add(lbl);

                divLeft.Controls.Add(divName);


                //quantity

                HtmlGenericControl divQuan = new HtmlGenericControl("div");
                divQuan.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl quan1 = new HtmlGenericControl("h6");
                quan1.InnerHtml = "Quantity: ";
                divQuan.Controls.Add(quan1);

                HtmlGenericControl quan = new HtmlGenericControl("p");
                quan.InnerHtml = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                divQuan.Controls.Add(quan);
                divLeft.Controls.Add(divQuan);

                //totalPrice

                HtmlGenericControl divTotal = new HtmlGenericControl("div");
                divTotal.Attributes.Add("class", "oneOrderDiv");

                HtmlGenericControl price1 = new HtmlGenericControl("h6");
                price1.InnerHtml = "Price:";
                divTotal.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                HtmlGenericControl price = new HtmlGenericControl("p");
                price.InnerHtml = "$" + priceTemp.ToString();
                totalPayment += priceTemp;
                divTotal.Controls.Add(price);
                divLeft.Controls.Add(divTotal);

                Button deleteItem = new Button();
                deleteItem.Text = "Confirm If Delivered";
                deleteItem.Attributes.Add("class", "btn btn-success");
                deleteItem.Attributes.Add("itemId", dataSet.Tables[0].Rows[c]["order_id"].ToString());
                deleteItem.Click += deliveredItem;
                divLeft.Controls.Add(deleteItem);

                deliveringOrders.Controls.Add(divLeft);

            }
            closeConnectionDB(con);

            HtmlGenericControl totalPriceDiv = new HtmlGenericControl("div");
            HtmlGenericControl totalPrice = new HtmlGenericControl("h3");
            totalPrice.InnerHtml = "$" + totalPayment;
            totalPriceDiv.Attributes.Add("class", "totalPayment");
            totalPriceDiv.Controls.Add(totalPrice);
            deliveringOrders.Controls.Add(totalPriceDiv);
        }

        private void deliveredItem(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from order_table where order_id=" + (sender as Button).Attributes["itemId"]);
            //insert to previous_table
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"INSERT INTO prev_orders_table VALUES(@client_id, @menu_id, @quantity, @client_name, @delivery_date, @delivery_address, @postal_code)";
            cmd.Parameters.AddWithValue("client_id", idString);
            cmd.Parameters.AddWithValue("menu_id", dataSet.Tables[0].Rows[0]["menu_id"]);
            cmd.Parameters.AddWithValue("quantity", dataSet.Tables[0].Rows[0]["quantity"]);
            cmd.Parameters.AddWithValue("client_name", dataSet.Tables[0].Rows[0]["client_name"]);
            cmd.Parameters.AddWithValue("delivery_date", dataSet.Tables[0].Rows[0]["delivery_date"]);
            cmd.Parameters.AddWithValue("delivery_address", dataSet.Tables[0].Rows[0]["delivery_address"]);
            cmd.Parameters.AddWithValue("postal_code", dataSet.Tables[0].Rows[0]["postal_code"]);
            cmd.ExecuteNonQuery();

            //delete from delivery_table
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = $"DELETE FROM order_table WHERE order_id = " + (sender as Button).Attributes["itemId"];
            cmd2.ExecuteNonQuery();
            closeConnectionDB(con);
            Session["currentTab"] = "delivery";

            Response.Redirect("orders_cart.aspx", false);
        }

        private void payAllItems(object sender, EventArgs e)
        {
            Response.Redirect("CheckoutPage.aspx");
        }

        private void removeItem(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM cart_table WHERE cart_id = " + (sender as Button).Attributes["itemId"];
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            Session["currentTab"] = "current";
            Response.Redirect("orders_cart.aspx", false);
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

        protected void ButtonCurr_Click(object sender, EventArgs e)
        {
            currentOrders.Style.Add("display", "block");
            deliveringOrders.Style.Add("display", "none");
            previousOrders.Style.Add("display", "none");
            removeButtonClass();
            ButtonCurr.Attributes.Add("class", "btn btn-dark");
            ButtonDel.Attributes.Add("class", "btn btn-outline-secondary");
            ButtonPrev.Attributes.Add("class", "btn btn-outline-secondary");
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            currentOrders.Style.Add("display", "none");
            deliveringOrders.Style.Add("display", "block");
            previousOrders.Style.Add("display", "none");
            removeButtonClass();
            ButtonCurr.Attributes.Add("class", "btn btn-outline-secondary");
            ButtonDel.Attributes.Add("class", "btn btn-dark");
            ButtonPrev.Attributes.Add("class", "btn btn-outline-secondary");
        }

        protected void ButtonPrev_Click(object sender, EventArgs e)
        {
            currentOrders.Style.Add("display", "none");
            deliveringOrders.Style.Add("display", "none");
            previousOrders.Style.Add("display", "block");
            removeButtonClass();
            ButtonCurr.Attributes.Add("class", "btn btn-outline-secondary");
            ButtonDel.Attributes.Add("class", "btn btn-outline-secondary");
            ButtonPrev.Attributes.Add("class", "btn btn-dark");
        }

        private void removeButtonClass()
        {
            ButtonCurr.Attributes.Remove("class");
            ButtonDel.Attributes.Remove("class");
            ButtonPrev.Attributes.Remove("class");
        }
    }
}