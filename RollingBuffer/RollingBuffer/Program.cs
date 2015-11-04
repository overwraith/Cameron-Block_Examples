/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//parallel for loop
using System.Threading;//Thread class

namespace RollingBuffer {
    class Program {
        static void Main(string[] args) {
            RollingBuffer<PhoneData> buffer = new RollingBuffer<PhoneData>(DateTime.Now.AddSeconds(2) - DateTime.Now, 2000);

            buffer.Add(new PhoneData { phoneNum = "555-555-5555", msg = "Hello World!" });
            buffer.Add(new PhoneData { phoneNum = "555-555-1111", msg = "Good Morning Vietnam!" });
            buffer.Add(new PhoneData { phoneNum = "555-555-2222", msg = "Hi!" });
            buffer.Add(new PhoneData { phoneNum = "555-555-3333", msg = "Howdy!" });
            buffer.Add(new PhoneData { phoneNum = "555-555-4444", msg = "Hello!" });

            for (int i = 0; i < buffer.Length; i++)
                Console.WriteLine(buffer[i].ToString());

            Console.WriteLine("Length of the buffer is " + buffer.Length);

            Console.WriteLine("Pause for a length of time... ");
            Console.ReadLine();

            Console.WriteLine("Length of the buffer is " + buffer.Length);

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main

    }//end class


    /*Attempt 1
    //dont think I implemented CollectionBase correctly, look 
    //into fixing the implementation. 

    //Want to be able to write to a file, will probably use the NSA database
    public class RollingBuffer<T> : System.Collections.CollectionBase {
        private List<Node<T>> list = new List<Node<T>>();
        private Node<T>[] nodes;
        private TimeSpan purgetime;

        public T this[int key] {
            get {
                return list.ElementAt(key).value;
            }
            set {
                //this method is going to be slow, have to convert to an array, 
                //and then set the value again, and encapsulate the array into
                //the list again. 
                nodes = list.ToArray();
                nodes[key] = new Node<T>(value, DateTime.Now);
                list = new List<Node<T>>(nodes);
            }
        }

        public TimeSpan PurgeTime {
            get { return purgetime; }
        }

        public int Length {
            get {
                purge();
                return list.Count();
            }
        }

        public int Count {
            get {
                purge();
                return list.Count();
            }
        }

        //give the constructor a timespan after which to purge the data
        public RollingBuffer(TimeSpan purgetime) {
            this.purgetime = purgetime;
        }//end constructor

        //add a node with the time of now
        public void Add(T input) {
            //purge should always appear first, since the data has not been verified yet
            purge();
            list.Add(new Node<T>(input, DateTime.Now));
        }

        //add a node with the given time
        public void Add(T input, DateTime date) {
            purge();
            list.Add(new Node<T>(input, date));
        }

        public void purge() {
            //Parallel.For(0, list.Count, i => {
            //    //if current time is past the data's purge time
            //    //get rid of the data
            //    if (DateTime.Now > list[i].date + purgetime)
            //        list.Remove(list[i]);
            //});

            //old code
            for (int i = 0; i < list.Count; i++)
                if (DateTime.Now > list[i].date + purgetime) {
                    //remove the value, subtract 1 to
                    //compensate for shift in indexes
                    list.Remove(list[i]);
                    i--;
                }

        }//end method

        new public void RemoveAt(int index) {
            //removal is the one time you don't want purge at 
            //the beginning of the method, could mess up the 
            //indexes. 
            list.RemoveAt(index);
            purge();
        }

        public class Node<T> {
            public T value;
            public DateTime date;

            public Node(T value, DateTime date) {
                this.value = value;
                this.date = date;
            }
        }//end inner class

    }//end class
    */

    public class RollingBuffer<T> : System.Collections.CollectionBase {
        private TimeSpan purgetime;
        private Thread purgethrd;

        public T this[int key] {
            get { return ( (Node<T>)List[key] ).value; }
            set {
                lock (this.List) {
                    ( (Node<T>)List[key] ).value = value;
                }
            }
        }

        public TimeSpan PurgeTime {
            get { return purgetime; }
        }

        public int Length {
            get { return List.Count; }
        }

        //give the constructor a timespan after which to purge the data
        public RollingBuffer(TimeSpan purgetime, int sleepTime) {
            this.purgetime = purgetime;

            purgethrd = new Thread(new ThreadStart(() => {
                    //purge once every so many seconds
                    while(true){
                        purge();
                        Thread.Sleep(sleepTime);
                    }
                }));

            //tell the thread to close when the application closes
            purgethrd.IsBackground = true;
            purgethrd.Start();

        }//end constructor

        //add a node with the time of now
        public void Add(T input) {
            lock (this.List) {
                List.Add(new Node<T>(input, DateTime.Now));
            }
        }//end method

        //add a node with the given time
        public void Add(T input, DateTime date) {
            lock (this.List) {
                List.Add(new Node<T>(input, date));
            }
        }//end method

        //pop method is multithreaded friendly
        public T pop() {
            T val;
            lock(this.List){
                val = ( (Node<T>)List[0] ).value;
                this.RemoveAt(0);
            }
            return val;
        }//end method

        private void purge() {

            for (int i = 0; i < List.Count; i++)
                if (DateTime.Now > ( (Node<T>)List[i]).date + purgetime) {
                    //remove the value, subtract 1 to
                    //compensate for shift in indexes
                    lock(this.List){
                        List.Remove(List[i]);
                    }
                    i--;
                }

        }//end method

        private class Node<T> {
            public T value;
            public DateTime date;

            public Node(T value, DateTime date) {
                this.value = value;
                this.date = date;
            }
        }//end inner class

    }//end class


    //standing in for phone call type data
    //until I have my own NSA surveillance
    //server up and running. 
    public class PhoneData{
        public string phoneNum;
        public string msg;

        public override string ToString() {
            return phoneNum + ": " + msg;
        }

        //public PhoneData() { }
    }//end class

}//end namespace
