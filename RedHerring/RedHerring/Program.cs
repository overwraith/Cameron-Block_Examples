/*Author: Cameron Block
  Purpose: Create a program that creates red herring "encrypted" files. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;//Parallel class

namespace RedHerring {

    class Program {

        static void Main(string[] args) {
            //bin files are usually encrypted
            List<BinaryWriter> bw = new List<BinaryWriter>();
            List<long> size = new List<long>();
            long temp = 0;

            if (args.Length == 0) {
                Console.WriteLine("RedHerring.exe -f D:\\Folder\\Encrypt.bin -s 12kb");
                Console.WriteLine("Supports up to Gb ranges, and multiple files. ");
                //Console.ReadLine();
                return;
            }

            try {
                for (int i = 0; i < args.Length; i++) {
                    if (args[i] == "-f") {//file
                        bw.Add(new BinaryWriter(File.Create(args[i + 1], 2048, FileOptions.None)));
                        size.Add(40);//default size of 40 bytes
                    }
                    else if (args[i] == "-s") {//size
                        Int64.TryParse(args[i + 1].Substring(0, args[i + 1].Length - 2), out temp);
                        
                        if (temp == 0)
                            throw new ArgumentException("Could not convert size value. ");

                        //convert input to bytes
                        if (args[i + 1].ToLower().EndsWith("kb"))
                            temp *= 1024 / 4;//integers are 4 bytes
                        else if (args[i + 1].ToLower().EndsWith("mb"))
                            temp *= 1024 * 1024 / 4;
                        else if (args[i + 1].ToLower().EndsWith("gb"))//don't ever use this one
                            temp *= 1024 * 1024 * 1024 / 4;

                        size[size.Count - 1] = temp;
                    }
                }//end loop
            }catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }

            //write the random content to the files
            Parallel.For(0, bw.Count, (i) => {
                RandomContent(bw[i], size[i]);
            });

        }//end main

        static Random rand = new Random();//using a class level random is better than using a local one
        public static void RandomContent(BinaryWriter bin, long size){
            for (; size > 0; size--)
                bin.Write(rand.Next());
        }//end method

    }//end class

}//end namespace
