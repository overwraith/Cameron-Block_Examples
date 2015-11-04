/* Author: Cameron Block
 * Class: CIS 434 ASP.NET
 * Final Project
 * Purpose: To create an online APA citation generator. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCitationGenerator {
    public class Editor : Person {
        public int refID;
        public int editorID;

        public String suffix { get; set; }

        public override string ToString() {
            if (fname != "" && mname != "" && lname != "" && suffix != "")
                return String.Format("{0}, {1}. {2}., {3} ", lname, fname, mname, suffix);
            else if (fname != "" && mname != "" && lname != "")
                return String.Format("{0}, {1}. {2}. ", lname, fname, mname);
            else if (fname != "" && lname != "")
                return String.Format("{0}, {1}. ", lname, fname);
            else if (lname != "")
                return String.Format("{0}", lname);

            return "";
        }//end method

        //public int CompareTo(object obj) {
        //    if (obj == null) return 1;

        //    Editor other = obj as Editor;

        //    if (other != null) {
        //        return lname.CompareTo(other.lname);
        //    }
        //    else if (obj as Author != null) {
        //        Author auth = obj as Author;

        //        return lname.CompareTo(auth.lname);
        //    }
        //    else
        //        throw new ArgumentException("Object is not an Author. ");
        //}//end method

    }//end class
}//end namespace