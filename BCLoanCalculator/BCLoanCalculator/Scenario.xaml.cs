using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO.Compression;
using Xamarin.Forms;
using BCLoanCalculator.Models;

namespace BCLoanCalculator
{
    public partial class Scenario : ContentPage
    {
        public ScenarioModel Model
        {
            get
            {
                return BindingContext as ScenarioModel;
            }
        }
        public Scenario()
        {
            InitializeComponent();
            BindingContext = new ScenarioModel();

            App.LabelFontFamily(LoanAmountLabel);
            App.LabelFontFamily(StartDateLabel);
            App.LabelFontFamily(EndDateLabel);
            App.LabelFontFamily(ScenarioLabel);
            App.LabelFontFamily(TermLabel);
            //App.LabelFontFamily(DailyRateLabel);
            App.LabelFontFamily(AnnualRateLabel);
            App.LabelFontFamily(PenaltyRateLabel);
            App.LabelFontFamily(PaymentLabel);
            //App.LabelFontFamily(RegularPaymentLabel);

            Color color = Color.FromRgb(2, 117, 157);

            ToolbarItems.Add(new ToolbarItem("X", "X", () =>
            {
                LoanAmountEntry.Text = string.Empty;
                TermsOfScenarioEntry.Text = string.Empty;
                DP1.Date = DateTime.Today;
                DP2.Date = DateTime.Today;
                TermsOfLoanEntry.Text = string.Empty;
                //DailyRateEntry.Text = string.Empty;
                AnnualRateEntry.Text = string.Empty;
                PenaltyRateEntry.Text = string.Empty;
                PaymentEntry.Placeholder = string.Empty;
                //RegularPaymentEntry.Placeholder = string.Empty;
            }));
            TermsOfScenarioEntry.Completed += TermsOfScenarioEntry_Completed;            
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = color;
            MainLabel.FontSize = 17;
            App.LabelFontFamily(MainLabel);

            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = color;
            LoanAmountLabel.FontSize = 14;

            StartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            StartDateLabel.TextColor = color;
            StartDateLabel.FontSize = 14;

            EndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            EndDateLabel.TextColor = color;
            EndDateLabel.FontSize = 14;

            ScenarioLabel.VerticalTextAlignment = TextAlignment.Center;
            ScenarioLabel.TextColor = color;
            ScenarioLabel.FontSize = 14;

            TermLabel.VerticalTextAlignment = TextAlignment.Center;
            TermLabel.TextColor = color;
            TermLabel.FontSize = 14;

            //DailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            //DailyRateLabel.TextColor = color;
            //DailyRateLabel.FontSize = 14;

            AnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnualRateLabel.TextColor = color;
            AnnualRateLabel.FontSize = 14;

            PenaltyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            PenaltyRateLabel.TextColor = color;
            PenaltyRateLabel.FontSize = 14;

            PaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            PaymentLabel.TextColor = color;
            PaymentLabel.FontSize = 14;

            //RegularPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            //RegularPaymentLabel.TextColor = color;
            //RegularPaymentLabel.FontSize = 14;
            DP2.DateSelected += DP2_DateSelected;
            DP1.DateSelected += DP1_DateSelected;
            CalculateGraph.BackgroundColor = color;
            CalculateGraph.TextColor = Color.White;
            App.ButtonFontFamily(CalculateGraph);
            CalculateGraph.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewScenario(Model.GetGraphViewModel()));
            };
          

        }

        private void TermsOfScenarioEntry_Completed(object sender, EventArgs e)
        {
            DP2.Date = DP1.Date.AddDays(Convert.ToInt32(TermsOfLoanEntry.Text));
        }

        private void DP1_DateSelected(object sender, DateChangedEventArgs e)
        {
            TermsOfLoanEntry.Text = (DP2.Date - DP1.Date).Days.ToString();
        }

        private void DP2_DateSelected(object sender, DateChangedEventArgs e)
        {
            TermsOfLoanEntry.Text = (DP2.Date - DP1.Date).Days.ToString();
        }


    }
}
