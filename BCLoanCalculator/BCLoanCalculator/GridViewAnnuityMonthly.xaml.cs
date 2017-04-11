using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class GridViewAnnuityMonthly : ContentPage
    {
        public GridViewAnnuityMonthly()
        {
            InitializeComponent();
            PmtNumberLabel.Text = "№";
            DateLabel.Text = "თარიღი";
            StartingBalanceLabel.Text = "საწყისი ბალანსი";
            EndingBalanceLabel.Text = "საბოლოო ბალანსი";
            PaymentLabel.Text = "გადასახადი";
            PrincipalLabel.Text = "ძირი";
            RateLabel.Text = "პროცენტი";


            int x = 1;
            gridItem(x, "27/02/1997", "1000", "36", "35", "1", "963");
            x++;

            LabelFontFamily(PaymentLabel);
            LabelFontFamily(DateLabel);
            LabelFontFamily(StartingBalanceLabel);
            LabelFontFamily(EndingBalanceLabel);
            LabelFontFamily(PaymentLabel);
            LabelFontFamily(PrincipalLabel);
            LabelFontFamily(RateLabel);
        }

        public void gridItem(int n, string date, string startingBalance, string payment, string principal, string rate, string endingBalance)
        {

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            var paymentNLabel = new Label { Text = n.ToString() };
            var dateLabel = new Label { Text = date };
            var startingBalanceLabel = new Label { Text = startingBalance };
            var paymentLabel = new Label { Text = payment };
            var principalLabel = new Label { Text = principal };
            var rateLabel = new Label { Text = rate };
            var endingBalanceLabel = new Label { Text = endingBalance };
            grid.Children.Add(paymentNLabel, 0, n);
            grid.Children.Add(dateLabel, 1, n);
            grid.Children.Add(startingBalanceLabel, 2, n);
            grid.Children.Add(paymentLabel, 3, n);
            grid.Children.Add(principalLabel, 4, n);
            grid.Children.Add(rateLabel, 5, n);
            grid.Children.Add(endingBalanceLabel, 6, n);


        }
        public void LabelFontFamily(Label label)
        {
            label.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
        }
    }
}
