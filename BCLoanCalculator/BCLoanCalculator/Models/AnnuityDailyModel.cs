using Microsoft.VisualBasic;
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
    public class AnnuityDailyModel : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string dailyRate;
        private string annualRate;
        private string payment;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;
        private string interestOnly;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string LoanAmount
        {
            get { return loanAmount; }
            set
            {
                loanAmount = value;
                //if (Nper().HasValue)
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
            }
        }

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set
            {
                termsOfLoan = value;

                if (App.Parse(value) == true)
                {
                    endDate = startDate.Date.AddDays(Convert.ToDouble(termsOfLoan));
                }
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
                OnPropertyChanged();
            }
        }

        public string DailyRate
        {
            get { return dailyRate; }
            set
            {
                dailyRate = value;
                if (string.IsNullOrEmpty(value))
                {
                    annualRate = string.Empty;
                }
                //if (App.Parse(dailyRate) == true)
                //{
                //    annualRate = Math.Round(Convert.ToDecimal(dailyRate) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                //if (App.Parse(payment) == true && Nper().HasValue && PMT() == null)
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
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
                    dailyRate = string.Empty;
                }
                //if (App.Parse(annualRate) == true)
                //{
                //    dailyRate = Math.Round(Convert.ToDecimal(annualRate) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                //if (App.Parse(payment) == true && Nper().HasValue && PMT() == null)
                //{
                //    termsOfLoan = Nper().Value.ToString();
                //}
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
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
                OnPropertyChanged();

            }
        }

        private string regularPayment;

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
                if (CountDays().HasValue)
                {
                    termsOfLoan = CountDays().ToString();

                }
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                if (CountDays().HasValue)
                {
                    TermsOfLoan = CountDays().ToString();

                }
                if (PMT().HasValue)
                {
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));
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
                    payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture);
                }

                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(AnnualRate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(InterestOnly));

            }
        }

        public int? CountDays()
        {
            return (endDate - startDate).Days;
        }

        public decimal? PMT()
        {
            try
            {
                if (App.Parse(DailyRate) == true && App.Parse(LoanAmount) == true && App.Parse(TermsOfLoan) == true && Convert.ToDecimal(DailyRate) != 0)
                {
                    decimal interestOnly = 0;
                    if (App.Parse(InterestOnly) == true && !string.IsNullOrEmpty(InterestOnly))
                    {
                        interestOnly = Convert.ToDecimal(InterestOnly);
                    }
                    decimal rate = Convert.ToDecimal(DailyRate) / 100;
                    decimal pmt = Convert.ToDecimal(LoanAmount) * rate / (decimal)(1 - (1 / Math.Pow((double)rate + 1, (double)Convert.ToDecimal(TermsOfLoan) - (double)Convert.ToDecimal(interestOnly))));
                    decimal val = pmt;
                    return val;
                }
                else
                {
                    return null;
                }
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
                if (App.Parse(Payment) == true && App.Parse(DailyRate) == true && App.Parse(LoanAmount) == true && PMT() == null && Convert.ToDecimal(DailyRate) != 0)
                {
                    try
                    {
                        decimal rate = Convert.ToDecimal(DailyRate) / 100;
                        decimal val = 1 - (rate * Convert.ToDecimal(LoanAmount) / Convert.ToDecimal(Payment));
                        decimal val2 = (decimal)Math.Log((double)(1 + rate), Math.E);
                        decimal nper = (decimal)-Math.Log((double)val, Math.E) / val2;
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

                return null;
            }

        }
        public List<GraphViewModel> GraphDaily()
        {
            var result = new List<GraphViewModel>();
            try
            {
                // CultureInfo ci = new CultureInfo("en-US");
                //double sumI = 0;
                //double sumP = 0;
                double amount = Convert.ToDouble(LoanAmount);
                double balance = Convert.ToDouble(LoanAmount);
                double dailyInterest = Convert.ToDouble(DailyRate) / 100;
                int term = Convert.ToInt32(TermsOfLoan) - 1;


                int interestonly;
                if (String.IsNullOrEmpty(InterestOnly))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnly);

                for (int i = 0; i < Convert.ToInt32(TermsOfLoan); i++)
                {
                    if (App.Parse(RegularPayment) == true && Convert.ToDecimal(RegularPayment) > 0)
                    {
                        if (Convert.ToDouble(PMT()) < Convert.ToDouble(RegularPayment))
                        {
                            do
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
                                    {
                                        i++;
                                        DateTime dateTime10 = StartDate.AddDays(i);
                                        double interest10 = amount * dailyInterest;
                                        double principal10 = 0.00;
                                        balance = Convert.ToDouble(LoanAmount);

                                        result.Add(new GraphViewModel
                                        {
                                            PaymentNumber = i.ToString(),
                                            Date = dateTime10.Date.ToString("dd/MM/yyyy"),
                                            Payment = interest10.ToString("N", CultureInfo.InvariantCulture),
                                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                            Principal = principal10.ToString("N", CultureInfo.InvariantCulture),
                                            Rate = interest10.ToString("N", CultureInfo.InvariantCulture),
                                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                                        });
                                        amount = Convert.ToDouble(LoanAmount);
                                        //sumI += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                        //sumP += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                    }
                                }
                                DateTime dateTime = StartDate.AddDays(i + 1);
                                double interest = amount * dailyInterest;
                                double principal = (double)Convert.ToDecimal(RegularPayment) - interest;
                                balance -= principal;

                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i + 1).ToString(),
                                    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    Payment = Convert.ToDecimal(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                                });
                                amount -= principal;
                                i++;
                                //sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                //sumP += Convert.ToDouble(RegularPayment);
                            }
                            while ((balance - Convert.ToDouble(RegularPayment)) > 0);
                            DateTime dateTime1 = StartDate.AddDays(i + 1);
                            double interest1 = amount * dailyInterest;
                            double principal1 = balance;
                            balance -= principal1;

                            result.Add(new GraphViewModel
                            {
                                PaymentNumber = (i + 1).ToString(),
                                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                Payment = (interest1 + amount).ToString("N", CultureInfo.InvariantCulture),
                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                Rate = interest1.ToString("N", CultureInfo.InvariantCulture),
                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                            });
                            amount -= principal1;
                            //sumP += Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero);
                            //sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            i = Convert.ToInt32(TermsOfLoan);

                        }
                        else
                        {
                            if ((Convert.ToDouble(PMT()) >= Convert.ToDouble(RegularPayment)))
                            {
                                while (i < term)
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i < Convert.ToDouble(interestonly))
                                        {
                                            i++;
                                            DateTime dateTime12 = StartDate.AddDays(i);
                                            double interest12 = amount * dailyInterest;
                                            double principal12 = 0.00;
                                            balance = Convert.ToDouble(LoanAmount);

                                            result.Add(new GraphViewModel
                                            {
                                                PaymentNumber = i.ToString(),
                                                Date = dateTime12.Date.ToString("dd/MM/yyyy"),
                                                Payment = interest12.ToString("N", CultureInfo.InvariantCulture),
                                                EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                                Principal = principal12.ToString("N", CultureInfo.InvariantCulture),
                                                Rate = interest12.ToString("N", CultureInfo.InvariantCulture),
                                                StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                                            });
                                            amount = Convert.ToDouble(LoanAmount);
                                            //sumI += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);
                                            //sumP += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);

                                        }
                                    }
                                    DateTime dateTime = StartDate.AddDays(i + 1);
                                    double interest = amount * dailyInterest;
                                    double principal = Convert.ToDouble(RegularPayment) - interest;
                                    balance -= principal;

                                    result.Add(new GraphViewModel
                                    {
                                        PaymentNumber = (i + 1).ToString(),
                                        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                        Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                        EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                        Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                                        Rate = interest.ToString("N", CultureInfo.InvariantCulture),
                                        StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                                    });
                                    amount -= principal;
                                    i++;
                                    //sumP += Math.Round(Convert.ToDouble(RegularPayment), 2, MidpointRounding.AwayFromZero);
                                    //sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                }
                                DateTime dateTime1 = StartDate.AddDays(i + 1);
                                double interest1 = Math.Round(amount * dailyInterest, 2, MidpointRounding.AwayFromZero);
                                double principal1 = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
                                balance -= principal1;

                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = (i + 1).ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = (interest1 + amount).ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest1.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)

                                });
                                amount -= principal1;
                                //sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                //sumP += Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero);
                            }
                            //else
                            //{
                            //    if (Convert.ToDouble(interestonly) > 0)
                            //    {
                            //        while (i < Convert.ToDouble(interestonly))
                            //        {
                            //            i++;
                            //            DateTime dateTime1 = StartDate.AddDays(i);
                            //            double interest1 = amount * dailyInterest;
                            //            double principal1 = 0.00;
                            //            balance = Convert.ToDouble(LoanAmount);

                            //            result.Add(new GraphViewModel
                            //            {

                            //                PaymentNumber = i.ToString(),
                            //                Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                            //                Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                            //                EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                            //                Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                            //                Rate = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                            //                StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()

                            //            });
                            //            amount = Convert.ToDouble(LoanAmount);
                            //            sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            //            sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            //        }
                            //    }

                            //    DateTime dateTime = StartDate.AddDays(i + 1);
                            //    double interest = amount * dailyInterest;
                            //    double principal = Convert.ToDouble(PMT()) - interest;
                            //    balance -= principal;

                            //    result.Add(new GraphViewModel
                            //    {
                            //        PaymentNumber = (i + 1).ToString(),
                            //        Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            //        Payment = Math.Round(Convert.ToDouble(PMT()), 2, MidpointRounding.AwayFromZero).ToString(),
                            //        EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                            //        Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                            //        Rate = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                            //        StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()


                            //    });
                            //    amount -= principal;
                            //    sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                            //    sumP += Math.Round(Convert.ToDouble(PMT()), 2, MidpointRounding.AwayFromZero);
                            //}
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(interestonly) > 0)
                        {
                            while (i < Convert.ToDouble(interestonly))
                            {
                                i++;
                                DateTime dateTime1 = StartDate.AddDays(i);
                                double interest1 = amount * dailyInterest;
                                double principal1 = 0.00;
                                balance = Convert.ToDouble(LoanAmount);

                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = interest1.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest1.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)


                                });
                                amount = Convert.ToDouble(LoanAmount);
                                //sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                //sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            }
                        }

                        DateTime dateTime = StartDate.AddDays(i + 1);
                        double interest = amount * dailyInterest;
                        double principal = Convert.ToDouble(PMT()) - interest;
                        balance -= principal;

                        result.Add(new GraphViewModel
                        {
                            PaymentNumber = (i + 1).ToString(),
                            Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            Payment = PMT().Value.ToString("N", CultureInfo.InvariantCulture),
                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture),
                            Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                            Rate = interest.ToString("N", CultureInfo.InvariantCulture),
                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture)


                        });
                        amount -= principal;
                        //sumI += interest;
                        // sumP += Math.Round(Convert.ToDouble(PMT()), 2, MidpointRounding.AwayFromZero);
                    }
                }
                //ItemsSum.Add(new GridItem()
                //{
                //    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                //    PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString(),
                //    sumSum = Math.Round(sumP / sumI, 2, MidpointRounding.AwayFromZero).ToString()
                //});

            }
            catch (Exception)
            {
            }
            return result;
        }

        public List<GraphViewModel> GetGraphViewModel()
        {

            var data = GraphDaily();
            var model = GraphViewModel.GetViewModel(data);
            return model;
        }

        //private List<GraphViewModel> GetTestGraph()
        //{
        //    var data = new List<GraphViewModel>
        //    {

        //    };

        //    return data;
        //}
    }
}
