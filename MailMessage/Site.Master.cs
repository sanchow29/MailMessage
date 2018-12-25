using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MailMessage
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                styleMenuPages();
            }

        }

        public void styleMenuPages()
        {

            if (Request.Url.AbsoluteUri.Contains("SingleMail"))
            {
                // Single Mail
                listItem_singleMail.Style["border-bottom"] = "2px solid white";
                listItem_home.Style.Clear();
                listItem_multiMail.Style.Clear();
            }
            else if (Request.Url.AbsoluteUri.Contains("MultipleMail"))
            {
                // Multiple Mail
                listItem_multiMail.Style["border-bottom"] = "2px solid white";
                listItem_home.Style.Clear();
                listItem_singleMail.Style.Clear();
            }
            else
            {
                //Home
                //listItem_home.Style["border-bottom"] = "2px solid white";
                //listItem_singleMail.Style.Clear();
                //listItem_multiMail.Style.Clear();
            }

        }

        protected void lnkbtn_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
        }

    }
}