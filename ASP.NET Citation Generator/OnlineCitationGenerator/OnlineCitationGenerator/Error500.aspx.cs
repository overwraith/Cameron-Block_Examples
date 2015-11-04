using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace OnlineCitationGenerator {
    public partial class Error500 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Exception ex = (Exception)Session["Exception"];
                this.sendMail(ex);
                Session.Remove("Exception");
            }
        }//end method

        private void sendMail(Exception ex) {
            String body = "An exception occurred at " 
                + DateTime.Now.ToLongTimeString() 
                + " on " + DateTime.Now.ToLongDateString() 
                + "<br />" + ex.Message;
            MailMessage msg = new MailMessage("Something@Something.com", "Support@Something.com");
            msg.Subject = "Exception in the References application";
            msg.Body = body;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("localhost");
            client.Send(msg);
        }
    }//end class
}//end namespace