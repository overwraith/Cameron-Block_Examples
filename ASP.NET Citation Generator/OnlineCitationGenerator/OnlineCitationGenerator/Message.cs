using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCitationGenerator {
    public class Message {
        public string username;
        public DateTime timestamp;
        public string comment;

        public override string ToString() {
            return "<dt>" + username + " (" + timestamp.ToShortTimeString() + ")</dt>\n<dd>" + comment + "</dd>";
        }//end method
    }//end class
}