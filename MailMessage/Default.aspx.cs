using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;

using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.IO;

namespace MailMessage
{
    public partial class _Default : Page
    {
        private string MyConnection2 = "server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty((string)(base.Session["FName"])) || string.IsNullOrEmpty((string)(base.Session["LName"])))
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                this.BindGrid();
               // GetData();
               this.GetChartData();
               this. GetChartTypes();
                lblAsignedcount.Text = base.Session["EmailLimit"].ToString();
                lblUsedcount.Text = Convert.ToString(Mailcount(base.Session["UserID"].ToString()));
            }
        }

        private void BindGrid()
        {
            try
            {
                // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                string query = "select name,datetime,count,type,role from hans.dashboard_details where name='" + base.Session["UserID"].ToString() + "' order by datetime asc;";
                using (MySqlConnection con = new MySqlConnection(MyConnection2))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('No emails are used by you!!')", true);
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        private void GetData()
        {
            // First load             
           
            var Query = "select * from hans.dashboard_details where name='" + base.Session["UserID"].ToString() + "';";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MyConn2.Open();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = MyCommand2;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            GridView1.DataSource = dTable;
            GridView1.DataBind();
            MyConn2.Close();
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('No emails are used by you!!')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('No emails are used by you!!')", true);
                return emailcount;
            }
            return emailcount;
        }
        private void GetChartTypes()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                ddlChart.Items.Add(li);
            }
        }

        private void GetChartData()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(MyConnection2))
                {
                    var MyConn2 = new MySqlConnection(MyConnection2);
                    var MyCommand2 = new MySqlCommand("SELECT datetime,count FROM dashboard_details WHERE  name='" + base.Session["UserID"].ToString() + "'group by DateTime ;", MyConn2);
                    MyConn2.Open();
                    var MyReader2 = MyCommand2.ExecuteReader();
                    Series series = Chart1.Series["Series1"];
                    while (MyReader2.Read())
                    {
                        series.Points.AddXY(MyReader2["DateTime"].ToString(),
                        MyReader2["count"]);
                    }
                    MyConn2.Close();
                }
            }
            catch( Exception ex)
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('No emails are used by you!!')", true);
            }
           
            
        }

        protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GetChartData();
            this.Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChart.SelectedValue);
        }
    }
}