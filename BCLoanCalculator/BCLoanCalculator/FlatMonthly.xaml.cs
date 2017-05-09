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
    public partial class FlatMonthly : ContentPage
    {
        public FlatRateMonthlyModel Model
        {
            get
            {
                return BindingContext as FlatRateMonthlyModel;
            }
        }
        public FlatMonthly()
        {
            InitializeComponent();
            BindingContext = new FlatRateMonthlyModel();
            Color color = Color.FromRgb(2, 117, 157);
            #region Interface
            string cultureName = "ka-GE";
            var locale = new Java.Util.Locale(cultureName);
            Java.Util.Locale.Default = locale;
            App.LabelFontFamily(MainLabel);
            App.LabelFontFamily(AnnualRateLabel);
            App.LabelFontFamily(EndDateLabel);
            App.LabelFontFamily(FirstPaymentLabel);
            App.LabelFontFamily(LoanAmountLabel);
            App.LabelFontFamily(PaymentLabel);
            App.LabelFontFamily(MonthlyRateLabel);
            App.LabelFontFamily(StartDateLabel);
            App.LabelFontFamily(TermLabel);
            RegularPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            RegularPaymentLabel.TextColor = color;
            RegularPaymentLabel.FontSize = 14;
            App.LabelFontFamily(RegularPaymentLabel);
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = color;
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            AnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnualRateLabel.TextColor = color;
            AnnualRateLabel.FontSize = 14;
            EndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            EndDateLabel.TextColor = color;
            EndDateLabel.FontSize = 14;
            FirstPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            FirstPaymentLabel.TextColor = color;
            FirstPaymentLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.FontSize = 14;
            LoanAmountLabel.TextColor = color;
            PaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            PaymentLabel.TextColor = color;
            PaymentLabel.FontSize = 14;
            MonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            MonthlyRateLabel.TextColor = color;
            MonthlyRateLabel.FontSize = 14;
            StartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            StartDateLabel.TextColor = color;
            StartDateLabel.FontSize = 14;
            TermLabel.VerticalTextAlignment = TextAlignment.Center;
            TermLabel.TextColor = color;
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
            Btn.BackgroundColor = color;
            App.ButtonFontFamily(Btn);
            Btn.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewFlatMonthly(Model.GetGraphViewModel()));
            };
            AnnualRateEntry.Completed += AnnualRateEntry_Completed;
            MonthlyRateEntry.Completed += MonthlyRateEntry_Completed;
        }

        private void MonthlyRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(MonthlyRateEntry.Text) == true)

            {
                AnnualRateEntry.Text = Math.Round(Convert.ToDecimal(MonthlyRateEntry.Text) * 12, 3, MidpointRounding.AwayFromZero).ToString() ;
            }
        }

        private void AnnualRateEntry_Completed(object sender, EventArgs e)
        {

            if (App.Parse(AnnualRateEntry.Text) == true)

            {
                MonthlyRateEntry.Text = Math.Round(Convert.ToDecimal(AnnualRateEntry.Text) / 12, 3, MidpointRounding.AwayFromZero).ToString() ;
            }
        }
    }
}
