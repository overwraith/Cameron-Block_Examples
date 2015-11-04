/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 9.2
 * Purpose: to create a GUI program that determines the price of a rental car. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment_9._2 {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        double totalPrice = 0;

        private void btnSelect_Click(object sender, EventArgs e) {
            //compute total price of rental
            if (listBox1.SelectedItem != null) {//make sure user selects a car model
                if (rentalDays != 0) {//make sure user selects a date
                    totalPrice = rentalDays * totalPrice;

                    label1.Text = "Number of Rental Days: " + rentalDays;
                    label2.Text = "Total Price is: " + totalPrice;
                    //MessageBox.Show("Number of Rental Days: " + rentalDays + "\n"
                    //    + "Total Price is: " + totalPrice);
                }
                else
                    MessageBox.Show("Select a date first. ", "Date");
            }
            else
                MessageBox.Show("Select a car model first. ", "Car Model");
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        double rentalDays = 0;

        private void monthCalendar1_SelectionChanged(object sender, DateRangeEventArgs e) {

            DateTime dateStart = monthCalendar1.TodayDate;
            DateTime dateEnd = monthCalendar1.SelectionRange.Start.Date;

            if (dateStart < dateEnd) {

                //set number of rental days
                rentalDays = dateEnd.Subtract(dateStart).TotalDays;
                //MessageBox.Show("The number of days between start and end are: " + rentalDays);
            }
            else {//error, cannot set date before todays date
                MessageBox.Show("Cannot set return date before todays date. ", "Error!");
                //allowing a user to return the car on the same day they rented it would result
                //in a price of 0 dollars, because they did not rent it a full day, so we are
                //not allowing it. 
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.SelectedItem.ToString() == "Compact")
                totalPrice = 19.95;
            else if (listBox1.SelectedItem.ToString() == "Standard")
                totalPrice = 24.95;
            else //Luxury
                totalPrice = 39;
        }

    }//end class

}//end namespace
