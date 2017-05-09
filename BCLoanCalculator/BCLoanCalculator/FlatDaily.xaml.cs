using BCLoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class FlatDaily : ContentPage
    {
        public FlatRateDailyModel Model
        {
            get
            {
                return BindingContext as FlatRateDailyModel;
            }
        }
        public FlatDaily()
        {
            InitializeComponent();
            BindingContext = new FlatRateDailyModel();

            Color color = Color.FromRgb(2, 117, 157);
            string cultureName = "ka-GE";
            var locale = new Java.Util.Locale(cultureName);
            Java.Util.Locale.Default = locale;
            #region Interface
            App.LabelFontFamily(MainLabel);
            App.LabelFontFamily(LoanAmountLabel);
            App.LabelFontFamily(FlatDailyAnnualRateLabel);
            App.LabelFontFamily(FlatDailyEndDateLabel);
            App.LabelFontFamily(FlatDailyPaymentLabel);
            App.LabelFontFamily(FlatDailyRateLabel);
            App.LabelFontFamily(FlatDailyStartDateLabel);
            App.LabelFontFamily(FlatDailyTermLabel);
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = color;
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            RegularPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            RegularPaymentLabel.TextColor = color;
            RegularPaymentLabel.FontSize = 14;
            App.LabelFontFamily(RegularPaymentLabel);
            FlatDailyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyAnnualRateLabel.TextColor = color;
            FlatDailyAnnualRateLabel.FontSize = 14;
            FlatDailyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyEndDateLabel.TextColor = color;
            FlatDailyEndDateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = color;
            LoanAmountLabel.FontSize = 14;
            FlatDailyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyPaymentLabel.FontSize = 14;
            FlatDailyPaymentLabel.TextColor = color;
            FlatDailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyRateLabel.TextColor = color;
            FlatDailyRateLabel.FontSize = 14;
            FlatDailyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyStartDateLabel.TextColor = color;
            FlatDailyStartDateLabel.FontSize = 14;
            FlatDailyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            FlatDailyTermLabel.TextColor = color;
            FlatDailyTermLabel.FontSize = 14;
            #endregion
            ToolbarItems.Add(new ToolbarItem("X", "X", () =>
            {
                // var page = new ContentPage();
                //  new AnnuityDaily();
                TermsOfLoanEntry.Text = string.Empty;
                LoanAmountEntry.Text = string.Empty;
                DP1.Date = DateTime.Today;
                DP2.Date = DateTime.Today.Date;
                PaymentEntry.Text = string.Empty;
                AnnualRateEntry.Text = string.Empty;
                DailyRateEntry.Text = string.Empty;
                AnnualRateEntry.Placeholder = string.Empty;
                DailyRateEntry.Placeholder = string.Empty;
                PaymentEntry.Text = string.Empty;
            }));
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewFlatDaily(Model.GetGraphViewModel()));
            };
            Btn.TextColor = Color.White;
            App.ButtonFontFamily(Btn);
            Btn.BackgroundColor = color;
            AnnualRateEntry.Completed += AnnualRateEntry_Completed;
            DailyRateEntry.Completed += DailyRateEntry_Completed;
            TermsOfLoanEntry.Completed += TermsOfLoanEntry_Completed;

        }

        private void TermsOfLoanEntry_Completed(object sender, EventArgs e)
        {
        }

        private void DailyRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(DailyRateEntry.Text) == true)
            {
                AnnualRateEntry.Text = Math.Round(Convert.ToDecimal(DailyRateEntry.Text) * 365, 3, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void AnnualRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(AnnualRateEntry.Text) == true)

            {
                DailyRateEntry.Text = Math.Round(Convert.ToDecimal(AnnualRateEntry.Text) / 365, 3, MidpointRounding.AwayFromZero).ToString();

            }
        }
    }
}
