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
    public partial class References : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Session.Add("username", this.User.Identity.Name);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            String title = txtTitle.Text;

            SqlConnection con = new SqlConnection(GetConnectionString());
            string insert = "INSERT INTO Reference (username, paperTitle) VALUES (@username, @paperTitle)";

            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
            cmd.Parameters.AddWithValue("@paperTitle", title);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/References.aspx");
            
        }

        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        protected void btnEditRef_Click(object sender, EventArgs e) {
            Session["PaperID"] = Int32.Parse(DropDownList1.SelectedItem.Value);
            Response.Redirect("~/EditReferences.aspx");
        }

        protected void btnPrintPage_Click(object sender, EventArgs e) {
            Session["PaperID"] = Int32.Parse(DropDownList1.SelectedItem.Value);
            Response.Redirect("~/PrintPage.aspx");
        }//end method
    }
}