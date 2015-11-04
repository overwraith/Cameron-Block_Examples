/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 8.2
 * Purpose: to create a GUI application. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment_8._2_B {
    public partial class assignment8 : Form {
        public assignment8() {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e) {
            MessageBox.Show("The Button Has Been Clicked", "Click Me");
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void assignment8_Load(object sender, EventArgs e) {

        }
    }
}
