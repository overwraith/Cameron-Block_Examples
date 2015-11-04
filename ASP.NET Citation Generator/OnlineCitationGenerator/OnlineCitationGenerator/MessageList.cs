using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace OnlineCitationGenerator {
    public class MessageList {
        private List<Message> msgList = new List<Message>();

        private void purge() {
            DateTime purgeTime = DateTime.Now;
            purgeTime = purgeTime.AddHours(-24);//making this a little bit longer
            int i = 0;

            while (i < msgList.Count) {
                if (msgList[i].timestamp <= purgeTime)
                    msgList.RemoveAt(i);
                else
                    i++;
            }
        }//end method

        public void Add(Message msg) {
            purge();
            System.Threading.Thread.Sleep(2000);
            msgList.Add(msg);//I like my lists arranged from oldest to newest
        }

        public override string ToString() {
            purge();
            StringBuilder str = new StringBuilder();

            if (msgList.Count > 0) {
                str.AppendLine("<dl>");
                foreach (Message msg in msgList) {
                    str.AppendLine(msg.ToString());
                }
                str.AppendLine("</dl>");
            }
            return str.ToString();
        }//end method
    }//end class
}