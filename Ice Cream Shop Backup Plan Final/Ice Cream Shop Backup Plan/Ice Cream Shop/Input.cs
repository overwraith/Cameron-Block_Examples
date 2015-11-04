/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ice_Cream_Shop {
        
    public class Input {

            public static string promptString(string prompt, string errorMsg) {
                //This method modified from a previous java method I had written. 

                string input;//Put string outside the loop for efficiency. 

                while (true) {//Loop until the user gets the input right. 
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

                while (true) {//Loop until the user gets the input right. 
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

                while (true) {//Loop until the user gets the input right. 
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
