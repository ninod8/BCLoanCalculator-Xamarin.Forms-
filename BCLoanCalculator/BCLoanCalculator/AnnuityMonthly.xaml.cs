using System;
using System.Collections.Generic;
using System.Linq;
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
            #region Interface
            DP0.Date = DateTime.Today.Date;
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            MainLabel.VerticalTextAlignment = TextAlignment.Center;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            AnnuityMonthlyFirstPaymentDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyFirstPaymentDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyFirstPaymentDateLabel.FontSize = 14;
            AnnuityMonthlyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            LoanAmountLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyMonthlyRateLabel.FontSize = 14;
            AnnuityMonthlyMonthlyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyEndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyEndDateLabel.FontSize = 14;
            AnnuityMonthlyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyInterestOnlyLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyInterestOnlyLabel.FontSize = 14;
            AnnuityMonthlyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyPaymentLabel.FontSize = 14;
            AnnuityMonthlyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyStartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyStartDateLabel.FontSize = 14;
            AnnuityMonthlyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityMonthlyTermLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityMonthlyTermLabel.FontSize = 14;
            #endregion
        }
        public class AnnuityMonthlyCalc
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
            private string interestOnly;
            #endregion

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
                set { monthlyRate = value; }
            }

            public string AnnualRate
            {
                get { return annualRate; }
                set { annualRate = value; }
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

            public string InterestOnly
            {
                get { return interestOnly; }
                set { interestOnly = value; }
            }

        }
    }
}
