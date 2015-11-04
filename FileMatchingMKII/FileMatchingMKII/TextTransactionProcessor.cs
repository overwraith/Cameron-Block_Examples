/*Author: Cameron Block
 * Purpose: Re-Create an Inline Transaction Processing System. 
 * 
 * The idea behind this program is to meld the two files master file, and transaction file together as 
 * cheaply as possible using only two objects which represent the current line in each of the two 
 * files. The input needs sorted before this program will operate on the data, but the idea is to have
 * a system process running in the background automatically sorting the files. I have been told by 
 * teachers that my C program that this was based on was very efficient. It acts like a zipper, 
 * threading the teeth correctly to each other. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileMatchingMKII {

    public class TextTransactionProcessor : TransactionProcessor {
        //The sole two mutable objects which are used for the transaction processing
        private MasterRecord ctMaster = new MasterRecord();
        private TransRecord ctTrans = new TransRecord();

        private StreamWriter writer;
        private StreamReader masterRecords;
        private StreamReader transRecords;

        public int LineNum { get; private set; }

        public static void Main(string[] args) {
            TextTransactionProcessor transaction1 =
                new TextTransactionProcessor("oldmast.txt", "trans.txt", "newMast.txt");

            //CreateMasterFileBinary();
            //CreateTransFileBinary();

            BinaryTransactionProcessor transaction2 =
                new BinaryTransactionProcessor("oldmast.dat", "trans.dat", "newMast.dat");

            transaction1.ProcessFile();
            transaction2.ProcessFile();

            pause();
        }//end main

        public TextTransactionProcessor(FileStream masterFile, 
            FileStream transactionFile,
            FileStream outputFile)
            : base(masterFile, transactionFile, outputFile) {

            this.masterRecords = new StreamReader(new BufferedStream(masterFile));
            this.transRecords = new StreamReader(new BufferedStream(transactionFile));
            this.writer = new StreamWriter(new BufferedStream(outputFile));
        }

        public TextTransactionProcessor(String masterFile, 
            String transactionFile, String outputFile) : this(
            new FileStream(masterFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(transactionFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) { }

        public override void ProcessFile() {
            ReadMasterFileRecord(ref ctMaster);
            ReadTransFileRecord(ref ctTrans);

            while (ctMaster != null) {
                while (ctTrans != null) {
                    if (ctMaster == ctTrans)//account nums match
                        ctMaster += ctTrans;
                    //don't read a trans record, wait for next master record
                    else if (ctMaster < ctTrans)
                        break;
                    //input appearing in the transaction file which doesn't have a corresponding account
                    else if (ctMaster > ctTrans) {
                        Console.WriteLine("Transaction with no corresponding account line "
                            + this.LineNum + " account number " + ctTrans.acctNum);
                    }

                    ReadTransFileRecord(ref ctTrans);
                }//end loop

                writer.WriteLine(ctMaster.ToString());
                ReadMasterFileRecord(ref ctMaster);
            }//end loop

            //could be mulitple unmatched transactions at the end of the list
            while (ctTrans != null) {
                Console.WriteLine("Transaction with no corresponding account line "
                    + this.LineNum + " account number " + ctTrans.acctNum);
                ReadTransFileRecord(ref ctTrans);
            }

            writer.Flush();
            writer.Close();
            Console.WriteLine("The master file has been updated... ");
        }//end method
        
        public override void ReadMasterFileRecord(ref MasterRecord ctMaster){
            try {
                String line = masterRecords.ReadLine();
                String[] toks = line.Split(' ');

                int offset = toks[0].Length + toks[1].Length + 1;

                ctMaster.acctNum = Convert.ToInt32(toks[0]);
                ctMaster.ctBal = Convert.ToDecimal(toks[1]);
                ctMaster.name = line.Substring(offset, line.Length - offset);
            }
            catch (ArgumentException) {
                ctMaster = null;
            }
            catch(NullReferenceException){
                ctMaster = null;
            }
        }//end method

        public override void ReadTransFileRecord(ref TransRecord ctTrans) {
            try {
                String[] toks = transRecords.ReadLine().Split(' ');

                ctTrans.acctNum = Convert.ToInt32(toks[0]);
                ctTrans.dollarAmt = Convert.ToDecimal(toks[1]);

                this.LineNum++;
            }
            catch (ArgumentException) {
                ctTrans = null;
            }
            catch (NullReferenceException) {
                ctTrans = null;
            }
        }//end method

        private static void CreateTransFile() {
            List<TransRecord> transRecord = new List<TransRecord>();

            //set up Ctrl + C trapping, write the file we prompted for
            Console.CancelKeyPress += delegate {
                StreamWriter writer = new StreamWriter(new BufferedStream(
                    new FileStream("trans.txt", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite)));

                transRecord.OrderBy(rec => rec.acctNum);

                foreach (TransRecord rec in transRecord)
                    writer.WriteLine(rec.ToString());

                writer.Close();

            };

            //Input transaction records
            while (true) {
                Console.WriteLine("Please Input a Transaction Record, Press <Ctrl + C> to exit... ");
                //ACCTNUM DOLLARAMT

                //get customer input
                Console.Write("Account Number: ");
                int acctNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Dollar Amount: ");
                decimal dollarAmt = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();

                transRecord.Add(new TransRecord(acctNum, dollarAmt));
            }//end loop

        }//end method

        private static void CreateTransFileBinary() {
            List<TransRecord> transRecord = new List<TransRecord>();

            //set up Ctrl + C trapping, write the file we prompted for
            Console.CancelKeyPress += delegate {
                BinaryWriter writer = new BinaryWriter(new BufferedStream(
                    new FileStream("trans.dat", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite)));

                transRecord.OrderBy(rec => rec.acctNum);

                foreach (TransRecord rec in transRecord) {
                    writer.Write(rec.acctNum);
                    writer.Write(rec.dollarAmt);
                }

                writer.Close();

            };

            //Input transaction records
            while (true) {
                Console.WriteLine("Please Input a Transaction Record, Press <Ctrl + C> to exit... ");
                //ACCTNUM DOLLARAMT

                //get customer input
                Console.Write("Account Number: ");
                int acctNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Dollar Amount: ");
                decimal dollarAmt = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();

                transRecord.Add(new TransRecord(acctNum, dollarAmt));
            }//end loop

        }//end method

        private static void CreateMasterFile() {
            List<MasterRecord> mastRecord = new List<MasterRecord>();

            //set up Ctrl + C trapping, write the file we prompted for
            Console.CancelKeyPress += delegate {
                StreamWriter writer = new StreamWriter(new BufferedStream(
                    new FileStream("oldmast.txt", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite)));

                mastRecord.OrderBy(rec => rec.acctNum);

                foreach (MasterRecord rec in mastRecord)
                    writer.WriteLine(rec.ToString());

                writer.Close();

            };

            //Input master records
            while (true) {
                Console.WriteLine("Please Input a Master Record, Press <Ctrl + C> to exit... ");
                //ACCTNUM CTBAL NAME

                //get customer input
                Console.Write("Account Number: ");
                int acctNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Current Balance: ");
                decimal ctBal = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Customer Name: ");
                String name = Console.ReadLine();
                Console.WriteLine();

                mastRecord.Add(new MasterRecord(acctNum, ctBal, name));
            }//end loop

        }//end method

        private static void CreateMasterFileBinary() {
            List<MasterRecord> mastRecord = new List<MasterRecord>();

            //set up Ctrl + C trapping, write the file we prompted for
            Console.CancelKeyPress += delegate {
                BinaryWriter writer = new BinaryWriter(new BufferedStream(
                    new FileStream("oldmast.dat", FileMode.Create, FileAccess.Write,
                        FileShare.ReadWrite)));

                mastRecord.OrderBy(rec => rec.acctNum);

                foreach (MasterRecord rec in mastRecord) {
                    writer.Write(rec.acctNum);
                    writer.Write(rec.ctBal);
                    writer.Write(rec.name);
                }

                writer.Close();

            };

            //Input master records
            while (true) {
                Console.WriteLine("Please Input a Master Record, Press <Ctrl + C> to exit... ");
                //ACCTNUM CTBAL NAME

                //get customer input
                Console.Write("Account Number: ");
                int acctNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Current Balance: ");
                decimal ctBal = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Customer Name: ");
                String name = Console.ReadLine();
                Console.WriteLine();

                mastRecord.Add(new MasterRecord(acctNum, ctBal, name));
            }//end loop

        }//end method

        public static void pause() {
            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }

    }//end class

}//end namespace
