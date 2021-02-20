using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommAssignment2
{
    public partial class ContactPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameContactInput.Text;
            string lastName = lastNameContactInput.Text;
            string email = emailContactInput.Text;
            string message = messageInput.Text;


        }
    }
}