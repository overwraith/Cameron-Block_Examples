/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assignment_3._2
{
    class Assignment3_Block
    {
        static void Main(string[] args)
        {
            //binary search can take an account type, or an integer as a search type
            //in order to binary search though, the array needs sorted
            //Console.WriteLine(Array.BinarySearch(accts, 1));

            account[] accts = new account[2];

            //instantiating a new accounts object
            accts[0] = new account(0, "Schmoe", 0.00D);//you can overwrite these in the program's prompt
            accts[1] = new account(1, "Stutte", 1111.00D);

            accts = account.promptAccount(accts);//method to fill the accounts array with user input

            //finish the menu driven system, ask to search, average, and exit

            Console.WriteLine();

            char ch;
            //int searchNum;

            while( (ch = char.ToUpper(Input.promptChar(
                "****************************************** \n"
            + "Enter an 'a' or 'A' to search account numbers, \n"
            + "Enter a 'b' or 'B' to average the accounts, \n"
            + "Enter an 'x' or 'X' to exit the program. \n"
            + "****************************************** \n"
            + "Enter an option: ", 
            "\nPlease enter valid character data... ", 
            new char[]{'A', 'B', 'X'}))) != 'X' )
            {
                Console.WriteLine();

                if(char.ToUpper(ch) == 'A')
                {
                    account.searchPrompt(accts);
                }
                else if(char.ToUpper(ch) == 'B')
                {
                    //Console.WriteLine(string.Format(
                    //    "The average dollar amount for the accounts is: {0:C}", 
                    //    account.getAverage()));
                    Console.WriteLine(string.Format(
                        "The average dollar amount for the accounts is: {0:C}",
                        account.getAverage(accts)));
                }
            }//end loop

            Console.WriteLine();


            pause();
        }//end main

        public static void pause()
        {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end method

    }//end class

    class account : IComparable
    {
        //the member variables
        private int acctNum;
        private double acctBal;
        private string acctName;

        //static variables
        private static int acctAutoNum = 0;//autonumbering set to zero the first time

        //private static double sum = 0;//the sum of all accounts
        //private static int count = 0;//the total number of accounts

        //the constructors
        public account(string acctName)//implements autonumbering
        {
            this.acctNum = acctAutoNum++;//increment after setting account number
            this.acctName = acctName;

            this.acctBal = 0D;

            //these used for determining the average in the accounts
            //sum += this.acctBal;
            //count++;
        }

        public account(int acctNum, string acctName)
        {
            this.acctNum = acctNum;
            this.acctName = acctName;

            this.acctBal = 0D;

            //these used for determining the average in the accounts
            //sum += this.acctBal;
            //count++;
        }

        public account(string acctName, double acctBal)//implements autonumbering
        {
            this.acctNum = acctAutoNum++;//increment after setting account number
            this.acctName = acctName;

            this.acctBal = acctBal;

            //these used for determining the average in the accounts
            //sum += this.acctBal;
            //count++;
        }

        public account(int acctNum, string acctName, double acctBal)
        {
            this.acctNum = acctNum;
            this.acctName = acctName;

            this.acctBal = acctBal;

            //these used for determining the average in the accounts
            //sum += this.acctBal;
            //count++;
        }

        //interface methods
        public int CompareTo(object obj)
        {//used MSDN page to figure this out
            if (obj == null) return 1;

            //if object is an integer
            if (obj is int)//allows to binary search with an account and an integer
                return this.acctNum.CompareTo((int)obj);
            else//if object is an account
            {
                account otherAcct = obj as account;
                if (otherAcct != null)
                    return this.acctNum.CompareTo(otherAcct.acctNum);
                else
                    throw new ArgumentException("Object is not an account");
            }
        }

        //the set methods
        public void setAcctNum(int acctNum)
        {
            this.acctNum = acctNum;
        }

        public void setAcctBal(double acctBal)
        {
            //if are resetting account balance, 
            //have to remove the value already assigned
            //sum -= this.acctBal;

            this.acctBal = acctBal;

            //sum += this.acctBal;
        }

        public void setAcctName(string acctName)
        {
            this.acctName = acctName;
        }

        //the get methods
        public int getAcctNum()
        {
            return acctNum;
        }
        
        public double getAcctBal()
        {
            return acctBal;
        }

        public string getAcctName()
        {
            return acctName;
        }

        //tostring method
        public override string ToString()
        {
            return String.Format(
                "Account # {0} has a balance of {1:C} for customer {2}", 
                acctNum, acctBal, acctName);
        }

        //static methods
        public static account[] promptAccount()
        {
            //This method gets input from the user and makes an array out of the results
            ArrayList accounts = new ArrayList();
            bool firstRun = true;

            do
            {
                Console.Write(firstRun ? "" : "\n" );

                int acctNum = Input.promptInt32("Enter the integer account number: ",
                    "Please Enter a valid integer... ");

                double bal = Input.promptDouble("Enter the account balance: ",
                    "Please enter a valid double... ");

                string name = Input.promptString("Enter the account holder last name: ",
                    "Please enter a valid string... ");

                accounts.Add(new account(acctNum, name, bal));

                firstRun = false;

                //the likelihood of this method erroring out is not very high
            } while (char.ToUpper(Input.promptChar("Would you like to continue?: ",
                "I don't know what you did, but that was awesome!!! ")) != 'N');

            //was a little hard to find how to do this
            return (account[])accounts.ToArray(typeof(account));
        }//end method

        public static account[] promptAccount(account[] accts)
        {
            //This method gets input from the user and makes an array out of the results
            
            ArrayList accounts = new ArrayList(accts);//send the input array to the ArrayList
            bool firstRun = true;

            do
            {
                Console.Write(firstRun ? "" : "\n");

                int acctNum = Input.promptInt32("Enter the integer account number: ",
                    "Please Enter a valid integer... ");

                double bal = Input.promptDouble("Enter the account balance: ",
                    "Please enter a valid double... ");

                string name = Input.promptString("Enter the account holder last name: ",
                    "Please enter a valid string... ");

                accounts.Add(new account(acctNum, name, bal));

                firstRun = false;

                //the likelihood of this method erroring out is not very high
            } while (char.ToUpper(Input.promptChar("Would you like to continue?: ",
                "I don't know what you did, but that was awesome!!! ")) != 'N');

            //was a little hard to find how to do this
            return (account[])accounts.ToArray(typeof(account));
        }//end method

        public static account[] promptAccountAutoNum()
        {
            //This method gets input from the user and makes an array out of the results
            ArrayList accounts = new ArrayList();

            do
            {
                //int acctNum = Input.promptInt32("Enter the integer account number: ",
                //    "Please Enter a valid integer... ");

                double bal = Input.promptDouble("Enter the account balance: ",
                    "Please enter a valid double... ");

                string name = Input.promptString("Enter the account holder last name: ",
                    "Please enter a valid string... ");

                accounts.Add(new account(name, bal));

                //return new account(name, bal);//autonumber the account number

                //the likelihood of this method erroring out is not very high
            } while (char.ToUpper(Input.promptChar("Would you like to continue?: ",
                "I don't know what you did, but that was awesome!!! ")) != 'N');

            //was a little hard to find how to do this
            return (account[])accounts.ToArray(typeof(account));
        }//end method

        public static void searchPrompt(account[] accts)
        {
            int searchNum = Input.promptInt32(
                "Enter an account number to search for: ",
                "\nPlease enter valid integer data... \n");

            Console.WriteLine();

            int acctIndex = account.unorderedSearch(accts, searchNum);

            if(acctIndex == -1)
                Console.WriteLine("You entered an invalid account... ");
            else if (accts[acctIndex] == null)//there can be null entries
                Console.WriteLine("You entered an invalid account... ");
            else
                Console.WriteLine(
                    accts[acctIndex].ToString());//find the account and print it
        }

        public static int unorderedSearch(account[] accounts, int acctNum)
        {
            for (int i = 0; i < accounts.Length; i++)
                if (accounts[i].CompareTo(acctNum) == 0)
                    return i;

            return -1;
        }

        //public static double getAverage()
        public static double getAverage(account[] accts)
        {
            //my original version accumulated the total account numbers as they were input into the class
            //return sum / (double)count;

            double avg = 0D;
            int count = 0;

            for (int i = 0; i < accts.Length; i++)
                if (accts[i] != null)//user can input null accounts
                {
                    avg += accts[i].getAcctBal();
                    count++;//determine the true number of accounts
                }

            return avg / (double)count;
        }

    }//end class

    class Input
    {

        public static string promptString(string prompt, string errorMsg)
        {
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
            string[] options)
        {
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

        public static char promptChar(string prompt, string errorMsg)
        {
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
            char[] options)
        {
            //This method modified from a previous java method I had written. 

            string input;//Put string outside the loop for efficiency. 

            while (true)//Loop until the user gets the input right. 
            {
                Console.Write(prompt);

                input = Console.ReadLine();

                //Will only return when input matches something in the list. 
                foreach (char ch in options)
                    if (char.ToUpper(input[0]) == char.ToUpper(ch))
                        return input[0];

                Console.WriteLine(errorMsg);

            }//end loop

        }//end method

        public static double promptDouble(string prompt, string errorMsg)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

        public static int promptInt32(string prompt, string errorMsg)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

        public static int promptInt32(string prompt, string errorMsg, int start, int end)
        {
            int val;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    val = Convert.ToInt32(Console.ReadLine());
                    if (val <= start && val >= end)
                        return val;
                    else
                        throw new Exception("Not within bounds... ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(errorMsg);
                }
            }

        }//end method

    }//end class

}//end namespace
