/*Author: Cameron Block
  Purpose: to create a class for handling CLI argument parsing. 
*/
using System;

namespace ArgParser {
    class Program {
        static void Main(string[] args) {
            try {
                ArgParser parse = new ArgParser("l,p#,d*", args);
                bool logging = parse.getBoolean('l');
                int port = parse.getInt('p');
                string directory = parse.getString('d');

                Console.WriteLine("Logging: " + logging);
                Console.WriteLine("Port Number: " + port);
                Console.WriteLine("Directory: " + directory);
            }
            catch (ArgsException e){
                Console.WriteLine("Argument error: {0}", e.errorMessage());
            }

            Console.WriteLine("Parse successful!");

            //if debugger is attached, want to pause the output at the very end
            if ( System.Diagnostics.Debugger.IsAttached ) {
                Console.Write("Press any key to continue... ");
                Console.ReadLine();
            }

        }//end main

    }//end class

}//end namespace
