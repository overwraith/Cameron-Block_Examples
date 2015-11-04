/* Author: Cameron Block
 * For software that requires LEASE PERIODS, TIMEOUTS, ETC. 
 * Is just for fun. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace TimeBomb {

    class Program {

        static void Main(string[] args) {
            //TimeBomb bomb = new TimeBomb(DateTime.Now.AddSeconds(3), (DetonateEvent e) => { Console.WriteLine("Boom!"); });

            //create a crypto stream writer
            Rijndael crypt = Rijndael.Create();
            ICryptoTransform transform = crypt.CreateEncryptor();
            FileStream fs = new FileStream("Encrypt.bin", FileMode.Create);
            CryptoStream cs = new CryptoStream(fs, transform, CryptoStreamMode.Write);
            byte[] pass = crypt.Key;

            BinaryWriter write = new BinaryWriter(cs);
            write.Write(DateTime.Now.AddSeconds(10).ToString());
            write.Flush();
            write.Close();

            TimeBomb bomb = new TimeBomb("Encrypt.bin",
                crypt,
                (DetonateEvent e) => { Console.WriteLine("Boom!"); },
                Decrypt);
            bomb.thrd.Join();

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }//end main

        public static BinaryReader Decrypt(String file, Rijndael crypt) {
            ICryptoTransform transform = crypt.CreateDecryptor();
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            CryptoStream cs = new CryptoStream(fs, transform, CryptoStreamMode.Read);

            return new BinaryReader(cs);
        }//end method

    }//end class

    public delegate void DetonateHandler(DetonateEvent evt);

    public class PasswordEventArgs : EventArgs {
        public string password;
    }//end class

    public class DetonateEvent {
        public event DetonateHandler detonate;

        public void OnDetonateEvent() {
            if (detonate != null)
                detonate(this);
        }//end method
    }//end class

    public delegate BinaryReader DecryptFile(String file, Rijndael crypt);

    public class TimeBomb {
        //some might want the detonate time accessable so they can update it, a keep alive
        //others might want it not accessable so that end users cannot modify the software
        protected DateTime detonateTime;
        public Thread thrd;
        public DetonateEvent detonate = new DetonateEvent();

        public TimeBomb(DateTime detonateTime, DetonateHandler detonate) {
            this.detonateTime = detonateTime;

            this.detonate.detonate += detonate;

            thrd = new Thread(new ThreadStart(() => {
                while (true) {
                    //if we are past time to detonate, then detonate
                    if (detonateTime.CompareTo(DateTime.Now) < 0) {
                        this.detonate.OnDetonateEvent();
                        Thread.Sleep(1000);
                        return;
                    }
                }//end loop
            }));
            thrd.Priority = ThreadPriority.Lowest;
            thrd.Start();
        }//end constructor

        //initialize from an encrypted file
        public TimeBomb(String file, Rijndael crypt, DetonateHandler detonate, DecryptFile decrypt) {
            //read the date time value from the file
            BinaryReader reader = decrypt.Invoke(file, crypt);
            String str = reader.ReadString();
            this.detonateTime = DateTime.Parse(str);//reader.ReadLine()

            this.detonate.detonate += detonate;

            thrd = new Thread(new ThreadStart(() => {
                while (true) {
                    //if we are past time to detonate, then detonate
                    if (detonateTime.CompareTo(DateTime.Now) < 0) {
                        this.detonate.OnDetonateEvent();
                        return;
                    }

                    Thread.Sleep(1000);
                }//end loop
            }));
            thrd.Priority = ThreadPriority.Lowest;
            thrd.Start();
        }//end constructor

        //add a certain amount of time to the detonate time
        public void AddTime(TimeSpan time) {
            detonateTime += time;
        }//end method

    }//end class

}//end namespace
