using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator.Models
{
    public class GraphViewModel
    {
        public string Payment { get; set; }
        public string Date { get; set; }
        public string StartingBalance { get; set; }
        public string EndingBalance { get; set; }
        public string Principal { get; set; }
        public string Rate { get; set; }
        public string PaymentNumber { get; set; }
        public string Penalty { get; set; }


        public static List<GraphViewModel> GetViewModel(List<GraphViewModel> data)
        {
            var result = new List<GraphViewModel>
            {
                new GraphViewModel
                {
                    Date = "თარიღი",
                    EndingBalance = "საბოლოო ბალანსი",
                    Payment = "გადასახადი",
                    Principal = "ძირი",
                    Rate = "პროცენტი",
                    StartingBalance = "საწყისი ბალანსი",
                    PaymentNumber = "№", 
                    Penalty = "პირგასამტეხლო"
                    
                }
            };

            result.InsertRange(1, data);

            return result;
        }
    }
}
