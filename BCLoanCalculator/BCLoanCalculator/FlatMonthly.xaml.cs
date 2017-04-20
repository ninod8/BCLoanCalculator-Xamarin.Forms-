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
            LabelFontFamily(AnnualRateLabel);
            LabelFontFamily(EndDateLabel);
            LabelFontFamily(FirstPaymentLabel);
            LabelFontFamily(LoanAmountLabel);
            LabelFontFamily(PaymentLabel);
            LabelFontFamily(MonthlyRateLabel);
            LabelFontFamily(StartDateLabel);
            LabelFontFamily(TermLabel);
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            AnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnualRateLabel.FontSize = 14;
            EndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            EndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            EndDateLabel.FontSize = 14;
            FirstPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FirstPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            FirstPaymentLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.FontSize = 14;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            PaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            PaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            PaymentLabel.FontSize = 14;
            MonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            MonthlyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            MonthlyRateLabel.FontSize = 14;
            StartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            StartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            StartDateLabel.FontSize = 14;
            TermLabel.VerticalTextAlignment = TextAlignment.Center;
            TermLabel.TextColor = Color.FromRgb(2, 117, 157);
            TermLabel.FontSize = 14;
            #endregion
            ToolbarItems.Add(new ToolbarItem("X", "X", () =>
            {
                // var page = new ContentPage();
                //  new AnnuityDaily();
                TermsOfLoanEntry.Text = string.Empty;
                LoanAmountEntry.Text = string.Empty;
                DP1.Date = DateTime.Today.Date;
                DP2.Date = DateTime.Today.Date;
                DP0.Date = DateTime.Today.Date;
                PaymentEntry.Text = string.Empty;
                AnnualRateEntry.Text = string.Empty;
                MonthlyRateEntry.Text = string.Empty;
                AnnualRateEntry.Placeholder = string.Empty;
                MonthlyRateEntry.Placeholder = string.Empty;
                PaymentEntry.Text = string.Empty;
            }));
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
            private string loanAmount = App.LoanAmountFM;
            private string termsOfLoan = App.TermFM;
            private string monthlyRate = App.MonthlyRateFM;
            private string annualRate = App.AnnualRateFM;
            private string payment = App.PaymentFM;
            private DateTime startDate = App.StartDateFM;
            private DateTime endDate = App.EndDateFM;
            private DateTime firstPaymentDate = App.ReleaseDateFM;


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
                    App.LoanAmountFM = value;
                }
            }

            public string TermsOfLoan
            {
                get { return termsOfLoan; }
                set
                {
                    termsOfLoan = value;
                    App.TermFM = value;
                }
            }

            public string MonthlyRate
            {
                get { return monthlyRate; }
                set
                {
                    monthlyRate = value;
                    App.MonthlyRateFM = value;

                   // annualRate = Math.Round((Convert.ToDouble(monthlyRate) * 12), 3, MidpointRounding.AwayFromZero).ToString();
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
                    App.AnnualRateFM = value;

                  //  monthlyRate = Math.Round((Convert.ToDouble(annualRate) / 12), 3, MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(MonthlyRate));
                }
            }

            public string Payment
            {
                get { return payment; }
                set
                {
                    payment = value;
                    App.PaymentFM = value;

                }
            }

            public DateTime StartDate
            {
                get { return startDate; }
                set
                {
                    startDate = value;
                    App.StartDateFM = value;

                }
            }

            public DateTime EndDate
            {
                get { return endDate; }
                set
                {
                    endDate = value;
                    App.EndDateFM = value;

                }
            }

            public DateTime FirstPaymentDate
            {
                get { return firstPaymentDate; }
                set
                {
                    firstPaymentDate = value;
                    App.ReleaseDateFM = value;
                }
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
