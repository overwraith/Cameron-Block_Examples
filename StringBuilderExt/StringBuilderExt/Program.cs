/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringBuilderExt;

namespace StringBuilderExt {

    class Program {

        static void Main(string[] args) {
            StringBuilder str = new StringBuilder();
            str.Append("Hello_World !!!");
            Console.WriteLine("Index is at: " + str.IndexOf("World", 1));
            Console.WriteLine("Index is at: " + str.IndexOf("H"));
            Console.WriteLine("Index is at: " + str.IndexOf("e"));
            Console.WriteLine("Index is at: " + str.IndexOf("l"));
            Console.WriteLine("Index is at: " + str.IndexOf("l", 3));
            Console.WriteLine("Index is at: " + str.IndexOf("o"));
            Console.WriteLine("Index is at: " + str.IndexOf("W"));
            Console.WriteLine("Index is at: " + str.IndexOf("o"));
            Console.WriteLine("Index is at: " + str.IndexOf("r"));
            Console.WriteLine("Index is at: " + str.IndexOf("l"));
            Console.WriteLine("Index is at: " + str.IndexOf("d"));

            Console.WriteLine("Substring 5 to end: " + str.Substring(5));

            Console.WriteLine("Substring 1, length 1: " + str.Substring(1, 1));

            StringBuilder[] strs = str.Split(new String[] { " ", "_" });

            Console.WriteLine("Does string contain Hello? " + str.Contains("Hello"));

            Console.WriteLine("Does string end with !!!? " + str.EndsWith("!!!"));

            Console.WriteLine("Last index of !: " + str.LastIndexOf("!"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }//end main

    }//end class

    public static class StringBuilderExt {

        public static int IndexOf(this StringBuilder str, String value) {
            int i = 0, j = 0;
            int startOfWord = 0;

            for (; i < str.Length; i++) {//loop over the string builder
                for (j = 0, startOfWord = i; j < value.Length; j++) {//loop over the string
                    if (str[i] == value[j]) {

                        if (j == value.Length - 1)
                            return startOfWord;
                    }
                    else {
                        break;
                    }
                }//end inner loop
            }//end outer loop

            return -1;//string not found
        }//end method

        public static int IndexOf(this StringBuilder str, String value, int start) {
            if (start > -1) {//sanity check
                int i = start, j = 0;
                int startOfWord = 0;

                for (; i < str.Length; i++) {//loop over the string builder
                    for (j = 0, startOfWord = i; j < value.Length; j++, i++) {//loop over the string
                        if (str[i] == value[j]) {

                            if (j == value.Length - 1)
                                return startOfWord;
                        }
                        else {
                            break;
                        }
                    }//end inner loop
                }//end outer loop
            }

            return -1;//string not found
        }//end method

        public static bool Contains(this StringBuilder str, String value) {
            int i = 0, j = 0;
            //int startOfWord = 0;

            for (; i < str.Length; i++) {//loop over the string builder
                for (; j < value.Length; j++) {//loop over the string
                    if (str[i] == value[j]) {

                        //if (j == 0)
                            //startOfWord = i;

                        if (j == value.Length - 1)
                            return true;
                    }
                    else {
                        break;
                    }
                }//end inner loop
            }//end outer loop

            return false;//string not found
        }//end method

        public static StringBuilder[] Split(this StringBuilder str, String[] tokens) {
            List<StringBuilder> list = new List<StringBuilder>();
            List<int> tokIndexes = new List<int>();

            StringBuilder ctVal = new StringBuilder();
            //int start = 0, end = 0;

            //get the indexes of the tokens
            for (int j = 0; j < tokens.Length; j++) {
                for (int i = 0; i < str.Length; i = tokIndexes[tokIndexes.Count - 1] + 1) {
                    //get the next token index
                    int tokIndex = str.IndexOf(tokens[j], i);
                    
                    //if index is -1 continue to next token
                    if (tokIndex == -1)
                        break;

                    //add the token index
                    tokIndexes.Add(tokIndex);

                    //i = the last token index
                }
            }

            //sort the token indexes
            tokIndexes.Sort();

            //split the string
            if (tokIndexes.Count > 0) {
                int start = 0;
                StringBuilder sub;
                for (int i = 0; i < tokIndexes.Count; start = tokIndexes[i] + 1, i++) {
                    int end = tokIndexes[i] - 1;
                    if (end - start + 1 > 0 && end > -1) {//length is greater than zero
                        sub = str.Substring(start, end - start + 1);
                        list.Add(sub);
                    }
                }//end loop

                if (str.Length - tokIndexes[tokIndexes.Count - 1] + 1 > 0) {
                    sub = str.Substring(tokIndexes[tokIndexes.Count - 1] + 1);
                    list.Add(sub);
                }
            }
            else {
                list.Add(str);
            }

            return list.ToArray();
        }//end method

        public static StringBuilder Substring(this StringBuilder str, int start) {
            StringBuilder sub = new StringBuilder();
            
            if (start > -1) {//sanity check
                //substring is from start index to end of string
                for (int i = start; i < str.Length; i++)
                    sub.Append(str[i]);
            }

            return sub;
        }//end method

        //Am keeping this more familiar substring method around just in case it is preferred. 
        //public static StringBuilder Substring(this StringBuilder str, int start, int end) {
        //    StringBuilder sub = new StringBuilder();

        //    if (start > -1 && end > start && end <= str.Length) {//sanity check
        //        //substring is from start index to end of string
        //        for (int i = start; i < end; i++)
        //            sub.Append(str[i]);
        //    }

        //    return sub;
        //}//end method

        public static StringBuilder Substring(this StringBuilder str, int start, int length) {
            StringBuilder sub = new StringBuilder();

            if (start > -1 && length > 0 ) {//sanity check
                //substring is from start index to end of string
                for (int i = start; i < str.Length && length > 0; i++, length--)
                    sub.Append(str[i]);
            }

            return sub;
        }//end method

        public static bool EndsWith(this StringBuilder str, String value) {
            for (int i = str.Length - 1, j = value.Length - 1; j >= 0; i--, j--)
                if (str[i] != value[j])
                    return false;

            return true;
        }//end method

        public static int LastIndexOf(this StringBuilder str, String value) {
            int i = str.Length - 1, j = value.Length - 1;
            int startOfWord = str.Length - 1;

            for (; i >= 0; i--) {//loop over the string builder
                for (; j >= 0; j--) {//loop over the string
                    if (str[i] == value[j]) {

                        if (j == 0)
                            startOfWord = i;

                        if (j == value.Length - 1)
                            return startOfWord;
                    }
                    else {
                        break;
                    }
                }//end inner loop
            }//end outer loop

            return -1;//string not found
        }//end method

        public static int LastIndexOf(this StringBuilder str, String value, int start) {
            if (start > -1 && start < str.Length) {
                int i = start, j = value.Length - 1;
                int startOfWord = str.Length - 1;

                for (; i >= 0; i--) {//loop over the string builder
                    for (; j >= 0; j--) {//loop over the string
                        if (str[i] == value[j]) {

                            if (j == 0)
                                startOfWord = i;

                            if (j == value.Length - 1)
                                return startOfWord;
                        }
                        else {
                            break;
                        }
                    }//end inner loop
                }//end outer loop
            }

            return -1;//string not found
        }//end method

    }//end class

}//end namespace
