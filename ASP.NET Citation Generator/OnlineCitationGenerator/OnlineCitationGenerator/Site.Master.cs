using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProjectCS {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e) {
            //don't let non logged in users modify our pages
            Response.Redirect("~/Home.aspx");
        }
    }
}