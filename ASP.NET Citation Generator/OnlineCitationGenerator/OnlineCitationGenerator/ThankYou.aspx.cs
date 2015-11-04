using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineCitationGenerator {
    public partial class ThankYou : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            String str;

            if(hasNaughtyWords(Session["Feedback"].ToString()) != true)
                str = "Thank you " + this.User.Identity.Name + " for your feedback concerning this website. ";
            else
                str = "Well, I am sorry you feel that way " + this.User.Identity.Name + ". ";

            Page.Controls.Add(new LiteralControl("<p>" + str + "</p>"));

        }

        protected bool hasNaughtyWords(String str) {
            String[] naughtyWords = new String[]{"damn ", "darn ", "hell "};//not going to put the really naughty ones in a school assignment

            for (int i = 0; i < naughtyWords.Length; i++)
                if (str.IndexOf(naughtyWords[i]) == -1)
                    return true;

            return false;
        }
    }
}