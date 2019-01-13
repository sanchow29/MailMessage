using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace MailMessage
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear all the textbox values
        }

        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text.ToString();
            string lname = txtLname.Text.ToString();
            string emailid = txtEmail.Text.ToString();
            string pwd = txtPwd.Text.ToString();
            string phoneno = txtPhoneNo.Text.ToString();
            string role = rblRole.SelectedItem.Value.ToString();
            string emaillimit = txtEmailLimit.Text.ToString();

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(emailid) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(phoneno)  || string.IsNullOrEmpty(emaillimit))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please fill all the details to update')", true);
            }
            else
            {
                MySqlConnection MyConn2 = new MySqlConnection(" server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018");
                MySqlCommand MyCommand2 = new MySqlCommand($"INSERT INTO `MailMessage_details` (`FName`, `LName`, `Email_ID`, `Password`, `Phone_Number`, `Role`, `EmailLimit`, `Status`, `CreatedBy`, `CreatedDate`) VALUES ('{fname}', '{lname}', '{emailid}', '{pwd}', '{phoneno}', '{role}', '{emaillimit}', 'Active', '{base.Session["Email"].ToString()}', '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}');", MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Details updated successfully.')", true);
            }
        }
    }
}