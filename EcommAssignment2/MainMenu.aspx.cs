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
            idString = Session["idString"].ToString();
            lastNameString = Session["lastNameString"].ToString();
            usernameString = Session["usernameString"].ToString();
            passwordString = Session["passwordString"].ToString();
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);

            if (Session["usernameString"] == null && Session["idString"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            idString = Session["idString"].ToString();
            usernameString = Session["usernameString"].ToString();
            addressString = Session["addressString"].ToString();
            loadCards();
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
                //createDiv
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "oneOrderInQueue");

                //menu_name
                DataSet temp = fillDataSet(con, "select * from menu_table where menu_id=" + dataSet.Tables[0].Rows[c]["menu_id"]);
                Label lbl = new Label();
                lbl.Text = temp.Tables[0].Rows[0]["name"].ToString();
                div.Controls.Add(lbl);

                //quantity
                Label quan1 = new Label();
                quan1.Text = "Quantity:";
                div.Controls.Add(quan1);

                Label quan = new Label();
                quan.Text = dataSet.Tables[0].Rows[c]["quantity"].ToString();
                div.Controls.Add(quan);

                //totalPrice
                Label price1 = new Label();
                price1.Text = "$";
                div.Controls.Add(price1);

                double priceTemp = double.Parse(temp.Tables[0].Rows[0]["price"].ToString()) * int.Parse(dataSet.Tables[0].Rows[c]["quantity"].ToString());
                Label price = new Label();
                price.Text = priceTemp.ToString();
                totalPayment += priceTemp;
                div.Controls.Add(price);

                //TODO put this in the being delivered
                /*//Btn
                Button btn = new Button();
                btn.Text = "Click if items are delivered";
                btn.Click += itemsDelivered;
                btn.Attributes.Add("idValue", dataSet.Tables[0].Rows[c]["menu_id"].ToString());
                div.Controls.Add(btn);*/

                currentOrdersSection.Controls.Add(div);

            }
            closeConnectionDB(con);
            //overAllTotal.Text = "" + totalPayment;
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
            //overAllTotal.Text = "" + totalPayment;
            totalPriceLabel.Text = "Total Price: " + total.ToString() + "$";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = createConnectionDB();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM curr_orders_table";
            cmd.ExecuteNonQuery();
            closeConnectionDB(con);
            totalPriceLabel.Text = "Total Price: " + 0 + "$";

        }

        private SqlConnection createConnectionDB()
        {

            //String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
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

        protected void ordersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("orders.aspx");
        }
    }
}