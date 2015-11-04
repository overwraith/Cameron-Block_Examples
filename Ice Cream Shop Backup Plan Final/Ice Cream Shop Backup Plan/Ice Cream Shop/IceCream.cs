/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using Ice_Cream_Shop;

namespace Ice_Cream_Shop {

    class IceCream : Cone {
        
        public static IceCream operator +(IceCream first, IceCream second) {
            if (first.ConeFlavor == second.ConeFlavor)
                return new IceCream(first.ConeFlavor) { NumScoops = first.NumScoops + second.NumScoops };
            else
                throw new FlavorMismatchException();
        }

        public IceCream() : base() { }

        public IceCream(String flavor) : base(flavor) { }

        public override string ToString() {
            //scoops and cost represent fairly constant data, 
            //cone flavor does not so it is put at the end of the output
            return String.Format("Ice Cream Cone: Scoops: {0}, Cone Cost: {1:C}, {2}  ", 
                numScoops, totalCost(), coneFlavor);
        }

        public override void writeToFile(String fname) {
             if (!File.Exists(fname))
                 File.Create(fname);

             FileStream outfile = new FileStream(fname, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(outfile);

            writer.WriteLine("Ice Cream Cone,{0},{1} ", numScoops, coneFlavor);

            writer.Close();
            outfile.Close();
        }

        public override void writeToFile(FileStream outfile) {

            StreamWriter writer = new StreamWriter(outfile);

            writer.WriteLine("Ice Cream Cone,{0},{1} ", numScoops, coneFlavor);

            writer.Flush();
            //writer.Close();
        }

        //variables related to the readFromFile() method
        static FileStream infile;
        static StreamReader reader;
        static bool firstRun = true;
        static String fname2;//used to determine if the file has been changed for some reason

        public override void readFromFile(String fname) {

            if (fname2 != fname) {//restart the process if the file changes
                firstRun = true;
                fname2 = fname;
            }

            try {
                if (firstRun) {
                    infile = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    reader = new StreamReader(infile);

                    firstRun = false;
                }

                String str = reader.ReadLine();
                String[] tokens = str.Split(new char[] { ',' });

                if (String.Equals(tokens[0], "Ice Cream Cone", StringComparison.OrdinalIgnoreCase)) {
                    //throws a type mismatch exception if file is bad
                    this.NumScoops = Convert.ToInt32(tokens[1]);
                    this.ConeFlavor = tokens[2];
                }
                else
                    throw new ConeTypeMismatchException();//trying to read non cone data
            }
            catch (System.IO.FileNotFoundException) { throw; }//file not found
            catch (System.NullReferenceException) {
                //something is wrong with the input file, or most likely end of file
                infile.Close();//close the readers
                reader.Close();

                infile = null;//deallocate memory
                reader = null;
                throw;//inform calling method there are no more records
            }
            catch (FormatException) { throw; }//input is not in the right format
        }//end method

        public override void readFromFile(FileStream infile) {
            try {
                //read a line, use extension class
                String str = infile.readLine();
                String[] tokens = str.Split(new char[] { ',' });

                if (String.Equals(tokens[0], "Ice Cream Cone", StringComparison.OrdinalIgnoreCase)) {
                    //throws a type mismatch exception if file is bad
                    this.NumScoops = Convert.ToInt32(tokens[1]);
                    this.ConeFlavor = tokens[2];
                }
                else {
                    //rewind the input stream, use extension class
                    infile.rewind();
                    throw new ConeTypeMismatchException();//trying to read non cone data
                }
            }
            catch (System.IO.FileNotFoundException) { throw; }//file not found
            catch (System.NullReferenceException) {
                //something is wrong with the input file, or most likely end of file
                infile.Close();//close the readers
                reader.Close();

                infile = null;//deallocate memory
                throw;//inform calling method there are no more records
            }
            catch (FormatException) { throw; }//input is not in the right format
        }//end method

    }//end class

    public class FlavorMismatchException : Exception {
        private static string msg = "Cone flavors must match. ";
        
        public FlavorMismatchException() : base(msg) { }
    }

    public class ConeTypeMismatchException : Exception {
        private static string msg = "The file contains different type of cone than what you are parsing for. ";

        public ConeTypeMismatchException() : base(msg) { }
    }

}//end namespace
