/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace OptimizationTesting {

    //public class Program {

    //    static void Main(string[] args) {
    //        //***Slowest***
    //        //Network
    //        //Hard Disk (Reads faster than writes)
    //        //RAM
    //        //Processor
    //        //***Fastest***

    //        OptimizationTests opt = new OptimizationTests(Console.Out);
    //        opt.NumTimes = 1;
    //        Console.WriteLine(opt);

    //        WebClient client = new WebClient();
    //        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

    //        //Network call
    //        opt.NumTimes = 1;
    //        opt.TimeFunc(client.OpenRead, "http://www.daniweb.com/");

    //        //Hard Disk Write
    //        opt.NumTimes = 5;
    //        opt.TimeAction(WriteTextFile);

    //        //Hard Disk Read
    //        opt.TimeFunc(File.ReadAllText, "Something.txt");

    //        //RAM/Processor
    //        int[] arr = OptimizationTests.RandArray(10000, 0, 10);
    //        //opt.TimeOperation((int[] list) => {
    //        //    Array.Sort(list);
    //        //    return list;
    //        //}, arr);

    //        opt.TimeAction(Array.Sort, arr);

    //        Console.Write("Press any key to continue... ");
    //        Console.ReadLine();
    //    }//end main

    //    public static void WriteTextFile() {
    //        StreamWriter writer = new StreamWriter(
    //            new BufferedStream(
    //                new FileStream("Something.txt", FileMode.Create, 
    //                    FileAccess.Write, FileShare.ReadWrite)));

    //        for (int i = 0; i < 1000; i++)
    //            writer.WriteLine("This is some text...");

    //        writer.Flush();
    //        writer.Close();
    //    }//end method
    //}//end class

    public class OptimizationTests {

        public int NumTimes = 100;
        private object consoleLock;

        public OptimizationTests(object con) {
            this.consoleLock = con;
        }//end method

        public override String ToString() {
            //Prints relivant info on the computer the program is currently executing on
            StringBuilder str = new StringBuilder();

            str.Append("Operating Sys: " + Environment.OSVersion + "\n");
            str.Append("Machine Name: " + Environment.MachineName+ "\n");
            str.Append("Domain Name: " + Environment.UserDomainName+ "\n");
            str.Append("64 bit process: " + Environment.Is64BitProcess+ "\n");
            str.Append("64 bit OS: " + Environment.Is64BitOperatingSystem+ "\n");
            str.Append("Processor Architecture: " + System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")+ "\n");
            str.Append("Processor Identifier: " + System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") + "\n");
            str.Append("Processor Count: " + Environment.ProcessorCount + "\n");

            return str.ToString();
        }//end method

        public TResult TimeFunc<TResult>(Func<TResult> func) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);
            
            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke();
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        public TResult TimeFunc<T1, TResult>(Func<T1, TResult> func, T1 arg1) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke(arg1);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        public TResult TimeFunc<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke(arg1, arg2);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        public TResult TimeFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke(arg1, arg2, arg3);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        public TResult TimeFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke(arg1, arg2, arg3, arg4);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        public TResult TimeFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();
            TResult ret = default(TResult);

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                ret = func.Invoke(arg1, arg2, arg3, arg4, arg5);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
            return ret;
        }//end method

        /*End at T16*/

        public void TimeAction(Action func) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke();
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        public void TimeAction<T1>(Action<T1> func, T1 arg1) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke(arg1);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        public void TimeAction<T1, T2>(Action<T1, T2> func, T1 arg1, T2 arg2) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke(arg1, arg2);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        public void TimeAction<T1, T2, T3>(Action<T1, T2, T3> func, T1 arg1, T2 arg2, T3 arg3) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke(arg1, arg2, arg3);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        public void TimeAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke(arg1, arg2, arg3, arg4);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        public void TimeAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
            Stopwatch sw = new Stopwatch();
            TimeSpan avgTime = new TimeSpan();

            for (int i = 0; i < NumTimes; i++) {
                sw.Start();
                func.Invoke(arg1, arg2, arg3, arg4, arg5);
                sw.Stop();
            }//end loop
            avgTime = TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds / NumTimes);

            lock (consoleLock)
                Console.WriteLine(func.Method.Name + " - Average Elapsed Time: "
                    + avgTime.ToString());
        }//end method

        //the random method is mine
        private static Random rand = new Random();//using a class level random more random than a local one
        public static int[] RandArray(int length, int min, int max) {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = rand.Next(min, max);

            return array;
        }//end method

    }//end class

}//end namespace
