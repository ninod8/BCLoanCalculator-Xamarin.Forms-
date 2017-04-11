﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class FlatDaily : ContentPage
    {
        public FlatDaily()
        {
            InitializeComponent();
            BindingContext = new FlatRateDailyCalc();
            #region Interface
            LabelFontFamily(MainLabel);
            LabelFontFamily(FlatDailyAnnualRateLabel);
            LabelFontFamily(FlatDailyEndDateLabel);
            LabelFontFamily(FlatDailyPaymentLabel);
            LabelFontFamily(FlatDailyRateLabel);
            LabelFontFamily(FlatDailyStartDateLabel);
            LabelFontFamily(FlatDailyTermLabel);
        //    LabelFontFamily();
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            FlatDailyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyAnnualRateLabel.FontSize = 14;
            FlatDailyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyEndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyEndDateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            LoanAmountLabel.FontSize = 14;
            FlatDailyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyPaymentLabel.FontSize = 14;
            FlatDailyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyRateLabel.FontSize = 14;
            FlatDailyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyStartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyStartDateLabel.FontSize = 14;
            FlatDailyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyTermLabel.TextColor = Color.FromRgb(2, 117, 157);
            FlatDailyTermLabel.FontSize = 14;
            #endregion
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewFlatDaily());
            };
            Btn.TextColor = Color.White;
            Btn.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
            Btn.BackgroundColor = Color.FromRgb(2, 117, 157);

        }
        public class FlatRateDailyCalc : INotifyPropertyChanged
        {
            #region privateVariables
            private string loanAmount;
            private string termsOfLoan;
            private string dailyRate;
            private string annualRate;
            private string payment;
            private DateTime startDate;
            private DateTime endDate;


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

            public string DailyRate
            {
                get { return dailyRate; }
                set
                {
                    try
                    {
                        dailyRate = value;
                        annualRate = Math.Round((Convert.ToDouble(dailyRate) * 365), 3, MidpointRounding.AwayFromZero).ToString();
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(AnnualRate));
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
                        DailyRate = Math.Round((Convert.ToDouble(annualRate) / 365), 3, MidpointRounding.AwayFromZero).ToString();
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(DailyRate));
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
