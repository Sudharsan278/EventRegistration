using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace EventReg
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowAlert("Email and Password cannot be empty.");
                return;
            }

            if (password.Length < 6)
            {
                ShowAlert("Password should have at least 6 characters.");
                return;
            }

            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";

            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            string checkPasswordQuery = "SELECT Id, Password FROM Users WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmdCheckEmail = new SqlCommand(checkEmailQuery, conn))
                    {
                        cmdCheckEmail.Parameters.AddWithValue("@Email", email);
                        int emailCount = (int)cmdCheckEmail.ExecuteScalar();

                        if (emailCount == 0)
                        {
                            ShowAlert("Email not found. Please register first.");
                            return;
                        }
                    }

                    using (SqlCommand cmdCheckPassword = new SqlCommand(checkPasswordQuery, conn))
                    {
                        cmdCheckPassword.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = cmdCheckPassword.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Password"].ToString();
                                string userId = reader["Id"].ToString();

                                if (storedPassword != password)
                                {
                                    ShowAlert("Invalid password. Please try again.");
                                    return;
                                }

                                Session["userId"] = userId;
                                Response.Redirect("Home.aspx");
                            }
                            else
                            {
                                ShowAlert("Invalid email or password.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert("An error occurred: " + ex.Message);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        private void ShowAlert(string message)
        {
            string script = $"<script>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", script);
        }
    }
}
