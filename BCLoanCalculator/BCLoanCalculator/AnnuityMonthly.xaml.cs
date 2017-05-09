using BCLoanCalculator.Models;
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
        public AnnuityMonthlyModel Model
        {
            get
            {
                return BindingContext as AnnuityMonthlyModel;
            }
        }
        public AnnuityMonthly()
        {
            InitializeComponent();
            BindingContext = new AnnuityMonthlyModel();
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
            Color color = Color.FromRgb(2, 117, 157);
            string cultureName = "ka-GE";
            var locale = new Java.Util.Locale(cultureName);
            Java.Util.Locale.Default = locale;
            App.LabelFontFamily(LoanAmountLabel);
            App.LabelFontFamily(MainLabel);
            App.LabelFontFamily(AnnuityMonthlyTermLabel);
            App.LabelFontFamily(AnnuityMonthlyAnnualRateLabel);
            App.LabelFontFamily(EndDateLabel);
            App.LabelFontFamily(FirstPaymentDateLabel);
            App.LabelFontFamily(AnnuityMonthlyInterestOnlyLabel);
            App.LabelFontFamily(AnnuityMonthlyMonthlyRateLabel);
            App.LabelFontFamily(AnnuityMonthlyPaymentLabel);
            App.LabelFontFamily(StartDateLabel);
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = color;
            MainLabel.FontSize = 17;
            RegularPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            RegularPaymentLabel.TextColor = color;
            RegularPaymentLabel.FontSize = 14;
            App.LabelFontFamily(RegularPaymentLabel);
            FirstPaymentDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FirstPaymentDateLabel.TextColor = color;
            FirstPaymentDateLabel.FontSize = 14;
            AnnuityMonthlyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyAnnualRateLabel.TextColor = color;
            AnnuityMonthlyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = color;
            LoanAmountLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyMonthlyRateLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.TextColor = color;
            EndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            EndDateLabel.TextColor = color;
            EndDateLabel.FontSize = 14;
            AnnuityMonthlyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyInterestOnlyLabel.TextColor = color;
            AnnuityMonthlyInterestOnlyLabel.FontSize = 14;
            AnnuityMonthlyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyPaymentLabel.TextColor = color;
            AnnuityMonthlyPaymentLabel.FontSize = 14;
            StartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            StartDateLabel.TextColor = color;
            StartDateLabel.FontSize = 14;
            AnnuityMonthlyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyTermLabel.TextColor = color;
            AnnuityMonthlyTermLabel.FontSize = 14;
            #endregion
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewAnnuityMonthly(Model.GetGraphViewModel()));
            };
            Btn.TextColor = Color.White;
            Btn.BackgroundColor = color;
            App.ButtonFontFamily(Btn);
            MonthlyRateEntry.Completed += MonthlyRateEntry_Completed;
            AnnualRateEntry.Completed += AnnualRateEntry_Completed;
            PaymentEntry.Completed += PaymentEntry_Completed;
        }

        private void PaymentEntry_Completed(object sender, EventArgs e)
        {
            var model = BindingContext as AnnuityMonthlyModel;
           TermsOfLoanEntry.Text= model.Nper().ToString();
        }

        private void AnnualRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(AnnualRateEntry.Text) == true)
            {
                MonthlyRateEntry.Text = Math.Round(Convert.ToDecimal(AnnualRateEntry.Text) / 12, 3, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void MonthlyRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(MonthlyRateEntry.Text)==true)
            {
            AnnualRateEntry.Text = Math.Round(Convert.ToDecimal(MonthlyRateEntry.Text) * 12, 3, MidpointRounding.AwayFromZero).ToString();
            }
        }
    }
}