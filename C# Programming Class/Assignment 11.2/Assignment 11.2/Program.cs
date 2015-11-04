/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 11.2
 * Purpose: to create a 'friends' list program. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_11._2 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Friends());
        }
    }
}
