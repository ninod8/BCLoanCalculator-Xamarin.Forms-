using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
namespace BCLoanCalculator
{
    public partial class AnnuityDaily : ContentPage
    {
        public AnnuityDaily()
        {
            InitializeComponent();
            BindingContext = new AnnuityDailyCalc();
            #region Interface
            DP1.Date = DateTime.Today.Date;
            DP2.Date = DateTime.Today.Date;
            MainLabel.TextColor = Color.FromRgb(2, 117, 157);
            MainLabel.FontSize = 17;
            MainLabel.HorizontalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyAnnualRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyAnnualRateLabel.FontSize = 14;
            LoanAmountLabel.VerticalTextAlignment = TextAlignment.Center;
            LoanAmountLabel.TextColor = Color.FromRgb(2, 117, 157);
            LoanAmountLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyDailyRateLabel.FontSize = 14;
            AnnuityDailyDailyRateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyEndDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyEndDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyEndDateLabel.FontSize = 14;
            AnnuityDailyInterestOnlyLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyInterestOnlyLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyInterestOnlyLabel.FontSize = 14;
            AnnuityDailyPaymentLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyPaymentLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyPaymentLabel.FontSize = 14;
            AnnuityDailyStartDateLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyStartDateLabel.TextColor = Color.FromRgb(2, 117, 157);
            AnnuityDailyStartDateLabel.FontSize = 14;
            AnnuityDailyTermLabel.VerticalTextAlignment = TextAlignment.Center;
            AnnuityDailyTermLabel.TextColor = Color.FromRgb(2,117,157);
            AnnuityDailyTermLabel.FontSize = 14;
            #endregion
        }

    }
    public class AnnuityDailyCalc
    {
        #region privateVariables
        private string loanAmount;
        private string termsOfLoan;
        private string dailyRate;
        private string annualRate;
        private string payment;
        private DateTime startDate;
        private DateTime endDate;
        private string interestOnly;

        #endregion

        public string LoanAmount
        {
            get { return loanAmount; }
            set
            {
                loanAmount = value;
            }
        }

        public string TermsOfLoan
        {
            get { return termsOfLoan; }
            set
            {
                termsOfLoan = value;
            }
        }

        public string DailyRate
        {
            get { return dailyRate; }
            set
            {
                dailyRate = value;
            }
        }

        public string AnnualRate
        {
            get { return annualRate; }
            set
            {
                annualRate = value;
            }
        }

        public string Payment
        {
            get { return payment; }
            set
            {
                payment = value;
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
            }
        }

        public string InterestOnly
        {
            get { return interestOnly; }
            set
            {
                interestOnly = value;
            }
        }


    }
}
