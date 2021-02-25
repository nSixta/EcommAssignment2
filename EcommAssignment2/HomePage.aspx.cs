using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class HomePage : System.Web.UI.Page
    {
        string idString = "";
        string firstNameString = "";
        string lastNameString = "";
        string usernameString = "";
        string passwordString = "";

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
        }
    }
}