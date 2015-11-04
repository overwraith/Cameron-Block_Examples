/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 9.2
 * Purpose: to create a GUI program that determines the price of a rental car. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_9._2 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
