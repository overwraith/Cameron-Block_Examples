using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineCitationGenerator {
    public partial class CitationInput : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            Label2.Visible = false;

            if (ddl1.SelectedIndex.ToString() == "Book") {
                //implement the book code
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {

            Response.Write("References\n");

            List<Book> books = BookDB.GetBookReferences();

            for (int i = 0; i < books.Count; i++ )
                Response.Write(books[i].ToString() + "\n");


        }//end event handler
    }//end page
}//end namespace