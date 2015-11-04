/* Author: Cameron Block
 * Class: CIS353 Intermediate C# Programming
 * Assignment 1.2
 * Purpose: To create a class that averages input and demonstrate basic knowledge of C#. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assignment1_Block
{
    class assignment1_Block
    {
        static void Main(string[] args)
        {

            Average a = new Average();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter an integer value: ");
                a.averageNum(Convert.ToInt32(Console.ReadLine()));
            }//end loop

            a.getAverage();//this is unnecessary given how Average.ToString is coded

            Console.WriteLine(a);

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main
    }//end class

    class Average
    {
        public int sum = 0;//collect the sum of the integer entries
        public double average = 0;//hold the average of the sum of the 10 integers

        private int i = 0;//counts the number of time the averageNum function has been called

        public void averageNum(int input)
        {
            sum += input;
            i++;
        }//end method

        public double getAverage()//calculates the average of the numbers input
        {
            return average = (double)sum / (double)i;
        }//end method

        public override string ToString()//public class method to output the average of the numbers input
        {
            getAverage();

            //I suppose string formatting is more efficient than concatenating all those immutable strings
            return string.Format("The average is {0}, the sum of {1} numbers is {2}. ", average.ToString(), i, sum);
            //return "The average is " + average.ToString() + ", the sum of " + i + " numbers is " + sum + ". ";
        }//end method

    }//end class

}//end namespace