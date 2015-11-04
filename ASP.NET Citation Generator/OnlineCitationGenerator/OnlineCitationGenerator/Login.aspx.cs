using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProjectCS {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Request.IsSecureConnection) {
                //secure the connection
                //Response.Redirect(Request.Url.ToString().Replace("http:", "https:"));
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e) {
            Session.Add("username", this.User.Identity.Name);
            Response.Redirect("~/References.aspx");//"~/CitationInput3.aspx"
        }
    }
}