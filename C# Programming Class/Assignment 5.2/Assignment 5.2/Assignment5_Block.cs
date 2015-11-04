/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 5.2
 * Purpose: To create tax payer software for a class assignment. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_5._2 {

    class Assignment5_Block {

        static void Main(string[] args) {

            Taxpayer[] people = new Taxpayer[5];
            string ssn;
            double grossIncome = 0;

            //instantiate an array of 5 taxpayer objects
            for (int i = 0; i < people.Length; i++)
                people[i] = new Taxpayer();

            /* implement a for loop that will prompt the user to enter the 
             * social security number and gross income*/
            for (int i = 0; i < people.Length; i++) {
                ssn = Input.promptString("Enter Social Security Number for taxpayer " + (i + 1) + ": ",
                    "Please enter something into the prompt... ");
                grossIncome = Input.promptDouble("Enter gross income for taxpayer " + (i + 1) + ": ",
                    "Please enter a valid currency value... ");

                people[i].SSN = ssn;

                //are we supposed to call Taxpayer.getRates() here? 
                people[i].YearlyGross = grossIncome;

                Console.WriteLine();
            }

            //implement a for loop that will display each object as a formatted taxpayer SSN, income, and calculated tax
            for (int i = 0; i < people.Length; i++)
                Console.WriteLine(string.Format("Taxpayer # {0} SSN: {1} income: {2:C} Tax is: {3:C}", (i + 1), people[i].SSN, people[i].YearlyGross, people[i].TaxOwed));

            Console.WriteLine();

            //implement a for loop that will sort the five objects in order by the amount of tax owed and then display each object as formatted taxpayer SSN, income, and calculated tax
            Array.Sort(people);
            for (int i = 0; i < people.Length; i++)
                Console.WriteLine(string.Format("Taxpayer # {0} SSN: {1} income: {2:C} Tax is: {3:C}", (i + 1), people[i].SSN, people[i].YearlyGross, people[i].TaxOwed));

            pause();
        }//end main

        public static void pause() {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }
    }//end class

    public class Rates {
        //read only accessor
        public double limit, lowRate, highRate;

        //read only accessor
        public double Limit {
            get {
                return limit;
            }
        }

        //read only accessor
        private double LowRate {
            get {
                return lowRate;
            }
        }

        //read only accessor
        private double HighRate {
            get {
                return highRate;
            }
        }

        //constructor
        public Rates() {
            limit = 30000;
            lowRate = .15;
            highRate = .28;
        }

        public Rates(double limit, double lowRate, double highRate) {
            this.limit = limit;
            this.lowRate = lowRate;
            this.highRate = highRate;
        }

        public double calculateTax(double income) {
            if (income < limit)
                return income * lowRate;

            //if we reach this statement, then income is greater than or equal to the limit
            return income * highRate;
        }
    }//end class

    public class Taxpayer : IComparable {
        private string ssn;//social security number
        private double yearlyGross;
        private double taxOwed;

        //get and set accessors
        public string SSN {
            get {
                return ssn;
            }
            set {
                ssn = value;
            }
        }

        //get and set accessors
        public double YearlyGross {
            get {
                return yearlyGross;
            }
            set {
                yearlyGross = value;

                //this calculates tax every time income is set
                //a rate object is required to calculate the tax, so a call to the getRates() method is made
                this.getRates();
            }
        }

        //read only accessor
        public double TaxOwed {
            get {
                return taxOwed;
            }
        }

        //implement the CompareTo method mandated by IComparable
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Taxpayer other = obj as Taxpayer;

            if (other != null)
                return this.taxOwed.CompareTo(other.taxOwed);
            else
                throw new ArgumentException("Object is not a TaxPayer");
        }

        public void getRates() {
            Rates rates;
            double incomeLimit = 0, lowRate, highRate;

            //prompt the user to enter a selection for either default settings or user input settings
            char ch = Input.promptChar(
                "Do you want default values (enter D) or enter your own (enter O)? ",
                "Please enter a valid character value... ", new char[] { 'D', 'O' });

            if (char.ToUpper(ch) == 'D') {
                rates = new Rates();

                this.taxOwed = rates.calculateTax(yearlyGross);
            }
            else {//has to be 'O'

                incomeLimit = Input.promptDouble("Enter the dollar limit: ",
                    "Please enter a valid currency value... ");
                lowRate = Input.promptDouble("Enter the low rate: ",
                    "Please enter a valid decimal value... ");
                highRate = Input.promptDouble("Enter the high rate: ",
                    "Please enter a valid decimal value... ");

                rates = new Rates(incomeLimit, lowRate, highRate);

                this.taxOwed = rates.calculateTax(yearlyGross);
            }
        }

        //public override string ToString()
        //{
        //    return string.Format("SSN: {0} income: {1:C} Tax is: {2:C}", this.ssn, this.yearlyGross, this.taxOwed);
        //}
    }//end class

    class Input {

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
}
