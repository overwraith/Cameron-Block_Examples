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

namespace Ice_Cream_Shop {
    public class Customer : IComparable {
        //may not have data about the same customer in your file more than once
        string lname;
        string fname;
        int id;

        private static int nextID = 1;//iterator, used to assign id number

        //getters and setters
        public string Lname {
            get { return lname; }
            set { lname = value; }
        }

        public string Fname {
            get { return fname; }
            set { fname = value; }
        }

        public int ID {
            get { return id; }
            set { id = value; }
        }

        public Customer(string fname, string lname) {
            ID = nextID;
            nextID++;

            Fname = fname;
            Lname = lname;
        }

        public Customer(int id, string fname, string lname) {//used when reading from the file
            ID = id;

            if (nextID <= id) { nextID = id + 1; }//make sure to set the auto generated ID to one more than the largest ID in the file

            Fname = fname;
            Lname = lname;
        }

        public override string ToString() {//use for printing to the command prompt, change as needed
            return string.Format("Customer #{0}: {1}, {2}", id, lname, fname);
        }

        public static Customer getCustomer() {
            String errorMsg = "Please enter something at the prompt... ";

            String fname = Input.promptString("Please enter customer first name: ", errorMsg);
            String lname = Input.promptString("Please enter Customer last name: ", errorMsg);

            return new Customer(fname, lname);
        }

        //implement the CompareTo method mandated by IComparable
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Customer other = obj as Customer;

            if (other != null)
                return this.id.CompareTo(other.id);
            else
                throw new ArgumentException("Object is not a Customer");
        }

        public static ArrayList readCustomersFromFile(string fname) {
            ArrayList customers = new ArrayList();

            if (File.Exists(fname)) {//read from file
                FileStream inFile = new FileStream(fname, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                String record;
                int i = 0;
                while ((record = reader.ReadLine()) != null) {
                    string[] fields = record.Split(',');//split the fields around ','

                    //initialize a new object
                    customers.Add(new Customer(Convert.ToInt32(fields[0].Trim()),
                        fields[1].Trim(), fields[2].Trim()));

                    //increment the array position
                    i++;
                }
                reader.Close();
                inFile.Close();
            }
            else {
                throw new FileNotFoundException("File " + fname + " does not exist... ");
            }

            return customers;
        }//end method

        public void writeToFile(String fname) {
            if (!File.Exists(fname))
                File.Create(fname);

            FileStream outfile = new FileStream(fname, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(outfile);

            //write the customer data to the file
            writer.WriteLine(String.Format("{0},{1},{2}", this.ID, this.fname, this.lname));

            writer.Close();
            outfile.Close();
        }

        public static void writeCustomersToFile(string fname, ArrayList customers) {
            /* In a real world situation I would not want to overwrite the file each time I 
             * had to record the customers this is just a class room example though. */

            if (!File.Exists(fname))
                File.Create(fname);

            FileStream outFile = new FileStream(fname, FileMode.Create, FileAccess.Write);//overwrite the existing file
            StreamWriter writer = new StreamWriter(outFile);

            foreach (Customer cust in customers)
                writer.WriteLine("{0},{1},{2}", cust.ID, cust.Fname, cust.Lname);

            writer.Close();
            outFile.Close();

        }//end method

        public static void AddCustomer(ArrayList customers, ref Customer newCust) {
            //method that adds a new customer to the array list unless there is a duplicate name
            //if there is a duplicate name, then it deletes the new customer and throws an exception. 
            foreach (Customer cust in customers)
                if (cust.Fname == newCust.Fname && cust.Lname == newCust.Lname) {//already using compareTo for sorting
                    newCust = null;
                    throw new ArgumentException("Customer " + cust.ID + " " + cust.Fname + " " + cust.Lname + " already exists. ");
                }

            customers.Add(newCust);
        }//end method

    }//end class

}//end namespace