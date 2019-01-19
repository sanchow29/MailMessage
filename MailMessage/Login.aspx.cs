using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace MailMessage
{
    public partial class Login : System.Web.UI.Page
    {
        private string MyConnection2 = "server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clearing session here
                Session.Clear();
            }
        }

        //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(Login1.UserName) && !string.IsNullOrEmpty(Login1.Password))
        //    {

        //        try
        //        {                 

        //            var Query = "select * from hans.MailMessage_details where UserID='" + Login1.UserName + "' and Password='" + Login1.Password + "';";
        //            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
        //            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
        //            MyConn2.Open();
        //            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
        //            MyAdapter.SelectCommand = MyCommand2;
        //            DataTable dTable = new DataTable();
        //            MyAdapter.Fill(dTable);
        //            if (dTable.Rows.Count > 0)
        //            {
        //                //Session["CurrentUser"] = Login1.UserName;
        //                foreach (DataRow row in dTable.Rows)
        //                {
        //                    Session["FName"] = row["FName"].ToString();
        //                    Session["LName"] = row["LName"].ToString();
        //                    Session["Email"] = row["Email_ID"].ToString();
        //                    Session["UserID"] = row["UserID"].ToString();
        //                    Session["PHNO"] = row["Phone_Number"].ToString();
        //                    Session["Role"] = row["Role"].ToString();
        //                    Session["EmailLimit"] = row["EmailLimit"].ToString();
        //                    Session["Status"] = row["Status"].ToString();

        //                }
        //                Response.Redirect("~/Default.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to login , Please try again')", true);
        //                return;
        //            }

        //            MyConn2.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            string filePath = Server.MapPath("~/testfolder/Logs/") + "\\" + "Catch.txt";

        //            using (StreamWriter writer = new StreamWriter(filePath, true))
        //            {
        //                writer.WriteLine("-----------------------------------------------------------------------------");
        //                writer.WriteLine("Date : " + DateTime.Now.ToString());
        //                writer.WriteLine();

        //                while (ex != null)
        //                {
        //                    writer.WriteLine(ex.GetType().FullName);
        //                    writer.WriteLine("Message : " + ex.Message);
        //                    writer.WriteLine("StackTrace : " + ex.StackTrace);

        //                    ex = ex.InnerException;
        //                }
        //            }
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to login , Please try again')", true);
        //            return;
        //        }

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Please enter username and password to proceed')", true);
        //        return;
        //    }
        //}

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            string userName = UserName.Text;
            string password = Password.Text;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {

                try
                {

                    var Query = "select * from hans.MailMessage_details where UserID='" + userName + "' and Password='" + password + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MyConn2.Open();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    if (dTable.Rows.Count > 0)
                    {
                        //Session["CurrentUser"] = Login1.UserName;
                        foreach (DataRow row in dTable.Rows)
                        {
                            Session["FName"] = row["FName"].ToString();
                            Session["LName"] = row["LName"].ToString();
                            Session["Email"] = row["Email_ID"].ToString();
                            Session["UserID"] = row["UserID"].ToString();
                            Session["PHNO"] = row["Phone_Number"].ToString();
                            Session["Role"] = row["Role"].ToString();
                            Session["EmailLimit"] = row["EmailLimit"].ToString();
                            Session["Status"] = row["Status"].ToString();

                        }
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to login , Please try again')", true);
                        return;
                    }

                    MyConn2.Close();
                }
                catch (Exception ex)
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

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to login , Please try again')", true);
                    return;

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Please enter username and password to proceed')", true);
                return;
            }
        }

    }
}