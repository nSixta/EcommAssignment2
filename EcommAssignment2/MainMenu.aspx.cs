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
    public partial class MainMenu : System.Web.UI.Page
    {

        string lastNameString = "";
        string firstNameString = "";
        string passwordString = "";
        string idString = "";
        string usernameString = "";
        string addressString = "";
        TextBox[] temp;
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
            addressString = Session["addressString"].ToString();
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);

            
            /*idString = Session["idString"].ToString();
            usernameString = Session["usernameString"].ToString();*/
            loadCards();
            loadCurrentOrders();
        }

        private void loadCards()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from menu_table");
            temp = new TextBox[dataSet.Tables[0].Rows.Count];
            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                //createDiv
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "menuCard");
                //create Elemets inside Div

                //createImage
                Image img = new Image();
                img.ImageUrl = dataSet.Tables[0].Rows[c]["photo"].ToString();
                img.Attributes.Add("class", "photo");
                div.Controls.Add(img);

                //create H3 and label
                //createNameLabel
                HtmlGenericControl h4 = new HtmlGenericControl("h4");
                Label lbl = new Label();
                lbl.Text = dataSet.Tables[0].Rows[c]["name"].ToString();
                h4.Controls.Add(lbl);
                div.Controls.Add(h4);

                //create price
                Label price = new Label();
                price.Text = dataSet.Tables[0].Rows[c]["price"].ToString();
                div.Controls.Add(price);

                //create InputBox
                TextBox tb = new TextBox();
                tb.TextMode = TextBoxMode.Number;
                tb.Text = "1";
                tb.Attributes.Add("ID", "quan" + dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                tb.Attributes.Add("runat", "server");
                temp[c] = tb;
                div.Controls.Add(tb);

                HtmlGenericControl br = new HtmlGenericControl("br");
                div.Controls.Add(br);

                Label nutritionalDetails = new Label();
                nutritionalDetails.Text = "Carbs: " + dataSet.Tables[0].Rows[c]["carbs"].ToString() + "g" + "<br/>" +
                                           "Calories: " + dataSet.Tables[0].Rows[c]["calories"].ToString() + "<br/>" +
                                           "Caffeine: " + dataSet.Tables[0].Rows[c]["caffeine"].ToString() + "mg" + "<br/>" +
                                           "Fiber: " + dataSet.Tables[0].Rows[c]["fiber"].ToString() + "g" + "<br/>" +
                                           "Sugar: " + dataSet.Tables[0].Rows[c]["sugar"].ToString() + "mg" + "<br/>" +
                                           "Sodium: " + dataSet.Tables[0].Rows[c]["sodium"].ToString() + "mg" + "<br/>" +
                                           "Protein: " + dataSet.Tables[0].Rows[c]["protein"].ToString() + "g";
                div.Controls.Add(nutritionalDetails);

                HtmlGenericControl br1 = new HtmlGenericControl("br");
                div.Controls.Add(br1);

                //createButton  
                Button btn = new Button();
                btn.Text = "Add To order";
                btn.Click += Btn_Click;
                btn.Attributes.Add("class", "menuItemButton");
                btn.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                div.Controls.Add(btn);
                //append To MainDiv

                mainDiv.Controls.Add(div);
            }
            closeConnectionDB(con);
        }

        private void loadCurrentOrders()
        {
            SqlConnection con = createConnectionDB();
            DataSet dataSet = fillDataSet(con, "select * from curr_orders_table where client_id=" + idString);
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
                img.Height = 30;
                img.Width = 30;
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

                
                //<i class="fas fa-times"></i>
                Button deleteItem = new Button();
                deleteItem.Text = "Remove Item";
                deleteItem.Attributes.Add("class", "btn btn-danger");
                deleteItem.Attributes.Add("itemId", dataSet.Tables[0].Rows[c]["current_id"].ToString());
                deleteItem.Click += removeItem;
                divLeft.Controls.Add(deleteItem);

                currentOrdersSection.Controls.Add(divLeft);

            }
            closeConnectionDB(con);

            HtmlGenericControl totalPriceDiv = new HtmlGenericControl("div");
            HtmlGenericControl totalPrice = new HtmlGenericControl("h3");
            totalPrice.InnerHtml = "$" + totalPayment;
            totalPriceDiv.Attributes.Add("class", "totalPayment");
            totalPriceDiv.Controls.Add(totalPrice);
            currentOrdersSection.Controls.Add(totalPriceDiv);
        }

        private void removeItem(object sender, EventArgs e)
        {
            Response.Write("  " + (sender as Button).Attributes["itemId"]);
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"DELETE FROM curr_orders_table WHERE current_id = " + (sender as Button).Attributes["itemId"];
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            Response.Redirect("MainMenu.aspx", false);
        }

        private void nutritionalBtn_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            double total = 0.00;
            //Response.Write(temp[int.Parse((sender as Button).Attributes["idValue"].ToString()) -1].Text);
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"insert into curr_orders_table values(@client_id, @menu_id, @delivery_date, @delivery_address, @store_id, @quantity)";
            cmd.Parameters.AddWithValue("client_id", idString);
            cmd.Parameters.AddWithValue("menu_id", (sender as Button).Attributes["idValue"].ToString());
            cmd.Parameters.AddWithValue("delivery_date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("delivery_address", addressString);//by default, personal address could change it in curr orders table
            cmd.Parameters.AddWithValue("store_id", DropDownList1.SelectedValue);//TODO at more restaurants later on
            cmd.Parameters.AddWithValue("quantity", temp[int.Parse((sender as Button).Attributes["idValue"].ToString()) - 1].Text);
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            loadCurrentOrders();

            SqlCommand totalPrice = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            DataSet dataSet = fillDataSet(con, "select * from curr_orders_table where client_id=" + idString);

            for (int c = 0; c < dataSet.Tables[0].Rows.Count; c++)
            {
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);

                total += double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
            }
            closeConnectionDB(con);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM curr_orders_table WHERE client_id = " + idString;
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);

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

        protected void ordersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("orders_cart.aspx");
        }
    }
}