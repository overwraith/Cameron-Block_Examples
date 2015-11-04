using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineCitationGenerator {
    public partial class ChangePassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e) {
            lblChangePass.Visible = true;
        }

        protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e) {
            Response.Redirect("~/CitationInput3.aspx");
        }

        protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e) {
            Response.Redirect("~/Home.aspx");
        }
    }
}