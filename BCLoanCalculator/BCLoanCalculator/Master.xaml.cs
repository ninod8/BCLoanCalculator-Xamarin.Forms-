using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            ELDailyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new AnnuityDaily() { Title = "  სესხის კალკულატორი" });

            };
            FDailyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new GridViewAnnnuityDaily() { Title = "  სესხის კალკულატორი" });
            };
            ELMonthlyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new AnnuityMonthly() { Title = "  სესხის კალკულატორი" });
            };
            FMonthlyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new FlatMonthly() { Title = "  სესხის კალკულატორი" });
            };
        }
    }
}
