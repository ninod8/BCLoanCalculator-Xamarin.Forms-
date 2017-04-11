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
            LabelFontFamily(ELMonthlyButton);
            LabelFontFamily(ELDailyButton);
            LabelFontFamily(FDailyButton);
            LabelFontFamily(FMonthlyButton);
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
        public void LabelFontFamily(Button label)
        {
            label.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
        }
    }
}
