using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCitationGenerator {
    public class Person : IComparable{

        public String fname { get; set; }
        public String mname { get; set; }
        public String lname { get; set; }

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Person other = obj as Person;

            if (other != null) {
                return lname.CompareTo(other.lname);
            }
            else
                throw new ArgumentException("Object is not an Person. ");
        }//end method
    }//end class
}//end namespace