/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 6.2
 * Purpose: to create an order processing program. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_6._2 {

    class Assignment6_Block {

        static void Main(string[] args) {

            ShippedOrder[] orders = new ShippedOrder[5];
            int orderNum;
            string customerName;
            int qty;
            bool reenter = false;

            for (int i = 0; i < orders.Length; i++) {//counting loop, fills the orders array
                
                orderNum = Input.promptInt32(reenter ? "Please reenter: " : "Enter order number: ", 
                    "Please enter a valid order number... ");

                reenter = false;

                foreach (ShippedOrder value in orders) {//validate there are no repeat orders
                    if (value != null && orderNum == value.OrderNum) {
                        Console.WriteLine("Sorry, the order number {0} is a duplicate... ", orderNum);
                        reenter = true;
                    }
                }

                if (reenter == true) {//repeat the current iteration if need to reenter data
                    i--;
                    continue;
                }

                customerName = Input.promptString("Enter customer name: ", 
                    "Please enter something into the prompt... ");
                qty = Input.promptInt32("Enter quantity: ", "Please enter a valid quantity... ");

                //instantiate the non-existant object
                orders[i] = new ShippedOrder(orderNum, customerName, qty);

                //put a line between inputs for better readability
                Console.WriteLine();

            }//end outer loop

            Console.WriteLine();


            Array.Sort(orders);
            

            Console.WriteLine("Summary: ");
            double total = 0;

            foreach (ShippedOrder value in orders) {//print out each member of the array
                Console.WriteLine(value.ToString());
                total += value.TotalPrice;
            }

            Console.WriteLine();
            Console.WriteLine("Total for all orders is {0:C}", total);
            pause();
        }//end main

        public static void pause() {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }

    }//end class

    public class Order : IComparable {
        protected const double PRICEEACH = 19.95;

        //automatically private
        protected int orderNum;
        protected string customerName;
        protected int qty;
        protected double totalPrice;

        //public accessors
        public int OrderNum { get{ return orderNum; } set{ orderNum = value; } }
        public string CustomerName { get{ return customerName; } set{ customerName = value; } }
        public int QTY { 
            get { return qty; } 
            set {
                //set total price each time quantity is updated
                qty = value; 
                totalPrice = qty * PRICEEACH; 
            } 
        }
        public double TotalPrice { get{ return totalPrice; } }

        public Order(int orderNum, string customerName, int qty) {
            this.OrderNum = orderNum;
            this.CustomerName = customerName;
            this.QTY = qty;
        }

        public override bool Equals(object obj) {
            //If parameter is null return false.
            if (obj == null) { return false; }

            //If parameter cannot be cast to Point return false.
            Order other = obj as Order;
            if ((System.Object)other == null) { return false; }

            //Return true if the fields match:
            return (this.orderNum == other.OrderNum);
        }

        public override int GetHashCode() {
            return this.orderNum;
        }

        public override string ToString() {
            return String.Format("Order {0} {1} {2} @{3:C} each. Total is {4:C}", 
                orderNum, customerName, qty, PRICEEACH, totalPrice);
        }

        //implement the CompareTo method mandated by IComparable
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Order other = obj as Order;

            if (other != null)
                return this.orderNum.CompareTo(other.OrderNum);
            else
                throw new ArgumentException("Object is not an Order");
        }

    }//end class

    public class ShippedOrder : Order {
        const double SHIPPING_FEE = 4.00;

        public new int QTY {
            get { return qty; } 
            set {
                //set total price each time quantity is updated
                qty = value;
                totalPrice = qty * PRICEEACH + SHIPPING_FEE;
            }
        }

        public ShippedOrder(int orderNum, string customerName, int qty) : base(orderNum, customerName, qty) {
            this.QTY = qty;//call the new quantity method, override what the Order class does
        }

        public override string ToString() {
            return String.Format("ShippedOrder {0} {1} {2} @{3:C} each. " 
                + "Shipping is {4:C}\nTotal is {5:C}", 
                orderNum, customerName, qty, PRICEEACH, SHIPPING_FEE, totalPrice);
        }
    }//end class

    public class Input {

        public static string promptString(string prompt, string errorMsg) {
            //This method modified from a previous java method I had written. 

            string input;//Put string outside the loop for efficiency. 

            while (true)//Loop until the user gets the input right. 
            {
                Console.Write(prompt);

                input = Console.ReadLine();

                if (input.Length > 0)
                    return input;

                Console.WriteLine(errorMsg);

            }//end loop

        }//end method


        public static string promptString(string prompt, string errorMsg,
            string[] options) {
            //This method modified from a previous java method I had written. 

            string input;//Put string outside the loop for efficiency. 

            while (true)//Loop until the user gets the input right. 
            {
                Console.Write(prompt);

                input = Console.ReadLine();

                //Will only return when input matches something in the list. 
                foreach (string str in options)
                    if (string.Equals(input, str, StringComparison.OrdinalIgnoreCase))
                        return input;

                Console.WriteLine(errorMsg);

            }//end loop

        }//end method

        public static char promptChar(string prompt, string errorMsg) {
            //This method modified from a previous java method I had written. 

            string input;//Put string outside the loop for efficiency. 

            while (true)//Loop until the user gets the input right. 
            {
                Console.Write(prompt);

                input = Console.ReadLine();

                return input[0];

                Console.WriteLine(errorMsg);

            }//end loop

        }//end method

        public static char promptChar(string prompt, string errorMsg,
            char[] options) {
            //This method modified from a previous java method I had written. 

            string input;//Put string outside the loop for efficiency. 

            while (true) {//Loop until the user gets the input right. 

                Console.Write(prompt);

                input = Console.ReadLine();

                //Will only return when input matches something in the list. 
                foreach (char ch in options)
                    if (char.ToUpper(input[0]) == char.ToUpper(ch))
                        return input[0];

                Console.WriteLine(errorMsg);

            }//end loop

        }//end method

        public static double promptDouble(string prompt, string errorMsg) {
            while (true) {
                try {
                    Console.Write(prompt);
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex) {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

        public static int promptInt32(string prompt, string errorMsg) {
            while (true) {
                try {
                    Console.Write(prompt);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex) {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

        public static int promptInt32(string prompt, string errorMsg, int start, int end) {
            int val;
            while (true) {
                try {
                    Console.Write(prompt);
                    val = Convert.ToInt32(Console.ReadLine());
                    if (val >= start && val <= end)
                        return val;
                    else
                        throw new Exception("Not within bounds... ");
                }
                catch (Exception ex) {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

    }//end class

}//end namespace
