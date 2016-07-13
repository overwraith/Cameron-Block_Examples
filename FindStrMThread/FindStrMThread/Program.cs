/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using OptimizationTesting;

namespace FindStrMThread {

    class Program {

        const String FILE_NAME = "input.txt";
        const int NUM_THREADS = 10;
        const String SEARCH_STR = "exit";

        static void Main(string[] args) {
            SearchThread[] threads = new SearchThread[NUM_THREADS];
            String text = File.ReadAllText(FILE_NAME);

            OptimizationTests test = new OptimizationTests(Console.Out);
            test.NumTimes = 1;

            test.TimeAction(FindStrMThread, threads, text);


            test.TimeAction(FindStrSingleThread, text);

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main

        private static void FindStrSingleThread(String text) {
            SearchThread thread = new SearchThread(text, SEARCH_STR, 0, text.Length);
            thread.run();
            thread.thrd.Join();
            Console.WriteLine("Number of occurrances of word \"{0}\" are {1}. ", SEARCH_STR,
                thread.NumOccurrances);
        }//end method

        private static void FindStrMThread(SearchThread[] threads, String text) {
            int workLength = text.Length / NUM_THREADS;

            //run the threads
            for (int i = 0, start = 0;
                    i < NUM_THREADS;
                    i++, start += workLength) {

                //set the bounds of the string work area, if is last iteration
                //the work area may be larger or smaller. 
                //if a word happens to be in the middle of the split operation it will not be counted
                threads[i] = new SearchThread(text, SEARCH_STR, start,
                    ( i != NUM_THREADS - 1 ) ? workLength : text.Length - start);
                threads[i].run();
            }//end loop

            //wait for the threads to stop
            Parallel.For(0, NUM_THREADS, (int i) => {
                threads[i].thrd.Join();
            });

            Console.WriteLine("Number of occurrances of word \"{0}\" are {1}. ", SEARCH_STR,
                SearchThread.CountOccurrances(threads));
        }//end method

    }//end class

    public class SearchThread {
        String search = null;
        String text = null;
        int start = 0;
        int length = 0;
        public Thread thrd;

        public int NumOccurrances {
            get;
            private set;
        }

        public SearchThread(String text, String search, int start, int length) {
            //substr = text.Substring(start, length);
            this.text = text;
            this.start = start;
            this.length = length;
            this.search = search;
        }//end constructor

        public void run() {
            thrd = new Thread(new ThreadStart( () => {
                //lazy execution
                foreach (String tok in text.NextSplit(new char[] { ' ', '\r', '\n' }, start, length))
                    if (tok.ToLower() == search)
                        NumOccurrances++;
            } ));

            thrd.Start();
        }//end method

        public static int CountOccurrances(SearchThread[] threads){
            //accumulate the total number of occurrances
            int total = 0;
            for (int i = 0; i < threads.Length; i++)
                total += threads[i].NumOccurrances;

            return total;
        }//end method

    }//end class

    public static class StringExt {

        //Some people on Code Project helped me with these methods (tinstaafl)
        //but making a split function which was lazily executed was my idea. 
        public static IEnumerable<String> NextSplit(
            this string str, char[] delimiters) {
            int nextIndex = 0;
            int lastIndex = 0;
            while (nextIndex != -1) {
                nextIndex = str.IndexOfAny(delimiters, lastIndex);
                if (nextIndex != -1) {
                    yield return str.Substring(lastIndex, nextIndex - lastIndex);
                    lastIndex = nextIndex + 1;
                }
                else {
                    yield return str.Substring(lastIndex);
                }
            }//end loop
        }//end method

        public static IEnumerable<String> NextSplit(
            this string str, char[] delimiters, int start) {
            int nextIndex = 0;
            int lastIndex = start;
            while (nextIndex != -1) {
                nextIndex = str.IndexOfAny(delimiters, lastIndex);
                if (nextIndex != -1) {
                    yield return str.Substring(lastIndex, nextIndex - lastIndex);
                    lastIndex = nextIndex + 1;
                }
                else {
                    yield return str.Substring(lastIndex);
                }
            }//end loop
        }//end method

        public static IEnumerable<String> NextSplit(
            this string str, char[] delimiters, int start, int length) {
            int nextIndex = 0;
            int lastIndex = start;
            int limit = start + length;

            while (nextIndex != -1) {
                nextIndex = str.IndexOfAny(delimiters, lastIndex);
                if (nextIndex != -1) {
                    if (nextIndex < limit) {
                        yield return str.Substring(lastIndex, nextIndex - lastIndex);
                        lastIndex = nextIndex + 1;
                    }
                    else {
                        yield return str.Substring(lastIndex, limit - lastIndex);
                        break;
                    }
                }
                else {
                    yield return str.Substring(lastIndex, limit - lastIndex);
                }
            }//end loop
        }//end method

    }//end class

}//end namespace
