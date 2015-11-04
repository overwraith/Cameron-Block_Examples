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

namespace FileMatchingMKII {

    public class BinaryTransactionProcessor : TransactionProcessor {
        //The sole two mutable objects which are used for the transaction processing
        private MasterRecord ctMaster = new MasterRecord();
        private TransRecord ctTrans = new TransRecord();

        private BinaryWriter writer;
        private BinaryReader masterRecords;
        private BinaryReader transRecords;

        //The current line in the transaction file, good for determining lines errors fall on
        public int LineNum { get; private set; }

        public BinaryTransactionProcessor(FileStream masterFile, 
            FileStream transactionFile, 
            FileStream outputFile) 
            : base(masterFile, transactionFile, outputFile){

            this.masterRecords = new BinaryReader(new BufferedStream(masterFile));
            this.transRecords = new BinaryReader(new BufferedStream(transactionFile));
            this.writer = new BinaryWriter(new BufferedStream(outputFile));

            this.LineNum = 0;
        }

        public BinaryTransactionProcessor(String masterFile, 
            String transactionFile, String outputFile) : this(
            new FileStream(masterFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(transactionFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) { }

        public override void ReadMasterFileRecord(ref MasterRecord ctMaster) {
            try {
                ctMaster.acctNum = masterRecords.ReadInt32();
                ctMaster.ctBal = masterRecords.ReadDecimal();

                //apparently strings are prefixed with their length
                ctMaster.name = masterRecords.ReadString();

                this.LineNum++;
            }
            catch (ArgumentException) {
                ctMaster = null;
            }
            catch (NullReferenceException) {
                ctMaster = null;
            }
            catch (EndOfStreamException) {
                ctMaster = null;
            }
        }//end method

        public override void ReadTransFileRecord(ref TransRecord ctTrans) {
            try {
                ctTrans.acctNum = transRecords.ReadInt32();
                ctTrans.dollarAmt = transRecords.ReadDecimal();
            }
            catch (ArgumentException) {
                ctTrans = null;
            }
            catch (NullReferenceException) {
                ctTrans = null;
            }catch(EndOfStreamException){
                ctTrans = null;
            }
        }//end method

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

                //write the new record
                writer.Write(ctMaster.acctNum);
                writer.Write(ctMaster.ctBal);
                writer.Write(ctMaster.name);

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

    }//end class

}//end namespace
