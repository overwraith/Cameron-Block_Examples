/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ice_Cream_Shop {

    class IceCreamShop {

        static void Main(string[] args) {

            Application.EnableVisualStyles();

            Application.Run(new IceCreamShop_Form());

            //pause();
        }//end main

        public static void pause() {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }

    }//end class

}//end namespace
