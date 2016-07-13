/*Author: Cameron Block*/
using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace TextFileLineSum {

    class Program {

        //the number of columns to sum
        const int NUM_COLUMNS = 5;
        const String F_NAME = "target.txt";

        static void Main(string[] args) {

            //sum = parser.LineOperation(Int32.TryParse, (int arg1, int arg2) => arg1 + arg2);
            
            int? sum = null;

            using (TextFieldParser parser = new TextFieldParser(F_NAME)) {
                
                parser.Delimiters = new string[] { " " };

                while ( (sum = parser.SumLine<Int32>()) != null) {
                    Console.WriteLine("Sum: " + sum);
                }//end loop

            }//end using

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main

    }//end class

    public static class TextReaderExt {

        public delegate bool TryParseDelegate<String, T>(String input, out T result);
        public delegate T OperationToPreform<T>(T arg1, T arg2);

        //does an operation summing the entire line
        public static Nullable<T> SumLine<T>(this TextFieldParser parser) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (toks != null) {

                for (int i = 0; i < toks.Length && toks[i] != ""; i++) {
                    result = (T)Convert.ChangeType(toks[i], typeof(T));
                    aggregation = (dynamic)aggregation + (dynamic)result;
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation summing the entire line
        public static Nullable<T> SumLine<T>(this TextFieldParser parser, int start) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (start < 1)
                throw new ArgumentException("Starting column is less than one. " 
                    + "Column numbers start at one. ");

            if (toks != null) {

                for (int i = start - 1; i < toks.Length && toks[i] != ""; i++) {
                    result = (T)Convert.ChangeType(toks[i], typeof(T));
                    aggregation = (dynamic)aggregation + (dynamic)result;
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation summing the entire line
        public static Nullable<T> SumLine<T>(this TextFieldParser parser, 
            int start, int end) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (start < 1)
                throw new ArgumentException("Starting column is less than one. " 
                    + "Column numbers start at one. ");

            if (end < start)
                throw new ArgumentException("End column is less than the starting column. ");

            if (toks != null) {

                for (int i = start - 1; i < toks.Length && toks[i] != "" && i < end; i++) {
                    result = (T)Convert.ChangeType(toks[i], typeof(T));
                    aggregation = (dynamic)aggregation + (dynamic)result;
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation aggregating the entire line
        public static Nullable<T> LineOperation<T>(this TextFieldParser parser,
            TryParseDelegate<String, T> func, OperationToPreform<T> operation) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (toks != null) {

                for (int i = 0; i < toks.Length && toks[i] != ""; i++) {
                    if (func.Invoke(toks[i], out result)) {
                        aggregation = operation.Invoke(aggregation.Value, result);
                    }
                    else
                        throw new IOException(typeof(T).Name + " data not found in file line "
                            + ( parser.LineNumber - 1 ) + " column " + ( i + 1 ));
                    //At this point have read one line past where we were, so LineNumber - 1
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation aggregating the entire line
        public static Nullable<T> LineOperation<T>(this TextFieldParser parser,
            TryParseDelegate<String, T> func, 
            OperationToPreform<T> operation, 
            int start) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (start < 1)
                throw new ArgumentException("Starting column is less than one. " 
                    + "Column numbers start at one. ");

            if (toks != null) {

                for (int i = start - 1; i < toks.Length && toks[i] != ""; i++) {
                    if (func.Invoke(toks[i], out result)) {
                        aggregation = operation.Invoke(aggregation.Value, result);
                    }
                    else
                        throw new IOException(typeof(T).Name + " data not found in file line "
                            + ( parser.LineNumber - 1 ) + " column " + ( i + 1 ));
                    //At this point have read one line past where we were, so LineNumber - 1
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation aggregating the entire line
        public static Nullable<T> LineOperation<T>(this TextFieldParser parser,
            TryParseDelegate<String, T> func, OperationToPreform<T> operation, 
            int start, int end) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = parser.ReadFields();

            if (start < 1)
                throw new ArgumentException("Starting column is less than one. " 
                    + "Column numbers start at one. ");

            if(end < start)
                throw new ArgumentException("End column is less than the starting column. ");

            if (toks != null) {

                for (int i = start - 1; i < toks.Length && toks[i] != "" && i < end; i++) {
                    if (func.Invoke(toks[i], out result)) {
                        aggregation = operation.Invoke(aggregation.Value, result);
                    }
                    else
                        throw new IOException(typeof(T).Name + " data not found in file line "
                            + ( parser.LineNumber - 1 ) + " column " + ( i + 1 ));
                    //At this point have read one line past where we were, so LineNumber - 1
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

        //does an operation aggregating the entire line
        public static Nullable<T> SumLine<T>(this StreamReader reader,
            TryParseDelegate<String, T> func) where T : struct {

            Nullable<T> aggregation = new T();
            T result = new T();
            String[] toks = reader.ReadLine().Split(new char[]{' '});

            if (toks != null) {

                for (int i = 0; i < toks.Length && toks[i] != ""; i++) {
                    if (func.Invoke(toks[i], out result)) {
                        aggregation = (dynamic)aggregation + (dynamic)result;
                    }
                    else
                        throw new IOException(typeof(T).Name + " data not found in file line " 
                            + "column " + ( i + 1 ));
                    //At this point have read one line past where we were, so LineNumber - 1
                }//end loop
            }//end if
            else return null;

            return aggregation;
        }//end method

    }//end class

}//end namespace
