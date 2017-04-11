using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator
{
   public class GridItem
    {
      //  private AnnuityDailyCalc data = new AnnuityDailyCalc();

        public string PaymentNumber { get; set; }
        public string Date { get; set; }
        public string Payment { get; set; }
        public string Principal { get; set; }
        public string Interest { get; set; }
        public string StartingBalance { get; set; }
        public string EndingBalance { get; set; }

        //public GridItem(string paymentNumber, string date, string payment, string principal, string interest, string startingBalance, string endingBalance)
        //{
        //    PaymentNumber = paymentNumber;
        //    Date = date;
        //    Payment = payment;
        //    Principal = principal;
        //    Interest = interest;
        //    StartingBalance = startingBalance;
        //    EndingBalance = endingBalance;
        //}
        //public override string ToString()
        //{
        //    return Payment;
        //}
    }
}
