/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 11.2
 * Purpose: to create a 'friends' list program. 
 */

using System;

namespace Assignment_11._2 {
    public class Friend {
        private String lname;
        private String fname;
        private String phoneNum;

        private int month;
        private int day;

        //getters and setters
        public String Lname { get { return lname; } set { this.lname = value; } }
        public String Fname { get { return fname; } set { this.fname = value; } }
        public String PhoneNum { get { return phoneNum; } set { this.phoneNum = value; } }

        public int Month { get { return month; } set { this.month = value; } }
        public int Day { get { return day; } set { this.day = value; } }

        //ToString()
        public override string ToString() {
            return fname + "," + lname + "," + phoneNum + "," + month + "," + day;
        }

        public Friend() {
        }
    }//end class
}//end namespace