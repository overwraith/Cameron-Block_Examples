/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

namespace Ice_Cream_Shop {

    public class Order {

        int orderNum;
        Customer cust;
        Cone[] cones = new Cone[10];//max cone number is 10 cones
        double totalPrice;

        int ctCone = 0;//keeps track of how many cones are in the order object
        static int nextOrderNum = 1;//keeps track of the next order number

        public Customer Cust{
            set { cust = value; }
            get { return cust; }
        }

        public int OrderNum {
            set {
                if (nextOrderNum <= value) { nextOrderNum = value + 1; } 

                orderNum = value;
            }
        }

        public void addCone(Cone cone) {
            if (ctCone == 10) { throw new ArgumentException("Order full, cannot order any more cones. "); }

            cones[ctCone] = cone;

            totalPrice += cone.totalCost();

            ctCone++;
        }

        public static Order operator +(Order first, Cone second) {

            first.addCone(second);

            return first;
        }

        public Order() {
            this.cust = null;

            orderNum = 0;
        }

        public Order(Customer cust) {
            this.cust = cust;

            OrderNum = nextOrderNum;
            //orderNum = nextOrderNum++;
        }

        public override string ToString() {
            String str = "";

            str += String.Format("Order Number: {0}\n", orderNum);

            str += cust.ToString() + "\n\n";

            foreach(Cone cone in cones)
                if(cone != null)
                    str += cone.ToString() + "\n";

            str += "\n";

            str += String.Format("Total Price: {0:C}\n", totalPrice);

            return str;
        }

        public void writeToFile(String fname) {
            if (!File.Exists(fname))
                File.Create(fname);

            FileStream outfile = new FileStream(fname, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(outfile);

            //write the order data to the file
            writer.WriteLine(String.Format("Order,{0},{1},{2}", orderNum, cust.ID, ctCone));

            writer.Flush();

            //write the cone data to the file
            foreach (Cone cone in cones) {
                if (cone == null)
                    break;
             
                cone.writeToFile(outfile);
            }

            writer.Close();
            outfile.Close();
        }

        //variables related to the readFromFile() method
        static FileStream infile;
        static bool firstRun = true;
        static String fname2;//used to determine if the file has been changed for some reason

        public void readFromFile(String fname, ArrayList customerList) {

            if (fname2 != fname) {//restart the process if the file changes
                firstRun = true;
                fname2 = fname;
            }

            try {
                if (firstRun) {
                    infile = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    //reader = new StreamReader(infile);

                    firstRun = false;
                }

                String str = infile.readLine();
                String[] tokens = str.Split(new char[] { ',' });

                if (String.Equals(tokens[0], "Order", StringComparison.OrdinalIgnoreCase)) {
                    //then we are reading an order
                    
                    //Order,orderNum,customerNum,numCones
                    this.OrderNum = Convert.ToInt32(tokens[1]);

                    int customerNum = Convert.ToInt32(tokens[2]);//read customer number

                    foreach(Customer cust in customerList)//match customer number to customer
                        if (cust.ID == customerNum) {
                            this.cust = cust;
                            break;
                        }
                    
                    if(this.cust == null)
                        throw new IOException("Customer in input file not found. ");

                    int numCones = Convert.ToInt32(tokens[3]);

                    if (numCones > 10)
                        throw new IOException("An order contains more than 10 cones. ");

                    for (int i = 0; i < numCones; i++) {
                        try {
                            //try to read an ice cream cone
                            IceCream cream = new IceCream();
                            cream.readFromFile(infile);

                            this.addCone(cream);
                        }
                        catch (ConeTypeMismatchException) {
                            //else read a yogurt cone
                            Yogurt yogurt = new Yogurt();
                            yogurt.readFromFile(infile);

                            this.addCone(yogurt);
                        }
                    }//end loop
                }
                else
                    throw new IOException("Order object not encountered in file. ");//non-cone data
            }
            catch (System.IO.FileNotFoundException) { throw; }//file not found
            catch (System.NullReferenceException) {
                //something is wrong with the input file, or most likely end of file
                infile.Close();//close the file

                infile = null;//deallocate memory

                firstRun = true;
                throw;//inform calling method there are no more records
            }
            catch (FormatException) { throw; }//input is not in the right format
        }//end method

    }//end class
}//end namespace