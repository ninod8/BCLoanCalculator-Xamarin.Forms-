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
            App.ButtonFontFamily(ELMonthlyButton);
            App.ButtonFontFamily(ELDailyButton);
            App.ButtonFontFamily(FDailyButton);
            App.ButtonFontFamily(FMonthlyButton);
            App.ButtonFontFamily(ScenarioButton);
            ScenarioButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Scenario());
            };
            ELDailyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new AnnuityDaily());
            };
            FDailyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new FlatDaily());
            };
            ELMonthlyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new AnnuityMonthly());
            };
            FMonthlyButton.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new FlatMonthly());
            };
        }
    }
}