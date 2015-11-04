using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace OnlineCitationGenerator {
    public partial class NewAuthor : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnEnter_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string insert = "INSERT INTO Author (refID, fname, mname, lname, suffix) VALUES (@refID, @fname, @mname, @lname, @suffix)";

            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@refID", Session["refID"]);
            cmd.Parameters.AddWithValue("@fname", txtFname.Text);
            cmd.Parameters.AddWithValue("@mname", txtMname.Text);
            cmd.Parameters.AddWithValue("@lname", txtLname.Text);
            cmd.Parameters.AddWithValue("@suffix", txtSuffix.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/EditReferences.aspx");
        }
        
        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}