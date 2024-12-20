using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventReg
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            String UserName = TextBox1.Text;
            String Password = TextBox4.Text;    
            String Email = TextBox2.Text;   
            String College = TextBox3.Text;

            if(UserName.Length < 3)
            {
                Response.Write("<script>alert('UserName should have atleas 3 characters');</script>");
                return;
            }

            if (College.Length < 3)
            {
                Response.Write("<script>alert('College name should have atleas 3 characters');</script>");
                return;
            }

            if (Password.Length < 6)
            {
                Response.Write("<script>alert('Password should have at least 6 characters');</script>");
                return;
            }


            String connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";

            String query = "INSERT INTO Users (UserName, Email, Password, College) VALUES (@UserName, @Email, @Password, @College); SELECT SCOPE_IDENTITY();";

            String checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmdCheckEmail = new SqlCommand(checkEmailQuery, conn))
                    {
                        cmdCheckEmail.Parameters.AddWithValue("@Email", Email);

                        int emailCount = (int)cmdCheckEmail.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            Response.Write("<script>alert('Email already exists. Please use a different email.');</script>");
                            return;
                        }
                    }


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("UserName", UserName);
                        cmd.Parameters.AddWithValue("Email", Email);
                        cmd.Parameters.AddWithValue("Password", Password);
                        cmd.Parameters.AddWithValue("College", College);

                        Console.WriteLine("hello");

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);

                            Session["userId"] = userId;

                            Response.Write("<script>alert('Registration successful!');</script>");
                            Response.Redirect("Home.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                        }


                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
                finally { 
                    conn.Close();   
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}