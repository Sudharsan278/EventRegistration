using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventReg
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                int userId = Convert.ToInt32(Session["userId"]);

                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";
                string query = "SELECT UserName, Email, College FROM Users WHERE Id = @UserId";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                string email = reader["Email"].ToString();
                                string college = reader["College"].ToString();

                                Label2.Text = userName;
                                Label3.Text = email;
                                Label4.Text = college;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            loadEvents();
        }

        private void loadEvents()
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";

            string query = "SELECT EventId, EventName, Venue, EventDate FROM Events";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                int userId = Convert.ToInt32(Session["userId"]);

                string eventId = TextBox1.Text;

                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";

                string fetchEventQuery = "SELECT EventName, Venue, EventDate FROM Events WHERE EventID = @EventId";
                string insertQuery = "INSERT INTO Registration (UserId, EventId, Event, Venue, EventDate) VALUES (@UserId, @EventId, @Event, @Venue, @EventDate)";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        string eventName = string.Empty;
                        string venue = string.Empty;
                        DateTime eventDate = DateTime.MinValue;

                        using (SqlCommand cmdFetch = new SqlCommand(fetchEventQuery, conn))
                        {
                            cmdFetch.Parameters.AddWithValue("@EventId", eventId);
                            SqlDataReader reader = cmdFetch.ExecuteReader();

                            if (reader.Read())
                            {
                                eventName = reader["EventName"].ToString();  
                                venue = reader["Venue"].ToString();
                                eventDate = Convert.ToDateTime(reader["EventDate"]);
                            }
                            reader.Close();
                        }

                        if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(venue) || eventDate == DateTime.MinValue)
                        {
                            Response.Write("<script>alert('Invalid event data. Please try again.');</script>");
                            return;
                        }

                        using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@UserId", userId);
                            cmdInsert.Parameters.AddWithValue("@EventId", eventId);
                            cmdInsert.Parameters.AddWithValue("@Event", eventName);
                            cmdInsert.Parameters.AddWithValue("@Venue", venue);
                            cmdInsert.Parameters.AddWithValue("@EventDate", eventDate);

                            int rowsAffected = cmdInsert.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                
                                Response.Redirect("Registration.aspx");
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
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
