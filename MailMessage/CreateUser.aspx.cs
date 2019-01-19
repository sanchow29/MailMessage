using System;
using System.IO;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MailMessage
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)(base.Session["FName"])) || string.IsNullOrEmpty((string)(base.Session["LName"])))
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                string role = base.Session["Role"].ToString();
                if (role == "User")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertLogin", "alert('You don't have rights to see this page!!')", true);
                    Response.Redirect("~/SiteAcess.aspx");
                }
            }
            //clear all the textbox values
        }

       
        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtFname.Text.ToString();
                string lname = txtLname.Text.ToString();
                string emailid = txtEmail.Text.ToString();
                string userid = txtuserid.Text.ToString();
                string pwd = txtPwd.Text.ToString();
                string phoneno = txtPhoneNo.Text.ToString();
                string role = rblRole.SelectedItem.Value.ToString();
                string emaillimit = txtEmailLimit.Text.ToString();

                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(emailid) || string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(phoneno) || string.IsNullOrEmpty(emaillimit))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please fill all the mandatory details')", true);
                }
                else
                {
                    MySqlConnection MyConn2 = new MySqlConnection(" server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018");
                    MySqlCommand MyCommand2 = new MySqlCommand($"INSERT INTO `MailMessage_details` (`FName`, `LName`, `Email_ID`,`UserId`, `Password`, `Phone_Number`, `Role`, `EmailLimit`, `Status`, `CreatedBy`, `CreatedDate`) VALUES ('{fname}', '{lname}', '{emailid}','{userid}', '{pwd}', '{phoneno}', '{role}', '{emaillimit}', 'Active', '{base.Session["Email"].ToString()}', '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}');", MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MyConn2.Close();
                     txtFname.Text = null;
                    txtLname.Text = null;
                    txtEmail.Text = null;
                    txtuserid.Text = null;
                    txtPwd.Text = null;
                    txtPhoneNo.Text = null;
                    txtEmailLimit.Text = null;

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('User Created successfully.')", true);
                }
            }
            catch(Exception ex)
            {
                string filePath = Server.MapPath("~/testfolder/Logs/") + "\\" + "Catch.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Unable to create user. please try again!!.')", true);
            }
        }
    }
}