﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class HomePage1 : System.Web.UI.Page
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
        }
    }
}