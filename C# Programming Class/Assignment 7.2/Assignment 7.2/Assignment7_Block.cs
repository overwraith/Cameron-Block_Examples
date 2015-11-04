/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 7.2
 * Purpose: to create an employee management program. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_7._2 {

    class Assignment7_Block {

        static void Main(string[] args) {

            Employee[] employees = new Employee[5];
            int id;
            double salary;

            for (int i = 0; i < employees.Length; i++) {

                try {
                    Console.Write("Enter ID number: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter hourly salary: ");
                    salary = Convert.ToDouble(Console.ReadLine());

                    employees[i] = new Employee(id, salary);

                    Console.WriteLine();//add a newline so prompt is easier to read
                }
                catch (Exception ex) {//accepts both ArgumentExceptions, and FormatExceptions
                    Console.WriteLine(ex.Message);
                    employees[i] = new Employee(999, 6.00);
                    Console.WriteLine();//add a newline so prompt is easier to read
                    //i--;//this would allow repeat entry of the error entries
                }
            }//end loop

            foreach (Employee emp in employees)
                Console.WriteLine(emp.ToString());

            Console.WriteLine();
            pause();
        }//end main

        public static void pause() {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }

    }//end class

    public class Employee {
        int IDNum;
        double hourlyWage;

        public Employee(int IDNum, double hourlyWage) {
            if (hourlyWage < 6.00 || hourlyWage > 50.00) { throw new ArgumentException(); }

            this.IDNum = IDNum;
            this.hourlyWage = hourlyWage;
        }

        public override string ToString() {
            return String.Format("Employee # {0} pay rate {1:C}", this.IDNum, this.hourlyWage);
        }
    }//end class

}//end namespace
