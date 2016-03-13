/*Author: Cameron Block*/
using System;
using System.Threading.Tasks;


namespace RecursivePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                //get starting directory
                ArgParser parse = new ArgParser("d*", args);
                string directory = parse.getString('d');

                //really doesn't need to be parallel, is cool though. 
                Parallel.ForEach<String>(FileUtil.RecurseFiles(directory), (String file) => {
                    new Printer(file);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName + " -d C:\\DirectoryToPrint");
                Console.WriteLine("Prints recursively... ");
            }

        }//end main

    }//end class

}//end namespace
