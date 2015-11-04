/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMatchingMKII {

#pragma warning disable 0660, 0661
    public class MasterRecord {
        //making these mutable
        public int acctNum;
        public decimal ctBal;
        public String name;

        public MasterRecord() {
            acctNum = 0;
            ctBal = 0.00m;
            name = "";
        }//end constructor

        public MasterRecord(int acctNum, decimal ctBal, String name) {
            this.acctNum = acctNum;
            this.ctBal = ctBal;
            this.name = name;
        }//end constructor

        public static MasterRecord operator +(MasterRecord mast, TransRecord trans) {
            if (mast.acctNum == trans.acctNum) {
                if (mast == null)
                    throw new ArgumentException("Master record must not be null. ");
                else if (trans == null)
                    throw new ArgumentException("Transaction record must not be null. ");
                else {
                    mast.ctBal += trans.dollarAmt;
                    return mast;
                }
            }
            else {
                throw new ArgumentException("Account numbers must be the same. ");
            }
        }//end method

        public static bool operator ==(MasterRecord mast, TransRecord trans) {
            if (ReferenceEquals(trans, null)) {
                if (ReferenceEquals(mast, null))
                    return true;
                else
                    return false;
            }

            if (mast.acctNum == trans.acctNum) {
                return mast.acctNum == trans.acctNum;
            }
            else {
                return false;
            }
        }//end method

        public static bool operator !=(MasterRecord mast, TransRecord trans) {
            if (ReferenceEquals(trans, null)) {
                if (ReferenceEquals(mast, null))
                    return false;
                else
                    return true;
            }

            if (mast.acctNum == trans.acctNum) {
                return mast.acctNum != trans.acctNum;
            }
            else {
                return true;
            }
        }//end method


        public static bool operator >(MasterRecord mast, TransRecord trans) {
            if (mast == null)
                throw new ArgumentException("Master record must not be null. ");
            else if (trans == null)
                throw new ArgumentException("Transaction record must not be null. ");
            else {
                return mast.acctNum > trans.acctNum;
            }
        }//end method

        public static bool operator <(MasterRecord mast, TransRecord trans) {
            if (mast == null)
                throw new ArgumentException("Master record must not be null. ");
            else if (trans == null)
                throw new ArgumentException("Transaction record must not be null. ");
            else {
                return mast.acctNum < trans.acctNum;
            }
        }//end method

        public override string ToString() {
            //ACCTNUM CTBAL NAME
            return acctNum + " " + ctBal + " " + name;
        }//end method

    }//end class
#pragma warning restore 0660, 0661

}//end namespace
