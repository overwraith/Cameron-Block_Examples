using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OnlineCitationGenerator {
    public partial class ContactUs : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            
            //count the number of visits
            if (Session["NumContactVisits"] == null)
                Session["NumContactVisits"] = 1;//assign 1 for the first visit 
            else//accumulate on subsequent visits
                Session["NumContactVisits"] = (int)Session["NumContactVisits"] + 1;

            //display the number of visits with a cookie
            lblVisitCustomize.Text = "You have visited this page " + Session["NumContactVisits"].ToString() + " times. ";
            lblVisitCustomize.Visible = true;

            MessageList shoutBox;
            if (Application["ShoutBox"] == null) {
                shoutBox = new MessageList();
                Application.Add("ShoutBox", shoutBox);
            }
            else {
                shoutBox = (MessageList)Application["ShoutBox"];
                lblShoutBox.Text = shoutBox.ToString();
            }
            if (ScriptManager1.IsInAsyncPostBack != true)
                txtComment.Focus();
        }//end method

        protected void btnAddMsg_Click(object sender, EventArgs e) {
            Message msg = new Message();

            if (this.User.Identity.Name != "") {
                msg.username = this.User.Identity.Name;
                msg.timestamp = DateTime.Now;
                msg.comment = txtComment.Text;

                Application.Lock();
                MessageList msgList = (MessageList)Application["ShoutBox"];
                msgList.Add(msg);
                Application.UnLock();

                lblShoutBox.Text = msgList.ToString();

                Session["Feedback"] = txtComment.Text;

                txtComment.Text = "";
                txtComment.Focus();

                
                Response.Redirect("~/ThankYou.aspx");
            }
            else {
                lblLogin.Text = "Please log in to contact the site admins. ";
            }
        }//end method
    }//end class
}//end namespace