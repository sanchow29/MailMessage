using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MailMessage
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)(base.Session["FName"])) || string.IsNullOrEmpty((string)(base.Session["LName"])))
            {
                Response.Redirect("~/Login.aspx");
            }
            
            if (!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/testfolder/Uploads/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                }
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            { 
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
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
            }
        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            if (base.Session["Role"].ToString() == "User")
            {
               
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertLogin", "alert('You don't have rights to see this page!!')", true);
                    Response.Redirect("~/SiteAcess.aspx");
               
            }
            else
            {
                try
                {
                    string filePath = (sender as LinkButton).CommandArgument;
                    File.Delete(filePath);
                    Response.Redirect(Request.Url.AbsoluteUri);
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
        }
    }
}