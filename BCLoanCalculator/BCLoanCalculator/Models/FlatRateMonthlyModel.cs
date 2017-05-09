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
    public class FlatRateMonthlyModel : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string monthlyRate;
        private string annualRate;
        private string payment;
        private string regularPayment;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;
        private DateTime firstPaymentDate = DateTime.Today.AddMonths(1);


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
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));

            }
        }

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set
            {
                termsOfLoan = value;
                if (App.Parse(termsOfLoan) == true)
                {
                    endDate = StartDate.AddMonths(Convert.ToInt32(termsOfLoan));
                }
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);

                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
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
                //if (App.Parse(value) == true && !string.IsNullOrEmpty(value))
                //{
                //    annualRate = Math.Round(Convert.ToDecimal(monthlyRate) * 12, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
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
                //if (App.Parse(value) == true && !string.IsNullOrEmpty(value))
                //{
                //    monthlyRate = Math.Round(Convert.ToDecimal(annualRate) / 12, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
            }
        }

        public string Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
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
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
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
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
            }
        }

        public DateTime FirstPaymentDate
        {
            get { return firstPaymentDate; }
            set
            {
                firstPaymentDate = value;
                if (CountTermsOfLoan().HasValue)
                {
                    termsOfLoan = CountTermsOfLoan().Value.ToString();
                }
                if (App.Parse(LoanAmount) == true && App.Parse(AnnualRate) == true && App.Parse(TermsOfLoan) == true)
                {
                    payment = FPayment().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(FirstPaymentDate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(MonthlyRate));
                OnPropertyChanged(nameof(Payment));
            }
        }
        public int? CountMonths()
        {
            return (EndDate.Month - FirstPaymentDate.Month) + 12 * (EndDate.Year - FirstPaymentDate.Year);
        }
        public int CounterForFlat()
        {
            return (FirstPaymentDate - StartDate).Days;
        }

        public int? CountTermsOfLoan()
        {
            return (EndDate.Month - StartDate.Month) + 12 * (EndDate.Year - StartDate.Year);
        }
        public decimal? FPayment()
        {
            try
            {
                decimal? flatPayment;
                decimal? rate = 0;

                rate = Convert.ToDecimal(AnnualRate) / 1200;
                if (startDate.Date == firstPaymentDate.Date)
                {
                    flatPayment = Math.Round((decimal)(rate * Convert.ToDecimal(LoanAmount) + Convert.ToDecimal(LoanAmount) / CountMonths()), 2, MidpointRounding.AwayFromZero);
                }
                else flatPayment = Math.Round((decimal)(rate * Convert.ToDecimal(LoanAmount) + Convert.ToDecimal(LoanAmount) / (CountMonths() + 1)), 2, MidpointRounding.AwayFromZero);

                if (flatPayment.HasValue)
                {
                    return flatPayment;
                }
                else return null;
            }
            catch (Exception)
            {
                return null; throw;
            }


        }
        public int CountMonthsForFlatStartEnd()
        {
            return (EndDate.Month - FirstPaymentDate.Month) + 12 * (EndDate.Year - FirstPaymentDate.Year) + 1;
        }
        public int CountMonthsFromStartToReleaseFlat()
        {
            return (FirstPaymentDate.Month - StartDate.Month) + 12 * (FirstPaymentDate.Year - StartDate.Year);
        }

        public List<GraphViewModel> GraphFlatRateMonthly()
        {
            var result = new List<GraphViewModel>();
            try
            {
                double SumI = 0;
                double SumP = 0;

                //result.Clear();
                double amount = Convert.ToDouble(LoanAmount);
                double balance = Convert.ToDouble(LoanAmount);
                double rate;
                double principal;

                #region star=rel
                if (FirstPaymentDate.Date == StartDate.Date.AddDays(1).AddMonths(1).AddDays(-1))
                {
                    for (int i = 1; i <= Convert.ToDouble(TermsOfLoan); i++)
                    {
                        if (App.Parse(RegularPayment) == true)
                        {
                            if (Convert.ToDouble(RegularPayment) < Convert.ToDouble(FPayment()))
                            {
                                rate = Convert.ToDouble(MonthlyRate) / 100;
                                double interest0 = Convert.ToDouble(LoanAmount) * rate;
                                do
                                {
                                    DateTime dateTime1 = StartDate.AddMonths(i);
                                    //double total = Convert.ToDouble(LoanAmount) * (1 + rate);
                                    principal = Convert.ToDouble(RegularPayment) - interest0;
                                    balance -= principal;
                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = i.ToString(),
                                        Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest0.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                    });
                                    amount -= principal;
                                    i++;
                                    SumI += interest0;
                                    SumP += Convert.ToDouble(RegularPayment);
                                } while (Convert.ToDouble(TermsOfLoan) > i);

                                DateTime dateTime = StartDate.AddMonths(i);
                                //double total = Convert.ToDouble(LoanAmount) * (1 + rate);
                                double principal1 = Convert.ToDouble(RegularPayment) - interest0;

                                principal = balance;
                                balance -= principal;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    Payment = (amount + interest0).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest0.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                amount -= principal;
                                i++;
                                SumI += interest0;
                                SumP += (amount + interest0);
                            }
                            else
                            {
                                result.Clear();
                            }
                        }
                        else
                        {
                            rate = Convert.ToDouble(MonthlyRate) / 100 * Convert.ToDouble(LoanAmount);

                            DateTime dateTime = StartDate.AddMonths(i - 1);
                            principal = Convert.ToDouble(LoanAmount) / CountMonthsForFlatStartEnd();
                            balance -= principal;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Convert.ToDouble(FPayment()).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                Rate = rate.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            amount -= principal;
                            SumI += rate;
                            SumP += Convert.ToDouble(FPayment());
                        }
                    }
                }
                #endregion
                else
                {
                    for (int i = 1; i <= CountMonthsForFlatStartEnd(); i++)
                    {

                        while (i < 3)
                        {

                            DateTime dateTime1 = FirstPaymentDate;

                            rate = Convert.ToDouble(AnnualRate) / 365 * CounterForFlat() / 100;
                            double principal1 = Convert.ToDouble(LoanAmount) / CountMonthsForFlatStartEnd();
                            double interest1 = Convert.ToDouble(LoanAmount) * rate;
                            balance -= principal1;
                            if (rate * Convert.ToDouble(LoanAmount) > Convert.ToDouble(FPayment()))
                            {
                                principal = 0;
                            }
                            //double peyment = interest1 + principal1;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Date = FirstPaymentDate.Date.ToString("dd/MM/yyyy"),
                                Payment = (principal1 + interest1).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                Rate = interest1.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            amount -= principal1;
                            i++;
                            SumI += interest1;
                            SumP += principal1 + interest1;

                            DateTime dateTime12 = StartDate.Date.AddMonths(CountMonthsFromStartToReleaseFlat() + 1);
                            int N = (dateTime12 - FirstPaymentDate).Days;
                            double rate2 = Convert.ToDouble(AnnualRate) / 36500 * N;
                            double principal12 = Convert.ToDouble(LoanAmount) / CountMonthsForFlatStartEnd();
                            double interest12 = Convert.ToDouble(LoanAmount) * rate2;
                            balance -= principal1;
                            //double peyment = interest1 + principal1;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime12.Date.ToString("dd/MM/yyyy"),
                                Payment = (principal12 + interest12).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                Rate = interest12.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            amount -= principal1;
                            i++;
                            SumI += interest12;
                            SumP += principal12 + interest12;
                        }
                        if (App.Parse(RegularPayment) == true)
                        {

                            do
                            {
                                rate = Convert.ToDouble(MonthlyRate) / 100;
                                DateTime dateTime111 = StartDate.AddMonths(i - 1);
                                principal = Convert.ToDouble(RegularPayment) - rate * Convert.ToDouble(LoanAmount);
                                if (rate * Convert.ToDouble(LoanAmount) > Convert.ToDouble(FPayment()))
                                {
                                    principal = 0;
                                }

                                balance -= principal;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime111.Date.ToString("dd/MM/yyyy"),
                                    Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = (Convert.ToDouble(RegularPayment) - principal).ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                amount -= principal;
                                i++;
                                //SumI +=  Convert.ToDouble(RegularPayment) - principal);
                                //SumP +=  Convert.ToDouble(RegularPayment) ;
                            }
                            while (i < CountMonthsForFlatStartEnd());

                            double Rrate = Convert.ToDouble(MonthlyRate) / 100.00;

                            DateTime dateTime = StartDate.AddMonths(i - 1);
                            principal = amount;
                            double interesetii = Rrate * Convert.ToDouble(LoanAmount);
                            balance -= principal;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = (interesetii + amount).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                Rate = interesetii.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            amount -= principal;
                            i++;
                            //SumI +=  interesetii ;
                            //SumP +=  interesetii + amount ;
                        }
                        else
                        {
                            rate = Convert.ToDouble(MonthlyRate) / 100;

                            DateTime dateTime = StartDate.AddMonths(i - 1);
                            principal = Convert.ToDouble(LoanAmount) / CountMonthsForFlatStartEnd();
                            balance -= principal;
                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = i.ToString(),
                                Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                Payment = Convert.ToDouble(FPayment()).ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                Rate = (Convert.ToDouble(FPayment()) - principal).ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                            });
                            amount -= principal;
                            SumP += Convert.ToDouble(FPayment());
                            SumI += (Convert.ToDouble(FPayment()) - principal);
                        }
                    }
                    if (Convert.ToDouble(Payment) > Convert.ToDouble(FPayment()))
                    {
                        result.Clear();
                    }
                }
                //FlatPercentageItemsSum.Add(new GraphViewModel
                //{
                //    InterestSum =  SumI .ToString(),
                //    PeymentSum =  SumP .ToString(),
                //    sumSum =  SumP / SumI .ToString()
                //});


                if (App.Parse(RegularPayment) == true)
                {
                    if (Convert.ToDouble(RegularPayment) > Convert.ToDouble(FPayment()))
                    {
                        result.Clear();
                    }
                }


            }
            catch (Exception)
            {
            }
            return result;
        }

        public List<GraphViewModel> GetGraphViewModel()
        {
            var data = GraphFlatRateMonthly();
            var model = GraphViewModel.GetViewModel(data);
            return model;
        }
    }
}
