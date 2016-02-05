/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JaggedTest {

    class Program {

        static void Main(string[] args) {
            int[][] jagged = new int[3][];

            //set up initial jagged array
            jagged[0] = new int[] { 1, 0, -1};
            jagged[1] = new int[] { 0, 1, 2};
            jagged[2] = new int[] { 0, 0, 0};

            Console.WriteLine("Original jagged array...");
            jagged.PrintArray();
            Console.WriteLine();

            //swapping operation
            GenericSwapper.Swap(ref jagged[0], ref jagged[1]);

            Console.WriteLine("Rows have been swapped...");
            jagged.PrintArray();
            Console.WriteLine();

            int[,] twoDArr = new int[,] { { 0, 1, 2, 3, 4 }, 
                                          { 5, 6, 7, 8, 9 }, 
                                          { 10, 11, 12, 13, 14} };

            Console.WriteLine("Our brand new 2d array...");
            twoDArr.PrintArray();
            Console.WriteLine();

            Console.WriteLine("Our 2d array converted to a jagged one... ");
            int[][] jagged2 = twoDArr.ToJagged();
            jagged2.PrintArray();
            Console.WriteLine();

            Console.WriteLine("Our jagged array converted back to a 2d one... ");
            jagged2.To2DArray().PrintArray();
            Console.WriteLine();

            //print a line of 80 asteristics to break up the screen
            //  (80 is length of CLI screen)
            for (int i = 0; i < 80; i++)
                Console.Write('*');

            RowEchilonForm(jagged);
            bool coeffIsOne = CoefficientIsOne(jagged);

            Console.WriteLine((coeffIsOne) ? "Coefficient is one..." : "Coefficient is not one...");

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main

        private static void RowEchilonForm(int[][] jagged) {
            //put the rows in the correct order
            IEnumerable<int[]> query = jagged.OrderByDescending(row => row[0]).ThenBy(row => row[1]);
            int i = 0;
            foreach (int[] row in query) {
                jagged[i] = row;
                row.PrintArray();
                Console.WriteLine();
                i++;
            }//end loop
        }//end method

        public static bool CoefficientIsOne(int[][] jagged) {
            //Every leading coefficient has to be 1
            //Testing for leading zeros and ones at the same time
            int rowLen = jagged.Length;
            int colLen;
            bool coeffIsOne = true;
            for (int i = 0; i < rowLen && coeffIsOne; i++) {
                colLen = jagged[i].Length;
                for (int j = 0; j < colLen; j++) {
                    if (jagged[i][j] == 1) {
                        break;
                    }
                    else if (jagged[i][j] != 0) {
                        coeffIsOne = false;
                        break;
                    }
                }//end loop
            }//end loop
            return coeffIsOne;
        }//end method

    }//end class

    public static class GenericSwapper {
        public static void Swap<T>(ref T left, ref T right) {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }//end method
    }//end class

    public static class ArrayUtil {

        public static IEnumerable<int[]> OrderByMatrixRows(this int[][] jagged) {

            var query = jagged.OrderByDescending(row => row[0]);
            for (int i = 1; i < jagged.Length; i++) {
                query = query.ThenBy(row => row[i]);
            }//end loop

            return query;

        }//end method

        public static T[][] ToJagged<T>(this T[,] array){

            int rowLen = array.GetLength(0);
            int colLen = array.GetLength(1);

            T[][] jagged = new T[rowLen][];
            List<T> ctRow = new List<T>();

            for (int i = 0; i < rowLen; i++) {
                for (int j = 0; j < colLen; j++)
                    ctRow.Add(array[i, j]);

                jagged[i] = ctRow.ToArray();
                ctRow = new List<T>();
            }//end loop

            return jagged;

        }//end method

        public static T[,] To2DArray<T>(this T[][] array) {

            int rowLen = array.Length;
            //int colLen;

            //make sure that the jagged array's rows are all the same length
            int colLen = array[0].Length;
            for(int i = 0; i < rowLen; i++)
                if(array[i].Length != colLen)
                    throw new ArgumentException("All the rows lengths must be the same for conversion to take place. ");

            T[,] twoDArr = new T[rowLen,colLen];

            for (int i = 0; i < rowLen; i++) {
                colLen = array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                    twoDArr[i, j] = array[i][j];
            }//end loop

            return twoDArr;

        }//end method

        //1 dimensional print array
        public static void PrintArray<T>(this T[] array) {

            //int rowLen = array.GetLength(0);
            int colLen = array.Length;

            for (int i = 0; i < colLen; i++) {
                Console.Write("{0,-5:s}", array[i] + ( i < colLen - 1 ? ", " : "" ));
            }//end loop

        }//end method

        //2 dimensional print array
        public static void PrintArray<T>(this T[,] array){

            int rowLen = array.GetLength(0);
            int colLen = array.GetLength(1);

            for (int i = 0; i < rowLen; i++) {
                for (int j = 0; j < colLen; j++)
                    Console.Write("{0,-5:s}", array[i, j] + ( j < colLen - 1 ? ", " : "" ));

                Console.Write('\n');
            }//end loop

        }//end method

        //Jagged print array
        public static void PrintArray<T>(this T[][] array) {

            int rowLen = array.Length;
            int colLen;

            for (int i = 0; i < rowLen; i++) {
                colLen = array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write("{0,-5:s}", array[i][j] + ( j < colLen - 1 ? ", " : "" ));

                Console.Write('\n');
            }//end loop

        }//end method

    }//end class

    public static class GenericCopier<T> {    //deep copy a list
        public static T DeepCopy(object objectToCopy) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, objectToCopy);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }//end method
    }//end class

}//end namespace
