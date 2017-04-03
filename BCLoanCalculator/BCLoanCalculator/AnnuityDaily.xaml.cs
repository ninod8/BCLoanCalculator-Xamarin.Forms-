using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.DataTransfer;
using UIKit;

namespace BCLoanCalculator
{
    public partial class AnnuityDaily : ContentPage
    {
        public AnnuityDaily()
        {

            InitializeComponent();
            //var ld = this.BindingContext as AnnuityDailyCalc;
            //    AnnualRateEntry.Text = ld.AnnualRate;
            BindingContext = new AnnuityDailyCalc();
            //UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            //{
            //    Font = UIFont.FromName("HelveticaNeue-Light", 20),
            //   // TextColor = App.NavBarTextTint.ToUIColor()
            //});
            //  var data = data as AnnuityDailyCalc;
            #region Interface
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            LabelFontFamily(MainLabel);
            LabelFontFamily(AnnuityDailyAnnualRateLabel);
            LabelFontFamily(AnnuityDailyDailyRateLabel);
            LabelFontFamily(AnnuityDailyEndDateLabel);
            LabelFontFamily(AnnuityDailyInterestOnlyLabel);
            LabelFontFamily(AnnuityDailyPaymentLabel);
            LabelFontFamily(AnnuityDailyStartDateLabel);
            LabelFontFamily(AnnuityDailyTermLabel);
            LabelFontFamily(LoanAmountLabel);
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            LoanAmountLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyDailyRateLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyEndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyEndDateLabel.FontSize = 14;
            AnnuityDailyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyInterestOnlyLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyInterestOnlyLabel.FontSize = 14;
            AnnuityDailyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyPaymentLabel.FontSize = 14;
            AnnuityDailyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyStartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyStartDateLabel.FontSize = 14;
            AnnuityDailyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyTermLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyTermLabel.FontSize = 14;
            AnnualRateEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
                {
                    try
                    {
                        DailyRateEntry.Text = "";
                        //double j = ;
                        string g = Math.Round((Convert.ToDouble(AnnualRateEntry.Text) / 365), 3, MidpointRounding.AwayFromZero).ToString("N", CultureInfo.InvariantCulture);
                        DailyRateEntry.Placeholder = g + "%";
                    }
                    catch (Exception)
                    {

                    }

                };
            DailyRateEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
              {
                  try
                  {
                      AnnualRateEntry.Text = "";
                      string g = Math.Round((Convert.ToDouble(DailyRateEntry.Text) * 365), 3, MidpointRounding.AwayFromZero).ToString("N", CultureInfo.InvariantCulture);
                      AnnualRateEntry.Placeholder = g + "%";
                  }
                  catch (Exception)
                  {

                  }

              };
            // AnnuityDailyEntry.Placeholder=
            #endregion
        }
        public void LabelFontFamily(Label label)
        {
            label.FontFamily = Device.OnPlatform(
                                                null,
                                                 "spparliamentmt_bold.ttf#spparliamentmt_bold", // Android
                                                  null
                                                );
            //label.FontAttributes = FontAttributes.Bold;

        }

    }
    public class AnnuityDailyCalc : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string dailyRate;
        private string annualRate;
        private string payment;
        private DateTime startDate;
        private DateTime endDate;
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
                try
                {
                    loanAmount = value;
                    //  if (Convert.ToDouble(payment) > 0)
                    //  {
                    //      termsOfLoan = NperDaily();
                    //  }
                    //else
                    payment = PMT();

                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {
                    loanAmount = "";
                }

            }
        }

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set
            {
                try
                {
                    termsOfLoan = value;
                    endDate = startDate.Date.AddDays(Convert.ToDouble(termsOfLoan));
                    // if (Convert.ToDouble(payment) > 0)
                    // {
                    //     termsOfLoan = NperDaily();
                    // }
                    //else
                    payment = PMT();
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
                catch (Exception)
                {
                    endDate = DateTime.Today;
                }
            }
        }

        public string DailyRate
        {
            get { return dailyRate; }
            set
            {
                try
                {
                    dailyRate = value;
                    payment = PMT();

                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {
                    dailyRate = "";
                }
            }
        }


        public string AnnualRate
        {
            get { return annualRate; }
            set
            {
                try
                {
                    annualRate = value;

                    payment = PMT();

                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {
                    annualRate = "";
                }
            }
        }


        public string Payment
        {
            get { return payment; }
            set
            {
                payment = value;

                try
                {
                    //if (Convert.ToDouble(payment) > 0)
                    //{
                    //    termsOfLoan = NperDaily();
                    //}
                    OnPropertyChanged(nameof(TermsOfLoan));
                }
                catch (Exception)
                {
                    termsOfLoan = "";
                }
            }
        }


        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                try
                {
                    startDate = value;
                    termsOfLoan = CountDays();
                    // if (Convert.ToDouble(payment) > 0)
                    // {
                    //     termsOfLoan = NperDaily();
                    // }
                    //else
                    payment = PMT();
                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {
                    termsOfLoan = "";
                }
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                try
                {
                    endDate = value;
                    termsOfLoan = CountDays();
                    //if (Convert.ToDouble(payment) > 0)
                    //{
                    //    termsOfLoan = NperDaily();
                    //}
                    //else 
                    payment = PMT();

                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {
                    termsOfLoan = "";
                }
            }
        }

        public string InterestOnly
        {
            get { return interestOnly; }
            set
            {
                try
                {
                    interestOnly = value;
                    //if (Convert.ToDouble(payment) > 0)
                    //{
                    //    termsOfLoan = NperDaily();
                    //}
                    //else
                    payment = PMT();

                    OnPropertyChanged(nameof(LoanAmount));
                    OnPropertyChanged(nameof(DailyRate));
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged(nameof(Payment));
                    OnPropertyChanged(nameof(EndDate));
                    OnPropertyChanged(nameof(StartDate));
                    OnPropertyChanged(nameof(TermsOfLoan));
                    OnPropertyChanged(nameof(InterestOnly));
                }
                catch (Exception)
                {

                    interestOnly = "";
                }

            }
        }

        public string CountDays()
        {

            int days = (endDate - startDate).Days;
            if (days == 0) return "";
            return days.ToString();

        }

        public string PMT()
        {
            try
            {
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnly))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnly);
                double rate = Convert.ToDouble(DailyRate) / 100;
                double pmt = Convert.ToDouble(LoanAmount) * Convert.ToDouble(rate) / (1 - (1 / (Math.Pow(Convert.ToDouble(rate + 1), Convert.ToDouble(TermsOfLoan) - interestonly))));

                if (!Double.IsNaN(pmt) && !Double.IsInfinity(pmt) && pmt != 0)
                {
                    return Math.Round(pmt, 2, MidpointRounding.AwayFromZero).ToString("N", CultureInfo.InvariantCulture);
                }
                else return "";
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string NperDaily()
        {
            double nper = 0;
            try
            {
                double rate = Convert.ToDouble(DailyRate) / 100;
                nper = -Math.Log((1 - (rate * Convert.ToDouble(LoanAmount) / Convert.ToDouble(Payment))), Math.E) / Math.Log((1 + rate), Math.E);
                return Convert.ToInt32(nper).ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
