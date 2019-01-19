using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.IO;

namespace MailMessage
{
    public partial class Contact : Page
    {
        private string MyConnection2 = " server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)(base.Session["FName"])) || string.IsNullOrEmpty((string)(base.Session["LName"])))
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                //
            }
        }

        protected void btnsendmultipleemail_Click(object sender, EventArgs e)
        {
            string message = txtmultiplemessg.Text.ToString();
            string subject = txtmulsub.Text.ToString();
            int limit = Mailcount(base.Session["UserID"].ToString());
            int count = Convert.ToInt32(base.Session["EmailLimit"].ToString());
            if (limit <= count)
            {
                if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(subject))
                {
                    try
                    {
                        var mess = new System.Net.Mail.MailMessage() ;
                       
                        foreach (GridViewRow g in grdview_MultiEmail.Rows)
                        {
                            if (g.RowType == DataControlRowType.DataRow)
                            {
                                using (mess = new System.Net.Mail.MailMessage(base.Session["Email"].ToString(),g.Cells[0].Text.ToString())
                                {
                                    Subject = subject,
                                    Body = message
                                })
                                { 
                                    if (fileuploadAttachments_Multiple.HasFile)
                                    {
                                        string FileName = Path.GetFileName(fileuploadAttachments_Multiple.PostedFile.FileName);
                                        mess.Attachments.Add(new Attachment(fileuploadAttachments_Multiple.PostedFile.InputStream, FileName));
                                    }
                                    mess.IsBodyHtml = true;
                                    new SmtpClient
                                    {
                                        Host = "relay-hosting.secureserver.net",
                                        Port = 25,
                                        EnableSsl = false,
                                        DeliveryMethod = SmtpDeliveryMethod.Network,
                                        UseDefaultCredentials = false,
                                        Credentials = new NetworkCredential("info@hanusol.com", "hanusol@2018")
                                    }.Send(mess);
                                }
                            }
                        }
                        grdview_MultiEmail.DataSource = null;
                        grdview_MultiEmail.DataBind();
                        txtmultiplemessg.Text = null;
                        txtmulsub.Text = null;
                        Displaygrid_Div.Style["display"] = "none";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand("insert into hans.dashboard_details(Name,DateTime,count,Type,Role) values('" + base.Session["UserID"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + base.Session["Rowount"].ToString() + "','Multiple','" + base.Session["Role"].ToString() + "');", MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        MyConn2.Close();
                        Session["Rowount"] = null;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Email sent successfully.')", true);
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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Failed to send email.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Please enter all the mandatory fields')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Your daily limit Exceeded')", true);
            }
        }

        public void Readexceel(string path)
        {
           
            string conn = string.Empty;
            string filePath = path;
            DataTable dtExcel = new DataTable();
            conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";
            //conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 4.0;HDR=YES';";
            OleDbConnection con = new OleDbConnection(conn);
            OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);
            oleAdpt.Fill(dtExcel);

            if (dtExcel != null && dtExcel.Rows.Count > 0)
            {
                Displaygrid_Div.Style["display"] = "block";
                loadGridView(dtExcel);
            }
            Session["Rowount"] = dtExcel.Rows.Count;
            
            #region
            // Session["MailType"] = "Multiple";
            // working in local

            //StringBuilder sb = new StringBuilder();
            //string s;
            //Excel.Application excelApp = new Excel.Application();
            //if (excelApp != null)
            //{//@"C:\Users\sanch\source\repos\TestApplication\TestApplication\testfolder\Book1.xlsx"
            //    Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //    Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            //    Excel.Range excelRange = excelWorksheet.UsedRange;
            //    int rowCount = excelRange.Rows.Count;
            //    int colCount = excelRange.Columns.Count;
            //    Session["Rowount"] = rowCount;
            //    Session["MailType"] = "Multiple";
            //    for (int i = 1; i <= rowCount; i++)
            //    {
            //        for (int j = 1; j <= colCount; j++)
            //        {
            //            Excel.Range range = (excelWorksheet.Cells[i, 1] as Excel.Range);
            //            string cellValue = range.Value.ToString();
            //            sb.Append(cellValue);
            //            sb.Append(",");
            //        }
            //    }
            //    s = sb.ToString();
            //    string g = s.TrimEnd(',');
            //    Session["MultipleMailId"] = g;
            //    string[] sTwo = g.Split(',');
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("PersonMailID");
            //    DataRow dr = null;
            //    for (int i = 0; i < sTwo.Length; i++)
            //    {
            //        dr = dt.NewRow();
            //        dr["PersonMailID"] = sTwo[i];
            //        dt.Rows.Add(dr);
            //    }
            //    loadGridView(dt);
            //    excelWorkbook.Close();
            //    excelApp.Quit();
            //    return s;

            //}
            //return "";
            #endregion
            
        }

        public int Mailcount(string name)
        {
            int emailcount = 0;
            try
            {                
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand("SELECT sum(count) AS EmailCount FROM dashboard_details WHERE type in('single','multiple') and name='" + name + "' ;", MyConn2);
                MyConn2.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to fetch the email count limit')", true);
                return emailcount;
            }
            return emailcount;
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
           
            string name = base.Session["UserID"].ToString()  ;
            try
            {
                if (Multipleemailupd.HasFile)
                {
                    string filename = Server.MapPath("/testfolder/Uploads/") + name + "_" + Multipleemailupd.FileName ;
                    Multipleemailupd.SaveAs(filename);
                    Readexceel(filename);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert(' File uploaded successfully ')", true);
                    return;
                }                
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Saved", "alert('Unable to upload Exceel Sheet. Please Try Again!!. If it happens contact Admin')", true);
                return;
            }
        }

        /// <summary>
        /// For loading grid view sample test
        /// </summary>
        public void loadGridView(DataTable dt)
        {
            try
            {
                grdview_MultiEmail.DataSource = dt;
                grdview_MultiEmail.DataBind();
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
            }
        }

        protected void btn_bulkSampleExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/testfolder/SampleFile.xlsx");
        }


    }
}