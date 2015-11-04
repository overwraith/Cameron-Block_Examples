using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace OnlineCitationGenerator {
    public partial class Test : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {

            if (Session["PreviousRowIndex"] != null) {
                var previousRowIndex = (int)Session["PreviousRowIndex"];
                GridViewRow PreviousRow = GridView1.Rows[previousRowIndex];
                PreviousRow.ForeColor = Color.Black;
                PreviousRow.BackColor = Color.White;

            }
            GridView1.SelectedIndex = e.NewSelectedIndex;

            GridViewRow row = GridView1.SelectedRow;
            row.ForeColor = Color.White;
            row.BackColor = Color.Blue;

            Session["PreviousRowIndex"] = row.RowIndex;
        }//end method

        protected void GridViewInsert(object sender, EventArgs e) {
            SqlDataSource1.Insert();
        }//end method

        protected void GridView1_PreRender(object sender, EventArgs e) {
            for (int i = 0; i < GridView1.Rows.Count - 1; i++) {
                if (GridView1.Rows[i].Cells[1].Controls.Count > 0)
                    GridView1.Rows[i].Cells[1].Controls[1].Visible = false;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void btnGenerate_Click(object sender, EventArgs e) {
            Response.Redirect("~/PrintPage.aspx");
        }

        protected void btnNewBook_Click(object sender, EventArgs e) {
            Response.Redirect("~/NewBook.aspx");
        }

        protected void btnNewAuthor_Click(object sender, EventArgs e) {
            try {
                Session["refID"] = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);//save the refID of the book in a session variable
                Response.Redirect("~/NewAuthor.aspx");
            }
            catch (NullReferenceException) {
                lblSelectValidate1.Visible = true;
            }
            
        }

        protected void btnNewEditor_Click(object sender, EventArgs e) {
            try {
                Session["refID"] = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);//save the refID of the book in a session variable
                Response.Redirect("~/NewEditor.aspx");
            }
            catch (NullReferenceException) {
                lblSelectValidate2.Visible = true;
            }
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e) {
            Response.Redirect("~/EditReferences.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e) {
            //Response.Redirect("~/EditReferences.aspx");
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {

        }//end method
    }
}