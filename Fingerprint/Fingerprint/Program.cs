/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.IO;

namespace Fingerprint {

    class Program {

        static void Main(string[] args) {

            if (args.Length == 0) {
                Console.WriteLine("Fingerprint.exe -f D:\\Folder\\file -s \"The quick brown fox jumps over the lazy dog\" ...");
                return;
            }

            //process file arguments in parallel
            Parallel.For(0, args.Length, (i) => {
                if (args[i] == "-f") {
                    Console.WriteLine(HashTest(args[i + 1]));
                }
                else if (args[i] == "-s") {//string input
                    Console.WriteLine(StringTest(args[i + 1]));
                }
            });

            //Console.ReadLine();
        }//end main

        public static String HashTest(String file) {
            //call all the hash algorithims here
            HashAlgorithm[] hashes = new HashAlgorithm[3];
            StringBuilder str = new StringBuilder();
            
            hashes[0] = SHA1.Create();
            hashes[1] = MD5.Create();
            hashes[2] = SHA512.Create();

            str.Append("File: " + file + "\n\n");

            for (int i = 0; i < hashes.Length; i++) {
                str.Append(hashes[i].GetType().Name + ": \n" 
                    + BitConverter.ToString(hashes[i].ComputeHash(new FileStream(file, 
                        FileMode.Open, FileAccess.Read))) + "\n\n");
            }//end loop

            //returning a string keeps files and hashes contiguous
            return str.ToString();
        }//end method

        public static String StringTest(String input) {
            //call all the hash algorithims here
            HashAlgorithm[] hashes = new HashAlgorithm[3];
            StringBuilder str = new StringBuilder();

            hashes[0] = SHA1.Create();
            hashes[1] = MD5.Create();
            hashes[2] = SHA512.Create();

            str.Append("String: " + input + "\n\n");

            for (int i = 0; i < hashes.Length; i++) {
                str.Append(hashes[i].GetType().Name + ": \n"
                    + BitConverter.ToString(hashes[i].ComputeHash(StringToStream(input))) + "\n\n");
            }//end loop

            //returning a string keeps files and hashes contiguous
            return str.ToString();
        }//end method

        public static Stream StringToStream(String src) {
            byte[] byteArray = Encoding.UTF8.GetBytes(src);
            return new MemoryStream(byteArray);
        }//end method

    }//end class

}//end namespace
