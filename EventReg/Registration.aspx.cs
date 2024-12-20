using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventReg
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                int userId = Convert.ToInt32(Session["userId"]);
                LoadRegisteredEvents(userId);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void LoadRegisteredEvents(int userId)
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PT\\PTLAB\\6th exercise\\EventRegistration\\EventRegistration\\EventRegistration.mdf\";Integrated Security=True;Connect Timeout=30;";

            string query = "SELECT r.EventId, e.EventName, e.Venue, e.EventDate " +
                           "FROM Registration r " +
                           "JOIN Events e ON r.EventId = e.EventId " +
                           "WHERE r.UserId = @UserId";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEventId = GridView1.SelectedRow.Cells[1].Text; 
            Response.Write("<script>alert('You selected event ID: " + selectedEventId + "');</script>");
        }
    }
}
