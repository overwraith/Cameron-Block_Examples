/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ice_Cream_Shop {
    public abstract class Cone {

        //accessible to all objects instantiated from this hierarchy
        public static double CostPerScoop = .50;
        public static double CostPerCone = .75;

        //class level variables automatically private
        protected int numScoops;
        protected string coneFlavor;

        //getters and setters
        public int NumScoops {
            get { return numScoops; }
            set { numScoops = value; }
        }

        public string ConeFlavor {
            get { return coneFlavor; }
            set { coneFlavor = value; }
        }

        public Cone() : this("") { }

        public Cone(string coneFlavor) {
            numScoops = 1;
            this.coneFlavor = coneFlavor;
        }

        public abstract override string ToString();

        public abstract void writeToFile(String fname);
        
        public abstract void writeToFile(FileStream outfile);

        public abstract void readFromFile(String fname);

        public abstract void readFromFile(FileStream infile);

        public double totalCost() {
            return CostPerScoop * numScoops + CostPerCone;
        }

    }//end class

}//end namespace
