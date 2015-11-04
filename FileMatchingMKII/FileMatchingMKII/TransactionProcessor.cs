/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileMatchingMKII {

    public abstract class TransactionProcessor {

        //Only two Constructors make much sense for this type of application
        public TransactionProcessor(FileStream masterFile, 
            FileStream transactionFile, 
            FileStream outputFile) { }

        public TransactionProcessor(String masterFile, 
            String transactionFile, String outputFile) : this(
            new FileStream(masterFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(transactionFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), 
            new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)) { }


        //Uses the ReadMasterFileRecord, and ReadTransFileRecord methods to process the transaction file
        //One MasterRecord object and one TransactionRecord can be used to process the file if both are sorted
        public abstract void ProcessFile();

        //Reads one master file record from the old master file
        public abstract void ReadMasterFileRecord(ref MasterRecord ctMaster);

        //Reads one transaction file record from the transaction file
        //Should keep track of the line numbers for error logging to the screen
        public abstract void ReadTransFileRecord(ref TransRecord ctTrans);
    }//end class

}//end namespace
