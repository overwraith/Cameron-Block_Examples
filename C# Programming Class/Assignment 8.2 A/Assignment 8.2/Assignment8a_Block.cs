/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 8.2
 * Purpose: to create a GUI application. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Assignment_8._1 {

    class Program {

        static void Main(string[] args) {
            Application.Run(new assignment8());
        }//end main

    }//end class

    public class assignment8 : System.Windows.Forms.Form {
        //Instantiate two button objects
        Button btnClickMe = new Button();
        Button btnExit = new Button();

        public assignment8() {
            //set the form title bar to display "Assignment 8"
            this.Text = "Assignment 8";

            this.Size = new System.Drawing.Size(300, 150);

            //set the button text
            btnClickMe.Text = "Press Me";
            btnExit.Text = "Exit";

            this.Controls.AddRange(new Control[] { btnClickMe, btnExit });

            //set button locations
            btnClickMe.Location = new System.Drawing.Point(15, 20);
            btnExit.Location = new System.Drawing.Point(15, 60);

            //register event handlers
            btnClickMe.Click += new EventHandler(btnClickMe_Click);
            btnExit.Click += new EventHandler(btnExit_Click);
        }

        //event handlers
        protected void btnClickMe_Click(Object sender, EventArgs e) {
            MessageBox.Show("The Button Has Been Clicked", "Click Me");
        }

        protected void btnExit_Click(Object sender, EventArgs e) {
            Application.Exit();
        }

    }//end class

}//end namespace
