using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace BCLoanCalculator.Models
{
    public class FlatRateDailyModel : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string dailyRate;
        private string annualRate;
        private string payment;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;

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
                if (App.Parse(loanAmount) == true && App.Parse(TermsOfLoan) == true && App.Parse(DailyRate) == true)
                {
                    if (Convert.ToDecimal(DailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);
                    }
                }
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged();
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
                    endDate = startDate.AddDays(Convert.ToInt32(termsOfLoan));
                }
                if (App.Parse(LoanAmount) == true && App.Parse(termsOfLoan) == true && App.Parse(DailyRate) == true)
                {

                    if (Convert.ToDecimal(DailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
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
                //if (App.Parse(value) == true)
                //{
                //    dailyRate =  Convert.ToDecimal(annualRate) * 365, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                if (App.Parse(TermsOfLoan) == true && App.Parse(DailyRate) == true && App.Parse(LoanAmount) == true)
                {

                    if (Convert.ToDecimal(dailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(AnnualRate));
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
                //if (App.Parse(value) == true)
                //{
                //    dailyRate =  Convert.ToDecimal(annualRate) / 365, 3, MidpointRounding.AwayFromZero).ToString();
                //}
                if (App.Parse(annualRate) == true && App.Parse(TermsOfLoan) == true && App.Parse(LoanAmount) == true)
                {
                    if (Convert.ToDecimal(DailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(Payment));
            }
        }

        public string Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(AnnualRate));
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
                if (CountDaysForFlat().HasValue)
                {
                    termsOfLoan = CountDaysForFlat().ToString();
                }
                if (App.Parse(TermsOfLoan) == true && App.Parse(DailyRate) == true && App.Parse(LoanAmount) == true)
                {

                    if (Convert.ToDecimal(DailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);

                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(AnnualRate));
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                if (CountDaysForFlat().HasValue)
                {
                    termsOfLoan = CountDaysForFlat().ToString();

                }
                if (App.Parse(TermsOfLoan) == true && App.Parse(DailyRate) == true && App.Parse(LoanAmount) == true)
                {
                    if (Convert.ToDecimal(DailyRate) > 0 && Convert.ToInt32(TermsOfLoan) > 0)
                    {
                        payment = FlatDaily().Value.ToString("N", CultureInfo.InvariantCulture);
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(DailyRate));
                OnPropertyChanged(nameof(TermsOfLoan));
                OnPropertyChanged(nameof(LoanAmount));
                OnPropertyChanged(nameof(Payment));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(AnnualRate));
            }
        }
        public int? CountDaysForFlat()
        {
            return (EndDate - StartDate).Days;
        }
        public decimal? FlatDaily()
        {
            try
            {
                decimal? rate = Convert.ToDecimal(DailyRate) * Convert.ToInt32(TermsOfLoan) / 100;
                decimal? flatPayment = (Convert.ToDecimal(LoanAmount) + (rate * Convert.ToDecimal(LoanAmount))) / Convert.ToInt32(TermsOfLoan);
                if (flatPayment.HasValue)
                {
                    return flatPayment;
                }
                else return null;

            }
            catch (Exception)
            {

                return null;
            }

        }
        public int CountDaysForFlatDaily()
        {
            return (EndDate - StartDate).Days;
        }
        public List<GraphViewModel> GraphFlatRateDaily()
        {
            var result = new List<GraphViewModel>();

            try
            {
                double sumI = 0;
                double sump = 0;
                double amount = Convert.ToDouble(LoanAmount);
                double rate = Convert.ToDouble(DailyRate) * Convert.ToDouble(TermsOfLoan) / 100;
                double balance = Convert.ToDouble(LoanAmount);

                for (int i = 1; i <= Convert.ToDouble(TermsOfLoan); i++)
                {
                    if (App.Parse(RegularPayment) == true)
                    {
                        if (Convert.ToDouble(RegularPayment) < Convert.ToDouble(FlatDaily()))
                        {
                            double interest0 = Convert.ToDouble(LoanAmount) * rate / Convert.ToDouble(TermsOfLoan);
                            do
                            {
                                DateTime dateTime1 = StartDate.AddDays(i);
                                double principal1 = Convert.ToDouble(RegularPayment) - interest0;
                                // double interest1 = Convert.ToDouble(Payment) - principal1;
                                balance -= principal1;
                                result.Add(new GraphViewModel
                                {
                                    PaymentNumber = i.ToString(),
                                    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                    Payment = Convert.ToDouble(RegularPayment).ToString("N", CultureInfo.InvariantCulture),
                                    Principal = principal1.ToString("N", CultureInfo.InvariantCulture),
                                    Rate = interest0.ToString("N", CultureInfo.InvariantCulture),
                                    StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                                    EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                                });
                                amount -= principal1;
                                i++;
                                sumI += interest0;
                                sump += Convert.ToDouble(RegularPayment);

                            } while (i < Convert.ToDouble(TermsOfLoan));

                            DateTime dateTime = StartDate.AddDays(i);
                            double principal = amount;
                            // double Rate = Convert.ToDouble(Payment) - principal;
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
                            sumI += interest0;
                            sump += amount + interest0;

                        }
                        else
                        {
                            result.Clear();
                        }
                    }
                    else
                    {
                        DateTime dateTime = StartDate.AddDays(i);
                        double principal = Convert.ToDouble(LoanAmount) / Convert.ToDouble(TermsOfLoan);
                        double Rate = Convert.ToDouble(Payment) - principal;
                        balance -= principal;
                        result.Add(new GraphViewModel
                        {
                            PaymentNumber = i.ToString(),
                            Date = dateTime.Date.ToString("dd/MM/yyyy"),
                            Payment = Convert.ToDouble(FlatDaily()).ToString("N", CultureInfo.InvariantCulture),
                            Principal = principal.ToString("N", CultureInfo.InvariantCulture),
                            Rate = Rate.ToString("N", CultureInfo.InvariantCulture),
                            StartingBalance = amount.ToString("N", CultureInfo.InvariantCulture),
                            EndingBalance = balance.ToString("N", CultureInfo.InvariantCulture)
                        });
                        amount -= principal;
                        sumI += Rate;
                        sump += Convert.ToDouble(FlatDaily());
                    }
                }
                //FlatDailyItemsSum.Add(new GraphViewModel
                //{
                //    InterestSum =  sumI .ToString(),
                //    PeymentSum =  sump .ToString(),
                //    sumSum =  sump / sumI .ToString()
                //});
                if (App.Parse(RegularPayment) == true)
                {
                    if (Convert.ToDouble(RegularPayment) > Convert.ToDouble(FlatDaily()))
                    {
                        result.Clear();
                        //FlatDailyItemsSum.Clear();
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
            var data = GraphFlatRateDaily();
            var model = GraphViewModel.GetViewModel(data);
            return model;
        }
    }

}
