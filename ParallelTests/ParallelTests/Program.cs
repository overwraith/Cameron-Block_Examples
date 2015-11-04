/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParallelTests {

    class Program {

        static void Main(string[] args) {
            int i = 0;
            ParallelExt.For(
                i + 1,                                          //Start value. 
                j => j != i,                                    //Comparison operation. 
                j => { Console.WriteLine("Counter: " + j); },   //Loop body. 
                (ref int j) => { if (j == 10) { j = -1; } });   //Loop conclusion. 

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }//end main

    }//end class

    public static class ParallelExt {

        public delegate void LoopConclusion(ref int counter);
        public delegate void LoopBody(int counter);
        public delegate bool LoopConditional(int counter);

        //method for wrap around for loops, 0, 1, 2, 3, 4, ..., 0, 1, 2, 3
        public static void For(int start, LoopConditional condition, LoopBody body, LoopConclusion conclusion) {
            var events = new List<ManualResetEvent>();

            for (int i = start, j = 0; condition.Invoke(i); i++, j++) {
                var resetEvent = new ManualResetEvent(false);

                ThreadPool.QueueUserWorkItem((arg) => {
                    int value = (int)arg;
                    body.Invoke(value);
                    resetEvent.Set();
                }, i);
                events.Add(resetEvent);
                conclusion.Invoke(ref i);
            }//end loop

            WaitHandle.WaitAll(events.ToArray());
            
        }//end method

    }//end class

}//end namespace
