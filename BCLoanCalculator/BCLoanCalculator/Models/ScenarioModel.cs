using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BCLoanCalculator.Models
{
    public class ScenarioModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string loanAmount;

        public string LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; }
        }

        private string annualRate;

        public string AnnualRate
        {
            get { return annualRate; }
            set { annualRate = value; }
        }

        private string dailyRate;

        public string DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        private string penaltyRate;

        public string PenaltyRate
        {
            get { return penaltyRate; }
            set { penaltyRate = value; }
        }
        private DateTime startDate = DateTime.Today;

        public DateTime StarDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                if (CountDays().HasValue)
                {
                    termsOfLoan = CountDays().ToString();
                }
            }
        }
        public int? CountDays()
        {
            return (endDate - startDate).Days;
        }
        private DateTime endDate = DateTime.Today;


        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                if (CountDays().HasValue)
                {
                    termsOfLoan = CountDays().ToString();
                }
            }
        }

        private string termsOfLoan;

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set { termsOfLoan = value; }
        }

        private string termsOfScenario;

        public string TermsOfScenario
        {
            get { return termsOfScenario; }
            set
            {
                termsOfScenario = value; if (App.Parse(value) == true)
                {
                    endDate = startDate.Date.AddDays(Convert.ToDouble(termsOfLoan));
                }
            }
        }

        private string payment;

        public string Payment
        {
            get { return payment; }
            set { payment = value; }
        }


        public List<GraphViewModel> GraphScenario()
        {
            var result = new List<GraphViewModel>();
            try
            {
               // List<double> list = new List<double>();
                double endingBalance = Convert.ToDouble(LoanAmount);
                double rate = Convert.ToDouble(AnnualRate) / 36500;
                double startingBalance = Convert.ToDouble(LoanAmount);
                double payment = Convert.ToDouble(Payment);
                DateTime dateTime = DateTime.Today;
                int j = 1;
                for (int i = 1; i <= Convert.ToInt32(TermsOfScenario); i++)
                {

                    while (i < Convert.ToInt32(TermsOfScenario))
                    {
                        while (i <= Convert.ToInt32(TermsOfLoan))
                        {
                            dateTime = StarDate.AddDays(i);


                            double interest1 = Math.Round(rate * startingBalance, 2, MidpointRounding.AwayFromZero);
                            double principal1 = Math.Round(payment - interest1, 2, MidpointRounding.AwayFromZero);
                            endingBalance -= principal1;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Payment = payment.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = startingBalance.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = endingBalance.ToString("N", CultureInfo.InvariantCulture),
                                Penalty = "0.00",
                                Rate = interest1.ToString("N", CultureInfo.InvariantCulture),
                                Date = dateTime.ToString("dd/MM/yyyy"),
                                Principal = principal1.ToString("N", CultureInfo.InvariantCulture)
                            });
                            startingBalance -= principal1;
                            i++;
                            //  list.Add(payment);
                        }
                        dateTime = StarDate.AddDays(i);


                        double interest = Math.Round(rate * startingBalance, 2, MidpointRounding.AwayFromZero);
                        double penalty = Math.Round(Convert.ToDouble(PenaltyRate) * startingBalance / 100, 2, MidpointRounding.AwayFromZero);
                        double principal = Math.Round(payment - interest - penalty, 2, MidpointRounding.AwayFromZero);
                        endingBalance -= principal;
                        result.Add(new GraphViewModel
                        {
                            PaymentNumber = i.ToString(),
                            Payment = payment.ToString("N", CultureInfo.InvariantCulture),
                            StartingBalance = startingBalance.ToString("N", CultureInfo.InvariantCulture),
                            EndingBalance = endingBalance.ToString("N", CultureInfo.InvariantCulture),
                            Penalty = penalty.ToString("N", CultureInfo.InvariantCulture),

                            Rate = interest.ToString("N", CultureInfo.InvariantCulture),
                            Date = dateTime.ToString("dd/MM/yyyy"),
                            Principal = principal.ToString("N", CultureInfo.InvariantCulture)
                        });
                        startingBalance -= principal;
                        // list.Add(payment);
                        i++;
                        j = i;
                        if (startingBalance - payment < 0)
                        {

                            i = Convert.ToInt32(TermsOfScenario);
                        }

                    }
                    dateTime = StarDate.AddDays(j);
                    double penalty1 = Math.Round(Convert.ToDouble(PenaltyRate) * startingBalance / 100, 2, MidpointRounding.AwayFromZero);
                    double interest2 = Math.Round(rate * startingBalance, 2, MidpointRounding.AwayFromZero);
                    double principal2 = Math.Round(startingBalance, 2, MidpointRounding.AwayFromZero);

                    endingBalance -= startingBalance;
                    result.Add(new GraphViewModel
                    {
                        PaymentNumber = j.ToString(),
                        Payment = (startingBalance + penalty1 + interest2).ToString("N", CultureInfo.InvariantCulture),
                        StartingBalance = startingBalance.ToString("N", CultureInfo.InvariantCulture),
                        EndingBalance = endingBalance.ToString("N", CultureInfo.InvariantCulture),
                        Penalty = penalty1.ToString("N", CultureInfo.InvariantCulture),
                        Rate = interest2.ToString("N", CultureInfo.InvariantCulture),
                        Date = dateTime.ToString("dd/MM/yyyy"),
                        Principal = principal2.ToString("N", CultureInfo.InvariantCulture)
                    });
                    //  list.Add((startingBalance + penalty1 + interest2));

                    i = Convert.ToInt32(TermsOfScenario);

                }
        
            }
            catch (Exception)
            {
            }
            return result;
        }
        public List<GraphViewModel> GetGraphViewModel()
        {
            var data = GraphScenario();
            var model = GraphViewModel.GetViewModel(data);
            return model;
        }
        //public double IRR(List<double> list, double loanAmount, int term, double rate)
        //{
        //    double sum = 0;
        //    for (int i = 1; i <= term; i++)
        //    {
        //        foreach (double item in list)
        //        {
        //            double x = item / Math.Pow((1 + rate), i);
        //            sum += x;
        //            i++;
        //        }
        //    }
        //    return Math.Round((sum - loanAmount),4,MidpointRounding.AwayFromZero);
        //}
        //public double Effect(double IRR, int term)
        //{

        //    double effect = Math.Pow(1 + (IRR / term), term) - 1;
        //    return effect;
        //}

    }
}
