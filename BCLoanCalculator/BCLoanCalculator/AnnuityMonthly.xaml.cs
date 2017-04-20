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
    public partial class AnnuityMonthly : ContentPage
    {
        public AnnuityMonthly()
        {
            InitializeComponent();
            BindingContext = new AnnuityMonthlyCalc();
            ToolbarItems.Add(new ToolbarItem("X", "X", () =>
            {
                // var page = new ContentPage();
                //  new AnnuityDaily();
                TermsOfLoanEntry.Text = string.Empty;
                LoanAmountEntry.Text = string.Empty;
                DP1.Date = DateTime.Today;
                DP2.Date = DateTime.Today.Date;
                DP0.Date = DateTime.Today.Date;
                PaymentEntry.Text = string.Empty;
                InterestOnlyEntry.Text = string.Empty;
                AnnualRateEntry.Text = string.Empty;
                MonthlyRateEntry.Text = string.Empty;
                AnnualRateEntry.Placeholder = string.Empty;
                MonthlyRateEntry.Placeholder = string.Empty;
            }));
            #region Interface
            DP0.Date = DateTime.Today.Date;
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            LabelFontFamily(LoanAmountLabel);
            LabelFontFamily(MainLabel);
            LabelFontFamily(AnnuityMonthlyTermLabel);
            LabelFontFamily(AnnuityMonthlyAnnualRateLabel);
            LabelFontFamily(EndDateLabel);
            LabelFontFamily(FirstPaymentDateLabel);
            LabelFontFamily(AnnuityMonthlyInterestOnlyLabel);
            LabelFontFamily(AnnuityMonthlyMonthlyRateLabel);
            LabelFontFamily(AnnuityMonthlyPaymentLabel);
            LabelFontFamily(StartDateLabel);

            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            FirstPaymentDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FirstPaymentDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FirstPaymentDateLabel.FontSize = 14;
            AnnuityMonthlyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            LoanAmountLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyMonthlyRateLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            EndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            EndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            EndDateLabel.FontSize = 14;
            AnnuityMonthlyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyInterestOnlyLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyInterestOnlyLabel.FontSize = 14;
            AnnuityMonthlyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyPaymentLabel.FontSize = 14;
            StartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            StartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            StartDateLabel.FontSize = 14;
            AnnuityMonthlyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyTermLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyTermLabel.FontSize = 14;
            #endregion
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewAnnuityMonthly());
            };
            Btn.TextColor = Color.White;
            Btn.BackgroundColor = Color.FromRgb(2, 117, 157);

            Btn.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );

        }
        public class AnnuityMonthlyCalc:INotifyPropertyChanged
        {
            #region privateVariables
            private string loanAmount = App.LoanAmountAM;
            private string termsOfLoan=App.TermAM;
            private string monthlyRate=App.MonthlyRateAM;
            private string annualRate=App.AnnualRateAM;
            private string payment=App.PaymentAM;
            private DateTime startDate=App.StartDateAM;
            private DateTime endDate=App.EndDateAM;
            private DateTime firstPaymentDate=App.ReleaseDateAM;
            private string interestOnly=App.InterestOnlyAM;


            #endregion
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string name="")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            public string LoanAmount
            {
                get { return loanAmount; }
                set
                {
                    loanAmount = value;
                    App.LoanAmountAM = value;
                }
            }

            public string TermsOfLoan
            {
                get { return termsOfLoan; }
                set
                {
                    termsOfLoan = value;
                    App.TermAM = value;

                }
            }

            public string MonthlyRate
            {
                get { return monthlyRate; }
                set
                {
                    monthlyRate = value;
                    App.MonthlyRateAM = value;
                   // annualRate = Math.Round((Convert.ToDouble(monthlyRate) * 12),3,MidpointRounding.AwayFromZero).ToString();
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
                    App.AnnualRateAM = value;

                    //  monthlyRate = Math.Round((Convert.ToDouble(annualRate) / 12),3,MidpointRounding.AwayFromZero).ToString();
                    OnPropertyChanged(nameof(monthlyRate));
                    OnPropertyChanged();
                }
            }

            public string Payment
            {
                get { return payment; }
                set
                {
                    payment = value;
                    App.PaymentAM = value;

                }
            }

            public DateTime StartDate
            {
                get { return startDate; }
                set
                {
                    startDate = value;
                    App.StartDateAM = value;
                }
            }

            public DateTime EndDate
            {
                get { return endDate; }
                set
                {
                    endDate = value;
                    App.EndDateAM = value;
                }
            }

            public DateTime FirstPaymentDate
            {
                get { return firstPaymentDate; }
                set
                {
                    firstPaymentDate = value;
                    App.ReleaseDateAM = value;

                }
            }

            public string InterestOnly
            {
                get { return interestOnly; }
                set
                {
                    interestOnly = value;
                    App.InterestOnlyAM = value;
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
