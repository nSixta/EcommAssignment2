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
        protected void Page_Load(object sender, EventArgs e)
        {
            loadCards();
        }

        private void loadCards()
        {
            SqlConnection con = createConnectionDB();
            //photos
            DataSet dataSet = fillDataSet(con, "select * from menu_table");

            for(int c=0; c < dataSet.Tables[0].Rows.Count; c++)
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
                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                Label lbl = new Label();
                lbl.Text = dataSet.Tables[0].Rows[0]["name"].ToString();
                h3.Controls.Add(lbl);
                div.Controls.Add(h3);

                //create price
                Label price = new Label();
                price.Text = dataSet.Tables[0].Rows[0]["price"].ToString();
                div.Controls.Add(price);

                //create InputBox
                TextBox tb = new TextBox();
                tb.TextMode = TextBoxMode.Number;
                tb.Text = "1";
                div.Controls.Add(tb);

                //append To MainDiv
                mainDiv.Controls.Add(div);

                /*//add css to card
                div.Style["width"] = "15%";
                div.Style["height"] = "40vh";
                div.Style["background-color"] = "antiquewhite";
                div.Style["border"] = "1px solid black";
                div.Style["padding"] = "5px";
                div.Style["display"] = "inline-block";
                //add css to photo
                img.Style["width"] = "80%";
                img.Style["height"] = "auto";*/

                Button btn = new Button();
                btn.Text = "Add order";

            }

            closeConnectionDB(con);
        }

        private void addToOrder()
        {
            Response.Redirect("SignUpPage.aspx");
        }
        private SqlConnection createConnectionDB()
        {
            String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
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


    }
}