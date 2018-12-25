using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace MailMessage
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string firstName = (string)(Session["FName"]);
            string lastName = (string)(Session["LName"]);
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                
            }
        }

        protected void btnsendsinglemail_Click(object sender, EventArgs e)
        {
            string to = txtsinsletoemail.Text.ToString();
            string message = txtsinglemessg.Text.ToString();
            string subject = txtsinglesub.Text.ToString();
            if (!string.IsNullOrEmpty(to) && !string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(subject))
            {
                try
                {
                    
                    var senderEmail = new MailAddress("info@hanusol.com", "sender");
                    var receiverEmail = new MailAddress(to, "Receiver");
                    var password = "hanusol@2018";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "relay-hosting.secureserver.net",
                        Port = 25,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new System.Net.Mail.MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                        txtsinsletoemail.Text = null;
                            txtsinsletoemail.Text = null;
                        txtsinglesub.Text = null;
                        Session["SingleRowount"] = "1";
                        Session["MailTypeeDtails"] = "Single";
                        string MyConnection2 = " server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";
                        string Query = "insert into hans.dashboard_details(Name,DateTime,count,Type) values('" + Session["FName"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + Session["SingleRowount"].ToString() + "','" + Session["MailTypeeDtails"].ToString() + "');";

                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        MyConn2.Close();
                        Session["SingleRowount"] = null;
                        Session["MailTypeeDtails"] = null;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Email sent successfully.')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Failed to send email.')", true);
                    ex.ToString();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please enter all the mandatory fields')", true);
            }
        }

    }
}