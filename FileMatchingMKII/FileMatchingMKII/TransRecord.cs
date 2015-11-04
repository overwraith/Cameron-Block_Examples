/*Author: Cameron Block*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMatchingMKII {

    public class TransRecord {
        public int acctNum;
        public decimal dollarAmt;

        public TransRecord() {
            acctNum = 0;
            dollarAmt = 0.00m;
        }//end constructor

        public TransRecord(int acctNum, decimal dollarAmt) {
            this.acctNum = acctNum;
            this.dollarAmt = dollarAmt;
        }//end constructor

        public override string ToString() {
            //ACCTNUM DOLLARAMT
            return acctNum + " " + dollarAmt;
        }//end method

    }//end class

}//end namespace
