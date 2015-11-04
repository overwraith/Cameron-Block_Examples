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
    public partial class NewBook : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnEnterBook_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string insert = "INSERT INTO Book (publicationDate, title, subtitle, City, State, publisher, " 
                + "translation, edition, volume, URL, DOI, PaperID) VALUES (@publicationDate, @title, @subtitle, "
                + "@City, @State, @publisher, @translation, @edition, @volume, @URL, @DOI, @PaperID)";

            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@publicationDate", DateTime.Parse(txtPubDate.Text));
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@subtitle", txtSubTitle.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@State", txtState.Text);
            cmd.Parameters.AddWithValue("@publisher", txtPub.Text);
            cmd.Parameters.AddWithValue("@translation", chkTrans.Checked);
            cmd.Parameters.AddWithValue("@edition", txtEdition.Text);
            cmd.Parameters.AddWithValue("@volume", txtVolume.Text);
            cmd.Parameters.AddWithValue("@URL", txtURL.Text);
            cmd.Parameters.AddWithValue("@DOI", txtDOI.Text);
            cmd.Parameters.AddWithValue("@PaperID", Session["PaperID"]);

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