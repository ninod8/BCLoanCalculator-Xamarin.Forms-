using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class FlatMonthly : ContentPage
    {
        public FlatMonthly()
        {
            InitializeComponent();
            BindingContext = new FlatRateMonthlyCalc();
            #region Interface
            DP0.Date = DateTime.Today.Date;
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            LabelFontFamily(MainLabel);
            LabelFontFamily(FlatMonthlyAnnualRateLabel);
            LabelFontFamily(FlatMonthlyEndDateLabel);
            LabelFontFamily(FlatMonthlyFirstPaymentLabel);
            LabelFontFamily(FlatMonthlyLoanAmountLabel);
            LabelFontFamily(FlatMonthlyPaymentLabel);
            LabelFontFamily(FlatMonthlyRateLabel);
            LabelFontFamily(FlatMonthlyStartDateLabel);
            LabelFontFamily(FlatMonthlyTermLabel);
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            FlatMonthlyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyAnnualRateLabel.FontSize = 14;
            FlatMonthlyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyEndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyEndDateLabel.FontSize = 14;
            FlatMonthlyFirstPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyFirstPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyFirstPaymentLabel.FontSize = 14;
            FlatMonthlyLoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyLoanAmountLabel.FontSize = 14;
            FlatMonthlyLoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyPaymentLabel.FontSize = 14;
            FlatMonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyRateLabel.FontSize = 14;
            FlatMonthlyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyStartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyStartDateLabel.FontSize = 14;
            FlatMonthlyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatMonthlyTermLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatMonthlyTermLabel.FontSize = 14;
            #endregion
            Btn.TextColor = Color.White;
            Btn.BackgroundColor = Color.FromRgb(2, 117, 157);
            Btn.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewFlatMonthly());
            };
        }
        public class FlatRateMonthlyCalc : INotifyPropertyChanged
        {
            #region privateVariables
            private string loanAmount;
            private string termsOfLoan;
            private string monthlyRate;
            private string annualRate;
            private string payment;
            private DateTime startDate;
            private DateTime endDate;
            private DateTime firstPaymentDate;


            #endregion

            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            public string LoanAmount
            {
                get { return loanAmount; }
                set { loanAmount = value; }
            }

            public string TermsOfLoan
            {
                get { return termsOfLoan; }
                set { termsOfLoan = value; }
            }

            public string MonthlyRate
            {
                get { return monthlyRate; }
                set
                {
                    monthlyRate = value;
                    annualRate = Math.Round((Convert.ToDouble(monthlyRate) * 12), 3, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(nameof(AnnualRate));
                    OnPropertyChanged();
                }
            }

            public string AnnualRate
            {
                get { return annualRate; }
                set
                {
                    annualRate = value;
                    monthlyRate = Math.Round((Convert.ToDouble(annualRate) / 12), 3, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(MonthlyRate));
                }
            }

            public string Payment
            {
                get { return payment; }
                set { payment = value; }
            }

            public DateTime StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }

            public DateTime EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }

            public DateTime FirstPaymentDate
            {
                get { return firstPaymentDate; }
                set { firstPaymentDate = value; }
            }

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
}
