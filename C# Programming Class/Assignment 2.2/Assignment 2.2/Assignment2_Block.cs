/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_2._2
{
    class Assignment2_Block
    {
        static void Main(string[] args)
        {
            Sales[] sales = new Sales[3];

            sales[0] = new Sales('A', "Andrea");
            sales[1] = new Sales('B', "Brittany");
            sales[2] = new Sales('E', "Eric");

            Sales.promptSales(sales);

            //print out each employee commission
            Sales.printSales(sales);

            pause();

        }//end main

        public static void pause()
        {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end method

    }//end class

    class Sales
    {
        char code;//character code, match to input from the console
        double saleAmt;
        double totalComm;//total commission
        string name;

        const double COMMRATE = 0.10;//commission rate

        static char[] options;

        public Sales(char code, string name)
        {
            //This constructor handles initialization of variables. 
            this.code = code;
            this.name = name;

            this.saleAmt = 0;
            this.totalComm = 0;

            if (options == null)
            {
                options = new char[1];

                options[0] = this.code;
            }
            else
            {
                //swap data from options array to temp array
                char[] temp = new char[options.Length + 1];
                Array.Copy(options, temp, options.Length);

                //reallocate the options array
                options = new char[temp.Length];

                //copy data from the temp array back into the options array
                Array.Copy(temp, options, temp.Length);

                //set the current option
                options[options.Length - 1] = this.code;
            }
        }//end constructor

        public static void promptSales(Sales[] sales)
        {
            char input;

            bool firstRun = true;

            while ( (input = Input.promptChar(
                    firstRun ? "Enter a salesperson initial: " : 
                    "Enter next salesperson or Z to quit: ", 
                    "Please enter a valid salesperson initial... ", 
                    Sales.getOptions()) ) != 'z' && input != 'Z' )
            {
                //match input to a sales person
                foreach (Sales sale in sales)
                {
                    if (char.ToUpper(sale.getCharCode()) == char.ToUpper(input))
                    {
                        //input sales amount
                        sale.accumSaleAmt(
                            Input.promptDouble("Enter amount of sale: ",
                            "Please enter a valid currency value... ") );
                    }
                }//end inner loop

                firstRun = false;
            }//end loop

        }//end method

        public static void printSales(Sales[] sales)
        {
            foreach (Sales sale in sales)
            {
                Console.WriteLine(sale.ToString());
            }//end loop
        }

        public override string ToString()
        {
            return String.Format("{0} has earned {1:C}", name, totalComm);
        }

        public void setSaleAmt(double saleAmt)
        {
            this.saleAmt = saleAmt;

            //keep track of the total commission as we enter data into the class
            totalComm += saleAmt * COMMRATE;
        }

        public void accumSaleAmt(double saleAmt)
        {
            this.saleAmt += saleAmt;

            //keep track of the total commission as we enter data into the class
            totalComm += saleAmt * COMMRATE;
        }

        public char getCharCode()
        {
            return this.code;
        }

        public static char[] getOptions()
        {
            //have to add the quit option

            //swap data from options array to temp array
            char[] temp = new char[options.Length + 1];
            Array.Copy(options, temp, options.Length);

            //reallocate the options array
            options = new char[temp.Length];

            //copy data from the temp array back into the options array
            Array.Copy(temp, options, temp.Length);

            //add the quit option
            options[options.Length - 1] = 'Z';

            return Sales.options;
        }

    }//end class

    class Input
    {
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

    }//end class

}//end namespace
