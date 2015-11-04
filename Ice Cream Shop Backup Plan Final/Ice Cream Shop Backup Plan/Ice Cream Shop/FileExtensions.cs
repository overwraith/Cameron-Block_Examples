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
using System.IO;
using System.Collections;

namespace Ice_Cream_Shop {
    public static class FileExtensions {

        public static long position = 0;

        public static String readLine(this FileStream infile) {
            char ch;
            ArrayList arr = new ArrayList();

            position = infile.Position;

            if (infile.Position == infile.Length)
                throw new System.NullReferenceException();//end of file

            //infile.ReadByte();//throw away next newline character
            while (( ( ch = Convert.ToChar(infile.ReadByte()) ) != '\n' )
                && ( infile.Position < infile.Length )) {
                if(ch != '\r')//FileStream does not automatically remove carriage returns
                    arr.Add(ch);
            }

            return new String((char[])arr.ToArray(typeof(char)));
        }//end method

        public static void rewind(this FileStream infile) {
            infile.Position = position;//rewind
        }

    }//end class
}//end namespace