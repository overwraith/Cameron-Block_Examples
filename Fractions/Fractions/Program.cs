/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractions {

    class Program {

        static void Main(string[] args) {
            Fraction frac1 = new Fraction(2, 9);
            Fraction frac2 = new Fraction(3, 9);

            Console.WriteLine((frac1 + frac2).ToString());

            Fraction frac3 = new Fraction(21, 4);
            frac3.Reduce();
            Console.WriteLine(frac3);

            Console.WriteLine(new Fraction(1, 1, 2) * new Fraction(2, 1, 5));

            Console.WriteLine(new Fraction(3, 4) - new Fraction(1, 4));

            Console.WriteLine(new Fraction(1, 2) / new Fraction(1, 6));

            Console.ReadLine();
        }//end main

    }//end class

    public class Fraction{
        private int denominator;

        public int WholeNum { get; set; }

        public int Numerator { get; set; }

        public int Denominator {
            get { return denominator; }
            set {
                if (value == 0)
                    throw new ArgumentException("Denominator cannot allow a zero value. ");
                else
                    denominator = value;
            }
        }//end property
        
        public Fraction() {
            this.WholeNum = 0;
            this.Numerator = 0;
            this.Denominator = 1;//can't be zero
        }//end constructor
        
        public Fraction(int num, int denom) {
            this.WholeNum = 0;
            this.Numerator = num;
            this.Denominator = denom;
        }//end constructor

        public Fraction(int wholeNum, int num, int denom) {
            this.WholeNum = wholeNum;
            this.Numerator = num;
            this.Denominator = denom;
        }//end constructor

        public void Reduce() {
            int gcf = GCD(Numerator, Denominator);
            Numerator /= gcf;
            Denominator /= gcf;

            if (Numerator > Denominator) {
                WholeNum = (int)Math.Truncate((Double)Numerator / (Double)denominator);
                Numerator %= Denominator;
            }
        }//end method

        //Greatest Common Divisor
        private static int GCD(int a, int b) {
            return b == 0 ? a : GCD(b, a % b);
        }//end method

        public override string ToString() {
            if (WholeNum != 0) {
                if (this.Numerator != 0) {
                    return this.WholeNum + " " + this.Numerator + " / "
                        + this.Denominator;
                }
                else
                    return this.WholeNum + "";
            }
            else
                return this.Numerator + " / " + this.Denominator;
        }//end method

        //this method isn't as glamorous as something on code project, but it works
        public static Fraction operator +(Fraction frac1, Fraction frac2) {
            Fraction result;

            int wholeNum = frac1.WholeNum + frac2.WholeNum;
            int num;
            int denom;

            if (frac1.Denominator == frac2.Denominator) {
                num = frac1.Numerator + frac2.Numerator;
                denom = frac1.Denominator;
            }
            else {
                int gcd = GCD(frac1.Denominator, frac2.Denominator);
                if (frac1.Denominator > frac2.Denominator) {
                    frac2.Numerator *= gcd;
                    frac2.Denominator *= gcd;
                }
                else {
                    frac1.Numerator *= gcd;
                    frac2.Denominator *= gcd;
                }
                num = frac1.Numerator + frac2.Numerator;
                denom = frac1.Denominator;
            }

            result = new Fraction(wholeNum, num, denom);
            result.Reduce();

            return new Fraction(wholeNum, num, denom);
        }//end operator

        //this method isn't as glamorous as something on code project, but it works
        public static Fraction operator -(Fraction frac1, Fraction frac2) {
            Fraction result;

            int wholeNum = frac1.WholeNum - frac2.WholeNum;
            int num;
            int denom;

            if (frac1.Denominator == frac2.Denominator) {
                num = frac1.Numerator - frac2.Numerator;
                denom = frac1.Denominator;
            }
            else {
                int gcd = GCD(frac1.Denominator, frac2.Denominator);
                if (frac1.Denominator > frac2.Denominator) {
                    frac2.Numerator *= gcd;
                    frac2.Denominator *= gcd;
                }
                else {
                    frac1.Numerator *= gcd;
                    frac2.Denominator *= gcd;
                }
                num = frac1.Numerator - frac2.Numerator;
                denom = frac1.Denominator;
            }

            result = new Fraction(wholeNum, num, denom);
            result.Reduce();

            return new Fraction(wholeNum, num, denom);
        }//end operator

        public static Fraction operator *(Fraction frac1, Fraction frac2){
            Fraction result;

            frac1.Unbalance();
            frac2.Unbalance();

            int num = frac1.Numerator * frac2.Numerator;
            int denom = frac1.Denominator * frac2.Denominator;
            
            result = new Fraction(num, denom);
            result.Reduce();

            return result;
        }//end operator

        public static Fraction operator /(Fraction frac1, Fraction frac2) {
            Fraction result;

            frac1.Unbalance();
            frac2.Unbalance();

            frac2.Recriprocal();

            int num = frac1.Numerator * frac2.Numerator;
            int denom = frac1.Denominator * frac2.Denominator;

            result = new Fraction(num, denom);
            result.Reduce();

            return result;
        }//end operator

        public void Unbalance() {
            //create unbalanced fractions
            if (WholeNum > 0) {
                Numerator += WholeNum * denominator;
                WholeNum = 0;
            }
        }//end method

        public void Recriprocal() {
            int temp = Numerator;

            Numerator = Denominator;
            Denominator = temp;
        }//end method

        public decimal ToDecimal() {
            return (decimal)WholeNum + (decimal)Numerator 
                / (decimal)Denominator;
        }//end method

        public Double ToDouble() {
            return (double)WholeNum + (double)Numerator 
                / (double)Denominator;
        }//end method

    }//end class

}//end namespace
