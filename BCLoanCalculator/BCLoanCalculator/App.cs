using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task NavigateMasterDetail(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }
        internal static string PmtAD;
        internal static string LoanAmountAD;
        internal static string LoanAmountAM;
        internal static string LoanAmountFM;
        internal static string LoanAmountFD;

        internal static string DailyRateAD;
        internal static string DailyRateFD;
        internal static string MonthlyRateFM;
        internal static string MonthlyRateAM;

        internal static string InterestOnlyAD;
        internal static string InterestOnlyAM;

        internal static string AnnualRateAD;
        internal static string AnnualRateAM;
        internal static string AnnualRateFM;
        internal static string AnnualRateFD;

        internal static string TermAD;
        internal static string TermAM;
        internal static string TermFM;
        internal static string TermFD;

        internal static string PaymentAD;
        internal static string PaymentAM;
        internal static string PaymentFM;
        internal static string PaymentFD;

        internal static DateTime StartDateAD = DateTime.Today.Date.AddMonths(1);
        internal static DateTime StartDateAM= DateTime.Today.Date;
        internal static DateTime StartDateFM= DateTime.Today.Date;
        internal static DateTime StartDateFD= DateTime.Today.Date.AddMonths(1);

        internal static DateTime EndDateAD  = DateTime.Today.Date;
        internal static DateTime EndDateAM = DateTime.Today.Date.AddMonths(1);
        internal static DateTime EndDateFM  = DateTime.Today.Date.AddMonths(1);
        internal static DateTime EndDateFD = DateTime.Today.Date;

        internal static DateTime ReleaseDateAM = DateTime.Today.Date;
        internal static DateTime ReleaseDateFM = DateTime.Today.Date;
        public App()
        {
            // The root page of your application            
            MainPage = new MainPage();
            //
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
