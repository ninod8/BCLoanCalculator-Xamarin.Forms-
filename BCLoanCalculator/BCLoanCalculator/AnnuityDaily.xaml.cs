using System;
using System.Globalization;
using Xamarin.Forms;
using BCLoanCalculator.Models;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BCLoanCalculator
{
    public partial class AnnuityDaily : ContentPage
    {
        public AnnuityDailyModel Model
        {
            get
            {
                return BindingContext as AnnuityDailyModel;
            }
        }

        public AnnuityDaily()
        {
          //  var userSelectedCulture = new CultureInfo("ka-GE");
            InitializeComponent();
            BindingContext = new AnnuityDailyModel();
            Color color = Color.FromRgb(2, 117, 157);
            string cultureName = "ka-GE";
            var locale = new Java.Util.Locale(cultureName);
        Java.Util.Locale.Default= locale;
            Financial.Pmt(2,3,4,5);
            ToolbarItems.Add(new ToolbarItem("X", "X", () =>
           {
               TermsOfLoanEntry.Text = string.Empty;
               LoanAmountEntry.Text = string.Empty;
               DP1.Date = DateTime.Today;
               DP2.Date = DateTime.Today;
               PaymentEntry.Text = string.Empty;
               InterestOnlyEntry.Text = string.Empty;
               AnnualRateEntry.Text = string.Empty;
               DailyRateEntry.Text = string.Empty;
               AnnualRateEntry.Placeholder = string.Empty;
               DailyRateEntry.Placeholder = string.Empty;
           }));
            Label1.IsVisible = false;
            Label2.IsVisible = false;
            Label3.IsVisible = false;
            #region Interface
            MainLabel.TextColor = color;
            MainLabel.FontSize = 17;
            App.LabelFontFamily(MainLabel);
            App.LabelFontFamily(AnnuityDailyAnnualRateLabel);
            App.LabelFontFamily(AnnuityDailyDailyRateLabel);
            App.LabelFontFamily(AnnuityDailyEndDateLabel);
            App.LabelFontFamily(AnnuityDailyInterestOnlyLabel);
            App.LabelFontFamily(AnnuityDailyPaymentLabel);
            App.LabelFontFamily(AnnuityDailyStartDateLabel);
            App.LabelFontFamily(AnnuityDailyTermLabel);
            App.LabelFontFamily(LoanAmountLabel);


            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.TextColor = color;
            AnnuityDailyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = color;
            LoanAmountLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyDailyRateLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.TextColor = color;
            AnnuityDailyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyEndDateLabel.TextColor = color;
            AnnuityDailyEndDateLabel.FontSize = 14;
            AnnuityDailyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyInterestOnlyLabel.TextColor = color;
            AnnuityDailyInterestOnlyLabel.FontSize = 14;
            AnnuityDailyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyPaymentLabel.TextColor = color;
            AnnuityDailyPaymentLabel.FontSize = 14;
            AnnuityDailyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyStartDateLabel.TextColor = color;
            AnnuityDailyStartDateLabel.FontSize = 14;
            AnnuityDailyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyTermLabel.TextColor = color;
            AnnuityDailyTermLabel.FontSize = 14;
            RegularPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            RegularPaymentLabel.TextColor = color;
            RegularPaymentLabel.FontSize = 14;
            App.LabelFontFamily(RegularPaymentLabel);
            CalculateGraph.BackgroundColor = color;
            CalculateGraph.TextColor = Color.White;
            App.ButtonFontFamily(CalculateGraph);
            App.EntryFontFamily(PaymentEntry);
            App.LabelFontFamily(Label1);
            App.LabelFontFamily(Label2);
            App.LabelFontFamily(Label3);

            #endregion


            CalculateGraph.Clicked += async(sender, e) =>
            {
                var btn = sender as Button;
            
              
                     await App.NavigateMasterDetail(new GridViewAnnnuityDaily(Model.GetGraphViewModel()));

                 

            };

            PaymentEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
              {

                  var model = BindingContext as AnnuityDailyModel;
                  //if (model.PMT().HasValue)
                  //{
                  //    decimal paymentSum = model.PMT().Value * model.TermsOfLoan;
                  //    decimal rateSum = paymentSum - model.LoanAmount.Value;
                  //    Label1.IsVisible = true;
                  //    Label2.IsVisible = true;
                  //    Label1.Text = "გადახდების ჯამი: " + paymentSum.ToString("N", CultureInfo.InvariantCulture);
                  //    Label2.Text = "პროცენტის ჯამი: " + rateSum.ToString("N", CultureInfo.InvariantCulture);
                  //}
              };
            PaymentEntry.Completed += PaymentEntry_Completed;
            DailyRateEntry.Completed += DailyRateEntry_Completed;
            AnnualRateEntry.Completed += AnnualRateEntry_Completed;

        }

        private void PaymentEntry_Completed(object sender, EventArgs e)
        {
            var model = BindingContext as AnnuityDailyModel;
            TermsOfLoanEntry.Text = model.Nper().ToString();
        }

        private void AnnualRateEntry_Completed(object sender, EventArgs e)

        {
            if (App.Parse(AnnualRateEntry.Text) == true)

            {
                DailyRateEntry.Text = Math.Round(Convert.ToDecimal(AnnualRateEntry.Text) / 365, 3, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void DailyRateEntry_Completed(object sender, EventArgs e)
        {
            if (App.Parse(DailyRateEntry.Text) == true)
            {
                AnnualRateEntry.Text = Math.Round(Convert.ToDecimal(DailyRateEntry.Text) * 365, 3, MidpointRounding.AwayFromZero).ToString();
            }
        }


    }
}
