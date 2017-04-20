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
using Microsoft.VisualBasic;


namespace BCLoanCalculator
{
    public partial class AnnuityDaily : ContentPage
    {
        public AnnuityDailyCalc LD { get; set; }

        public AnnuityDaily()
        {
            InitializeComponent();
            this.BindingContext = LD;

            BindingContext = new AnnuityDailyCalc();
            LD = BindingContext as AnnuityDailyCalc;
            ToolbarItems.Add(new ToolbarItem("X", "X",  () =>
            {
                // var page = new ContentPage();
                //  new AnnuityDaily();
                TermsOfLoanEntry.Text = string.Empty;
                LoanAmountEntry.Text = string.Empty;
                DP1.Date = DateTime.Today;
                DP2.Date = DateTime.Today.Date;
                PaymentEntry.Text = string.Empty;
                InterestOnlyEntry.Text = string.Empty;
                AnnualRateEntry.Text = string.Empty;
                DailyRateEntry.Text = string.Empty;
                AnnualRateEntry.Placeholder = string.Empty;
                DailyRateEntry.Placeholder = string.Empty;
            }));
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
            Btn.BackgroundColor = Color.FromRgb(2, 117, 157);
            Btn.TextColor = Color.White;
            Btn.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
            #endregion

            AnnualRateEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
                {
                    try
                    { 
                        DailyRateEntry.Text = "";
                        //double j = ;
                        string g = Math.Round((Convert.ToDouble(AnnualRateEntry.Text) / 365), 3, MidpointRounding.AwayFromZero).ToString("N", CultureInfo.InvariantCulture);
                        DailyRateEntry.Placeholder = g + "%"; 
                      // App.data =  AnnualRateEntry.Text;
                      
                    }
                    catch (Exception)
                    {


                    }

                };
            Btn.Clicked += async (sender, e) =>
            {
                var btn = sender as Button;
                await App.NavigateMasterDetail(new GridViewAnnnuityDaily());
            };
            DailyRateEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
              {
                  try
                  {
                      AnnualRateEntry.Text = "";
                      string g = Math.Round((Convert.ToDouble(DailyRateEntry.Text) * 365), 3, MidpointRounding.AwayFromZero).ToString("N", CultureInfo.InvariantCulture);
                      AnnualRateEntry.Placeholder = g + "%";
                      App.AnnualRateAD = AnnualRateEntry.Placeholder;
                  }
                  catch (Exception)
                  {

                  }

              };
            // AnnuityDailyEntry.Placeholder=
        }
        public void LabelFontFamily(Label label)
        {
            label.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
        }

    }
    public class AnnuityDailyCalc : INotifyPropertyChanged
    {
        #region privateVariables
        private string loanAmount = App.LoanAmountAD;
        private string termsOfLoan=App.TermAD;
        private string dailyRate=App.DailyRateAD;
        private string annualRate=App.AnnualRateAD;
        private string payment=App.PaymentAD;
        private DateTime startDate=App.StartDateAD;
        private DateTime endDate=App.EndDateAD;
        private string interestOnly=App.InterestOnlyAD;



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
                    App.LoanAmountAD = value;
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
                    App.TermAD = value;
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
                    App.DailyRateAD = value;
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
                    App.AnnualRateAD = value;
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
                App.PaymentAD = value;
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
                    App.StartDateAD = value;
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
                    App.EndDateAD = value;
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
                    App.InterestOnlyAD = value;
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
