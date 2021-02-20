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
            System.Diagnostics.Debug.WriteLine(idString + " " + firstNameString + " " + lastNameString + " " + usernameString + " " + passwordString);
            loadCards();
        }

        private void loadCards()
        {
            SqlConnection con = createConnectionDB();
            //photos
            DataSet dataSet = fillDataSet(con, "select * from menu_table");

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
                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                Label lbl = new Label();
                lbl.Text = dataSet.Tables[0].Rows[c]["name"].ToString();
                h3.Controls.Add(lbl);
                div.Controls.Add(h3);

                //create price
                Label price = new Label();
                price.Text = dataSet.Tables[0].Rows[c]["price"].ToString();
                div.Controls.Add(price);

                //create InputBox
                TextBox tb = new TextBox();
                tb.TextMode = TextBoxMode.Number;
                tb.Text = "1";
                div.Controls.Add(tb);

                //createButton  
                Button btn = new Button();
                btn.Text = "Add To order";
                btn.Click += Btn_Click;

                div.Controls.Add(btn);
                //append To MainDiv
                mainDiv.Controls.Add(div);

                

            }

            closeConnectionDB(con);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Response.Write("abc");
            //TODO add to database
        }

        
        private SqlConnection createConnectionDB()
        {
            //String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Semester5\Ecommerce\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";
            String mycon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sixta\Desktop\EcommAssignment2\EcommAssignment2\App_Data\dragonball_database.mdf;Integrated Security=True";

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