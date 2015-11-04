using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace OnlineCitationGenerator {
    public partial class CitationInupt2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }//end method

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

        }//end method
    }
}