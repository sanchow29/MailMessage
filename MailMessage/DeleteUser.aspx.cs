﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MailMessage
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        string constr= "server = 50.62.209.108;port=3306; user id = sarasa; database = hans;password=@dmin@2018";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
           // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string query = "SELECT Fname,Lname,Email_ID,Role,EmailLimit,Status FROM hans.MailMessage_details";
            using (MySqlConnection con = new MySqlConnection(constr))
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

        protected void Insert(object sender, EventArgs e)
        {
           // string Fname = txtFname.Text.ToString();
           // string Lname = txtLname.Text.ToString();
           //// string EmailID = txtEmailid.Text.ToString();
           // string Role = txtRole.Text.ToString();
           // string EmailLimit = txtEmailLimit.Text.ToString();
           // string Status = txtStatus.Text.ToString();

           // string query = "INSERT INTO hans.MailMessage_details VALUES(@Fname, @Lname,@Email_ID,@Role,@EmailLimit,@Status)";
           //// string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
           // using (MySqlConnection con = new MySqlConnection(constr))
           // {
           //     using (MySqlCommand cmd = new MySqlCommand(query))
           //     {
           //         cmd.Parameters.AddWithValue("@Fname", Fname);
           //         cmd.Parameters.AddWithValue("@Lname", Lname);
           //        // cmd.Parameters.AddWithValue("@EmailID", EmailID);
           //         cmd.Parameters.AddWithValue("@Role", Role);
           //         cmd.Parameters.AddWithValue("@EmailLimit", EmailLimit);
           //         cmd.Parameters.AddWithValue("@Status", Status);
           //         cmd.Connection = con;
           //         con.Open();
           //         cmd.ExecuteNonQuery();
           //         con.Close();
           //     }
           // }
           // this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
           // int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Fname = (row.FindControl("txtFname") as TextBox).Text;
            string Lname = (row.FindControl("txtLname") as TextBox).Text;
           string EmailID = (row.FindControl("txtEmailid") as TextBox).Text;
            string Role = (row.FindControl("txtRole") as TextBox).Text;
            string EmailLimit = (row.FindControl("txtEmailLimit") as TextBox).Text;
            string Status = (row.FindControl("txtStatus") as TextBox).Text;
            string query = "UPDATE hans.MailMessage_details SET Fname=@Fname,Lname=@Lname,Role=@Role,EmailLimit=@EmailLimit,Status=@Status WHERE Email_ID=@Email_ID";
           // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Fname", Fname);
                    cmd.Parameters.AddWithValue("@Lname", Lname);
                    cmd.Parameters.AddWithValue("@Email_ID", EmailID);
                    cmd.Parameters.AddWithValue("@Role", Role);
                    cmd.Parameters.AddWithValue("@EmailLimit", EmailLimit);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string EmailID = Convert.ToString (GridView1.DataKeys[e.RowIndex].Values[0]);
           // int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM hans.MailMessage_details WHERE Email_ID=@Email_ID";
          //  string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Email_ID", EmailID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            //{
            //    (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            //}
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}