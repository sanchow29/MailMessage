using System;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using System.Data;
using MySql.Data.MySqlClient;

namespace MailMessage
{
    public partial class About : Page
    {
        private string MyConnection2 = "server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";
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
            int limit = Mailcount(Session["Email"].ToString());
            if (limit > Convert.ToInt32(base.Session["EmailLimit"].ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Your limit Exceeded')", true);
            }
            else
            {
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
                            var MyConn2 = new MySqlConnection(MyConnection2);
                            var MyCommand2 = new MySqlCommand("insert into hans.dashboard_details(Name,DateTime,count,Type,Role) values('" + base.Session["Email"].ToString() + "','" + DateTime.Now.Date.ToString() + "','1','Single','" + base.Session["Role"].ToString() + "');", MyConn2);
                            MyConn2.Open();
                            var MyReader2 = MyCommand2.ExecuteReader();
                            MyConn2.Close();                           
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
        public int Mailcount(string name)
        {
            int emailcount = 0;
            try
            {
                var MyConn2 = new MySqlConnection(MyConnection2);
                MyConn2.Open();
                var MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = new MySqlCommand("SELECT sum(count) AS EmailCount FROM dashboard_details WHERE type in('single','multiple') and name='" + name + "' ;", MyConn2);
                var dTable = new DataTable();
                MyAdapter.Fill(dTable);
                if (dTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dTable.Rows)
                    {
                        emailcount = Convert.ToInt32(row["EmailCount"].ToString());
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to fetch the email count limit')", true);
                    return emailcount;
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to fetch the email count limit')", true);
                return emailcount;
            }
            return emailcount;
        }
    }
}