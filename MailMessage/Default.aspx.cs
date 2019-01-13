using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
namespace MailMessage
{
    public partial class _Default : Page
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
                // First load             
                lblAsignedcount.Text = Session["EmailLimit"].ToString();
                lblUsedcount.Text = Convert.ToString(Mailcount(Session["Email"].ToString()));
                var Query = "select * from hans.dashboard_details where Name='" + Session["Email"].ToString() + "';";
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertLogin", "alert('Unable to fetch the email count limit')", true);
                return emailcount;
            }
            return emailcount;
        }

    }
}