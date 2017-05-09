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
    public class AnnuityMonthlyModel : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string monthlyRate;
        private string annualRate;
        private string payment;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;
        private DateTime firstPaymentDate = DateTime.Today.AddMonths(1);
        private string interestOnly;
        private string regularPayment;


        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string LoanAmount
        {
            get { return loanAmount; }
            set
            {
                loanAmount = value;
                //if (Nper().HasValue && !string.IsNullOrEmpty(Payment))
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set
            {
                termsOfLoan = value;
                if (App.Parse(value) == true && !string.IsNullOrEmpty(value))
                {
                    endDate = StartDate.AddMonths(Convert.ToInt32(termsOfLoan));
                }
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string MonthlyRate
        {
            get { return monthlyRate; }
            set
            {
                monthlyRate = value;
                if (string.IsNullOrEmpty(value))
                {
                    annualRate = string.Empty;
                }
                //if (App.Parse(monthlyRate) == true)
                //{
                //    annualRate = Math.Round(Convert.ToDecimal(monthlyRate) * 12, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                //if (Nper().HasValue && !string.IsNullOrEmpty(Payment))
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)

                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string AnnualRate
        {
            get { return annualRate; }
            set
            {
                annualRate = value;
                if (string.IsNullOrEmpty(value))
                {
                    monthlyRate = string.Empty;
                }
                //if (App.Parse(annualRate) == true)
                //{
                //    monthlyRate = Math.Round(Convert.ToDecimal(annualRate) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                //if (Nper().HasValue && !string.IsNullOrEmpty(Payment))
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(monthlyRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                //if (Nper().HasValue)
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string RegularPayment
        {
            get { return regularPayment; }
            set
            {
                regularPayment = value;
            }
        }


        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                if (CountTermsOfLoan().HasValue)
                {
                    termsOfLoan = CountTermsOfLoan().Value.ToString();

                }
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                if (CountTermsOfLoan().HasValue)
                {
                    termsOfLoan = CountTermsOfLoan().Value.ToString();

                }
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public DateTime FirstPaymentDate
        {
            get { return firstPaymentDate; }
            set
            {
                firstPaymentDate = value;

                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }

        public string InterestOnly
        {
            get { return interestOnly; }
            set
            {
                interestOnly = value;
                if (PMT().HasValue)
                {
                    Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged(nameof(LoanAmount));
            }
        }
        public int? MonthsFromFirstToEnd()
        {
            return (EndDate.Month - FirstPaymentDate.Month) + 12 * (EndDate.Year - FirstPaymentDate.Year);
        }
        public int? MonthsFromFirstToRelease()
        {
            return (StartDate.Month - FirstPaymentDate.Month) + 12 * (StartDate.Year - FirstPaymentDate.Year);
        }
        public int? CountTermsOfLoan()
        {
            return (EndDate.Month - StartDate.Month) + 12 * (EndDate.Year - StartDate.Year);
        }
        public decimal? PMT()
        {
            try
            {
                if (App.Parse(AnnualRate) == true && App.Parse(LoanAmount) == true && App.Parse(TermsOfLoan) == true && Convert.ToDecimal(AnnualRate) != 0)

                {
                    decimal interestOnly = 0;
                    if (App.Parse(InterestOnly) == true)
                    {
                        interestOnly = Convert.ToDecimal(InterestOnly);
                    }
                    decimal rate = Convert.ToDecimal(AnnualRate) / 1200;
                    decimal pmt;
                    pmt = Convert.ToDecimal(LoanAmount) * rate / (decimal)(1 - (1 / (Math.Pow((double)rate + 1, (double)MonthsFromFirstToEnd() + 1 - (double)interestOnly))));
                    string peyment = pmt.ToString();
                    decimal val = pmt;
                    return val;
                }

                else return null;
            }
            catch (Exception)
            {

                return null;
            }


        }
        public int? Nper()
        {
            try
            {
                if (App.Parse(Payment) == true && App.Parse(AnnualRate) == true && App.Parse(LoanAmount) == true && PMT() == null && Convert.ToDecimal(AnnualRate) != 0)
                {
                    try
                    {
                        decimal rate = Convert.ToDecimal(AnnualRate) / 1200;

                        decimal nper = (decimal)-Math.Log((double)(1 - (rate * Convert.ToDecimal(LoanAmount) / Convert.ToDecimal(Payment))), Math.E) / (decimal)Math.Log((double)(1 + rate), Math.E);
                        return Convert.ToInt32(nper);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            //double rate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermsOfLoan));

        }
        public int CountMonthsFromFirstToStart()
        {
            return (FirstPaymentDate.Month - StartDate.Month) + 12 * (FirstPaymentDate.Year - StartDate.Year);
        }
        public int CountMonthsEndRelease()
        {
            return (EndDate.Month - FirstPaymentDate.Month) + 12 * (EndDate.Year - FirstPaymentDate.Year) + 1;
        }
        public int CounterForMonthly()
        {
            return (FirstPaymentDate - StartDate).Days;
        }
        public int CountDaysFromStartDateToNextPayment()
        {
            return ((FirstPaymentDate.Date.AddMonths(CountMonthsFromFirstToStart() - 1) - StartDate).Days);
        }
        public List<GraphViewModel> GraphMonthly()
        {
            var result = new List<GraphViewModel>();

            try
            {
                double SumI = 0;
                double SumP = 0;
                double amount = Convert.ToDouble(LoanAmount);
                double balance = Convert.ToDouble(LoanAmount);
                //double monthlyRate = Convert.ToDouble(DailyInterestELM) * CountDaysForMonthly() / (100 * Convert.ToDouble(TermsOfLoan)); //// <<<<<<<
                double monthlyRate = Convert.ToDouble(AnnualRate) / 1200;
                int time = CountMonthsFromFirstToStart();
                DateTime DT = FirstPaymentDate.Date.AddMonths(CountMonthsFromFirstToStart());
                if (monthlyRate == 0)
                {
                    monthlyRate = Convert.ToDouble(AnnualRate) / 365 * Convert.ToInt32(TermsOfLoan) * 30.417 / (100 * Convert.ToDouble(TermsOfLoan));
                }

                int interestonly;
                if (String.IsNullOrEmpty(InterestOnly))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnly);
                #region chveulebriviiiiiiii
                #region start==release
                if (FirstPaymentDate.Date.AddDays(1).AddMonths(-1).AddDays(-1) == StartDate.Date.Date)
                {
                    for (int i = 1; i <= Convert.ToDouble(TermsOfLoan); i++)
                    {
                        if (App.Parse(RegularPayment) == true && Convert.ToDecimal(RegularPayment) > 0)
                        {
                            if (Convert.ToDouble(RegularPayment) > Convert.ToDouble(PMT()))
                            {
                                do
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = StartDate.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            amount -= principal11;
                                            i++;
                                        }
                                    }
                                    DateTime dateTime = FirstPaymentDate.AddMonths(i);
                                    double principal = Convert.ToDouble(RegularPayment) - amount * monthlyRate;
                                    double Rate = amount * monthlyRate;
                                    balance -= principal;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    //SumI += Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                                    //SumP += Math.Round(Convert.ToDouble(RegularPayment), 2, MidpointRounding.AwayFromZero);
                                    amount -= principal;
                                    i++;
                                }
                                while ((balance - Convert.ToDouble(RegularPayment)) > 0);

                                DateTime dateTime22 = FirstPaymentDate.AddMonths(i);
                                double principal22 = balance;
                                double interest22 = amount * monthlyRate;
                                balance -= principal22;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime22.Date.ToString("dd/MM/yyyy"),
                                    Payment = (interest22 + amount).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal22.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest22.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                i = Convert.ToInt32(TermsOfLoan);
                                //SumP += Math.Round((interest22 + amount), 2, MidpointRounding.AwayFromZero);
                                //SumI += Math.Round(interest22, 2, MidpointRounding.AwayFromZero);
                            }

                            if (Convert.ToDouble(RegularPayment) < Convert.ToDouble(PMT()))
                            {
                                while (i < Convert.ToInt32(TermsOfLoan))
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = StartDate.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            amount -= principal11;
                                            i++;
                                            //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                        }
                                    }
                                    DateTime dateTime22 = StartDate.AddMonths(i);
                                    double principal22 = Convert.ToDouble(RegularPayment) - amount * monthlyRate;
                                    double interest22 = amount * monthlyRate;
                                    balance -= principal22;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime22.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal22.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest22.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    amount -= principal22;
                                    i++;
                                    //SumP += Math.Round(Convert.ToDouble(RegularPayment), 2, MidpointRounding.AwayFromZero);
                                    //SumI += Math.Round(interest22, 2, MidpointRounding.AwayFromZero);
                                }
                                DateTime dateTime = StartDate.AddMonths(i);
                                double principal = balance;
                                double Rate = amount * monthlyRate;
                                balance -= principal;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    Payment = (Rate + amount).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                amount -= principal;
                                //SumI += Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                                //SumP += Math.Round((Rate + amount), 2, MidpointRounding.AwayFromZero);
                            }

                            else
                            {
                                while (i < Convert.ToInt32(TermsOfLoan))
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        //for (int i = 1; i <= Convert.ToDouble(TermsOfLoan); i++)
                                        //{
                                        while (i <= interestonly)
                                        {
                                            DateTime dateTime11 = FirstPaymentDate.AddMonths(i);
                                            double principal11 = 0;
                                            double interest11 = monthlyRate * amount;
                                            balance -= principal11;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            amount -= principal11;
                                            i++;
                                            //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                        }
                                    }
                                    DateTime dateTime = FirstPaymentDate.AddMonths(i);
                                    double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                                    double Rate = amount * monthlyRate;
                                    balance -= principal;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    //SumI += Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                                    //SumP += Math.Round(Convert.ToDouble(RegularPayment), 2, MidpointRounding.AwayFromZero);
                                    amount -= principal;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(interestonly) > 0)
                            {
                                //for (int i = 1; i <= Convert.ToDouble(TermsOfLoan); i++)
                                //{
                                while (i <= interestonly)
                                {
                                    DateTime dateTime11 = StartDate.AddMonths(i);
                                    double principal11 = 0;
                                    double interest11 = monthlyRate * amount;
                                    balance -= principal11;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                        Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    amount -= principal11;
                                    i++;
                                    //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                    //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);

                                }
                            }
                            DateTime dateTime = StartDate.AddMonths(i);
                            double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                            double Rate = amount * monthlyRate;
                            balance -= principal;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = (i).ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Convert.ToDouble(Payment).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            //SumI += Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                            //SumP += Math.Round(Convert.ToDouble(Payment), 2, MidpointRounding.AwayFromZero);
                            amount -= principal;
                            //}
                        }
                    }
                }
                #endregion
                else
                {
                    int x = CountMonthsEndRelease() + 1;
                    int y = x - 1;
                    double interesetIpayment = CounterForMonthly() * ((Convert.ToDouble(AnnualRate) / 100) / 365) * Convert.ToDouble(LoanAmount);
                    #region interesetIpayment >= Convert.ToDouble(PMT())
                    if (interesetIpayment >= Convert.ToDouble(PMT()))
                    {

                        if (App.Parse(RegularPayment) == true && Convert.ToDecimal(RegularPayment) > 0)
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                #region (Convert.ToDouble(RegularPayment) > Convert.ToDouble(PMT())
                                if (Convert.ToDouble(RegularPayment) > Convert.ToDouble(PMT()))
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = FirstPaymentDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                                        //double Rate = amount * monthlyRate;
                                        //balance -= principal;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDate.Date.ToString("dd/MM/yyyy"),
                                            Payment = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        i++;
                                        //SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        //SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);

                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            //SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            //SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                result.Add(new GraphViewModel
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                    Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                    Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                                });
                                                amount -= principal11;
                                                i++;
                                                //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(RegularPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal21.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            //SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            //SumP += Math.Round(Convert.ToDouble(Payment), 2, MidpointRounding.AwayFromZero);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime2 = DT.AddMonths(i - 1);
                                        double principal2 = Convert.ToDouble(RegularPayment) - amount * monthlyRate;
                                        double interest2 = amount * monthlyRate;
                                        balance -= principal2;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime2.Date.ToString("dd/MM/yyyy"),
                                            Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal2.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest2.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        amount -= principal2;
                                        i++;
                                        //SumI += Math.Round(interest2, 2, MidpointRounding.AwayFromZero);
                                        //SumP += Math.Round(Convert.ToDouble(Payment), 2, MidpointRounding.AwayFromZero);
                                    }
                                    while ((amount - Convert.ToDouble(RegularPayment)) > 0);

                                    DateTime dateTime3 = DT.AddMonths(i - 1);
                                    double interest3 = amount * monthlyRate;
                                    double principal3 = amount * monthlyRate;

                                    balance -= principal3;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                        Payment = (interest3 + amount).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = amount.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest3.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    //SumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                                    //SumP += Math.Round(interest3 + amount, 2, MidpointRounding.AwayFromZero);
                                    amount -= principal3;
                                    i = x;
                                }
                                #endregion


                                #region reggadasaxadi naklebiapeimentze
                                else
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = FirstPaymentDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                                        //double Rate = amount * monthlyRate;
                                        //balance -= principal;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDate.Date.ToString("dd/MM/yyyy"),
                                            Payment = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        i++;
                                        //SumI += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);
                                        //SumP += Math.Round(interesetIpayment, 2, MidpointRounding.AwayFromZero);

                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            //SumI += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            //SumP += Math.Round(interest21, 2, MidpointRounding.AwayFromZero);
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                result.Add(new GraphViewModel
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                    Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                    Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                                });
                                                amount -= principal11;
                                                i++;
                                                //SumP += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                                //SumI += Math.Round(interest11, 2, MidpointRounding.AwayFromZero);
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(RegularPayment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal21.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            //SumI +=  interest21 ;
                                            //SumP +=  Convert.ToDouble(Payment) ;
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime3 = DT.AddMonths(i - 1);
                                        double interest3 = amount * monthlyRate;
                                        double principal3 = Convert.ToDouble(RegularPayment) - amount * monthlyRate;

                                        balance -= principal3;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                            Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal3.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest3.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        //SumI +=  interest3 ;
                                        //SumP +=  Convert.ToDouble(Payment) ;
                                        amount -= principal3;
                                        i++;
                                    } while (i < CountMonthsEndRelease());
                                    DateTime dateTime4 = DT.AddMonths(i - 1);
                                    double interest4 = amount * monthlyRate;
                                    double principal4 = amount;

                                    balance -= amount;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                        Payment = (amount + interest4).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = amount.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest4.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    SumI += interest4;
                                    SumP += amount + interest4;
                                    amount -= principal4;
                                    i = x;
                                }
                                #endregion
                            }
                        }////////////////////////////////////////////////

                        else
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                #region (Convert.ToDouble(Payment) > Convert.ToDouble(PMT())
                                if (Convert.ToDouble(Payment) > Convert.ToDouble(PMT()))
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = FirstPaymentDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                                        //double Rate = amount * monthlyRate;
                                        //balance -= principal;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDate.Date.ToString("dd/MM/yyyy"),
                                            Payment = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        i++;
                                        SumI += interesetIpayment;
                                        SumP += interesetIpayment;
                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            SumI += interest21;
                                            SumP += interest21;
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                result.Add(new GraphViewModel
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                    Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                    Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                                });
                                                amount -= principal11;
                                                i++;
                                                //SumI +=  interest11 ;
                                                //SumP +=  interest11 ;
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Convert.ToDouble(Payment).ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal21.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            SumI += interest21;
                                            SumP += Convert.ToDouble(Payment);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime2 = DT.AddMonths(i - 1);
                                        double principal2 = Convert.ToDouble(Payment) - amount * monthlyRate;
                                        double interest2 = amount * monthlyRate;
                                        balance -= principal2;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime2.Date.ToString("dd/MM/yyyy"),
                                            Payment = Convert.ToDouble(Payment).ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal2.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest2.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        amount -= principal2;
                                        i++;
                                        SumI += interest2;
                                        SumP += Convert.ToDouble(Payment);

                                    }
                                    while ((amount - Convert.ToDouble(Payment)) > 0);

                                    DateTime dateTime3 = DT.AddMonths(i - 1);
                                    double interest3 = amount * monthlyRate;
                                    double principal3 = amount * monthlyRate;

                                    balance -= amount;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                        Payment = (interest3 + amount).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = amount.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest3.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    SumI += interest3;
                                    SumP += interest3 + amount;
                                    amount -= principal3;
                                    i = x;
                                }
                                #endregion
                                #region reggadasaxadi naklebiapeimentze
                                else
                                {
                                    while (i < 3)
                                    {
                                        // DateTime dateTime1 = FirstPaymentDate.AddMonths(i);
                                        // double principal = Convert.ToDouble(PMT()) - amount * monthlyRate;
                                        //double Rate = amount * monthlyRate;
                                        //balance -= principal;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = StartDate.Date.ToString("dd/MM/yyyy"),
                                            Payment = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interesetIpayment.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        i++;
                                        SumP += interesetIpayment;
                                        SumI += interesetIpayment;
                                        if (Convert.ToDouble(interestonly) > 0)
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            //double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            //balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            SumI += interest21;
                                            SumP += interest21;
                                            // amount -= principal21;
                                            i++;

                                            while (i <= (interestonly + 1))
                                            {
                                                DateTime dateTime11 = DT.AddMonths(i);
                                                double principal11 = 0;
                                                double interest11 = monthlyRate * amount;
                                                balance -= principal11;
                                                result.Add(new GraphViewModel
                                                {
                                                    PaymentNumber = (i).ToString(),
                                                    Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                                    Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                    Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                                    Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                                });
                                                amount -= principal11;
                                                i++;
                                                SumI += interest11;
                                                SumP += interest11;
                                            }
                                        }
                                        else
                                        {
                                            double rate = Convert.ToDouble(AnnualRate) / 36500 * CountDaysFromStartDateToNextPayment();

                                            DateTime dateTime21 = DT.AddMonths(i - 1);
                                            double principal21 = Convert.ToDouble(Payment) - amount * rate;
                                            double interest21 = amount * rate;
                                            balance -= principal21;
                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = (i).ToString(),
                                                Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                                Payment = Convert.ToDouble(Payment).ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal21.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                            });
                                            SumI += interest21;
                                            SumP += Convert.ToDouble(Payment);
                                            amount -= principal21;
                                            i++;
                                        }
                                    }

                                    do
                                    {
                                        DateTime dateTime3 = DT.AddMonths(i - 1);
                                        double interest3 = amount * monthlyRate;
                                        double principal3 = Convert.ToDouble(Payment) - amount * monthlyRate;

                                        balance -= principal3;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime3.Date.ToString("dd/MM/yyyy"),
                                            Payment = Convert.ToDouble(Payment).ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal3.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest3.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        SumI += interest3;
                                        SumP += Convert.ToDouble(Payment);
                                        amount -= principal3;
                                        i++;
                                    } while (i < CountMonthsEndRelease());
                                    DateTime dateTime4 = DT.AddMonths(i - 1);
                                    double interest4 = amount * monthlyRate;
                                    double principal4 = amount;

                                    balance -= amount;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                        Payment = amount + interest4.ToString("N", CultureInfo.InvariantCulture),
                                        Principal = amount.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest4.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    SumI += interest4;
                                    SumP += amount + interest4;
                                    amount -= principal4;
                                    i = x;
                                }
                                #endregion


                            }
                        }
                    }
                    #endregion

                    #region pirveli gadaxda maleveaa
                    else
                    {
                        DateTime date = StartDate.Date.AddMonths(CountMonthsFromFirstToStart());

                        for (int i = 1; i <= y; i++)
                        {
                            while (i < 3)
                            {
                                DateTime dateTime1 = FirstPaymentDate;
                                int N = (FirstPaymentDate - StartDate).Days;
                                double rate = Convert.ToDouble(AnnualRate) / 36500 * N * Convert.ToDouble(LoanAmount);
                                double principal0 = Convert.ToDouble(RegularPayment) - rate;
                                //  double interest0 = amount * monthlyRate;
                                balance -= principal0;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal0.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = rate.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                amount -= principal0;
                                i++;
                                SumP += Convert.ToDouble(RegularPayment);
                                SumI += interesetIpayment;

                                if (Convert.ToDouble(interestonly) > 0)
                                {

                                    DateTime dateTime21 = date.AddMonths(i - 1);
                                    int n = (dateTime21 - FirstPaymentDate).Days;
                                    double rate0 = Convert.ToDouble(AnnualRate) / 36500 * n;

                                    double interest21 = amount * rate0;
                                    double principal21 = 0;

                                    balance -= principal21;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                        Payment = interest21.ToString("N", CultureInfo.InvariantCulture),
                                        Principal = 0.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    //SumI +=  interest21 ;
                                    //SumP +=  interest21 ;
                                    amount -= principal21;
                                    i++;





                                    while (i <= (interestonly + 1))
                                    {
                                        DateTime dateTime11 = date.AddMonths(i - 1);
                                        double principal11 = 0;
                                        double interest11 = monthlyRate * amount;
                                        balance -= principal11;
                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = (i).ToString(),
                                            Date = dateTime11.Date.ToString("dd/MM/yyyy"),
                                            Payment = interest11.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal11.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest11.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)
                                        });
                                        amount -= principal11;
                                        i++;
                                        //SumI +=  interest11 ;
                                        //SumP +=  interest11 ;
                                    }
                                }
                                else
                                {
                                    DateTime dateTime21 = date.AddMonths(i - 1);
                                    int n = (dateTime21 - FirstPaymentDate).Days;
                                    double rate0 = Convert.ToDouble(AnnualRate) / 36500 * n;
                                    double principal21 = Convert.ToDouble(Payment) - amount * rate0;
                                    double interest21 = amount * rate0;
                                    balance -= principal21;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i).ToString(),
                                        Date = dateTime21.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal21.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest21.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    SumI += interest21;
                                    SumP += Convert.ToDouble(RegularPayment);
                                    amount -= principal21;
                                    i++;
                                }
                            }
                            while (balance - Convert.ToDouble(RegularPayment) > 0)
                            {
                                DateTime dateTime4 = date.AddMonths(i - 1);
                                double principal4 = Convert.ToDouble(RegularPayment) - amount * monthlyRate;
                                double interest4 = amount * monthlyRate;
                                balance -= principal4;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i).ToString(),
                                    Date = dateTime4.Date.ToString("dd/MM/yyyy"),
                                    Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal4.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest4.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                                });
                                SumI += interest4;
                                SumP += Convert.ToDouble(RegularPayment);
                                amount -= principal4;
                                i++;
                            }

                            DateTime dateTime = date.AddMonths(i - 1);
                            double principal = amount;
                            double Rate = amount * monthlyRate;
                            balance -= amount;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = (i).ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = (amount + Rate).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = (balance).ToString("N", CultureInfo.InvariantCulture)
                            });
                            SumI += Rate;
                            SumP += (amount + Rate);
                            amount -= principal;
                            i = y;
                        }
                        #endregion

                        #endregion
                    }
                }
                //ItemsMonthlySum.Add(new GraphViewModel
                //{
                //    InterestSum =  SumI .ToString(),
                //    PeymentSum =  SumP .ToString(),
                //    sumSum = Math.Round(SumP / SumI .ToString()
                //});
            }
            catch (Exception)
            {
                //_ex = "შეავსეთ ველი მხოლოდ ციფრებით (მაგ: 34.5)";
            }
            return result;
        }

        public List<GraphViewModel> GetGraphViewModel()
        {
            var data = GraphMonthly();
            var model = GraphViewModel.GetViewModel(data);
            return model;
        }
    }
}
