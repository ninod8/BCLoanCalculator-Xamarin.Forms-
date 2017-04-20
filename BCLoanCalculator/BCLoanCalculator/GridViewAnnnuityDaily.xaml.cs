using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class GridViewAnnnuityDaily : ContentPage
    {
        public AnnuityDailyCalc ld { get; set; }
        public GridViewAnnnuityDaily()
        {
            // BindingContext = new AnnuityDailyCalc();


            InitializeComponent();

       
             GraphDaily();
            PmtNumberLabel.Text = "№";
             DateLabel.Text = "თარიღი";
            //DateLabel.Text = ld.LoanAmount;
            StartingBalanceLabel.Text = "საწყისი ბალანსი";
            EndingBalanceLabel.Text = "საბოლოო ბალანსი";
            PaymentLabel.Text = "გადასახადი";
            PrincipalLabel.Text = "ძირი";
            RateLabel.Text = "პროცენტი";

            //int x = 1;
            //gridItem(x, "27/02/1997", "1000", "36", "35", "1", "963");
            //x++;

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
            var ld = this.BindingContext as AnnuityDailyCalc;
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
        public void GraphDaily()
        {            this.BindingContext = ld;
            BindingContext = new AnnuityDailyCalc();
            ld = BindingContext as AnnuityDailyCalc;
            try
            {
                     double dailyInterest = Convert.ToDouble(ld.DailyRate) / 100;


                double amount = Convert.ToDouble(ld.LoanAmount);
                double balance = Convert.ToDouble(ld.LoanAmount);

                int term = Convert.ToInt32(ld.TermsOfLoan) - 1;
                int j = 1;
                gridItem(j, "27/02/1997", "1000", "36", "35", "1", "963");
                j++;
                int interestonly;
                if (String.IsNullOrEmpty(ld.InterestOnly))
                {
                    interestonly = 0;
                }

                else interestonly = Convert.ToInt32(ld.InterestOnly);

                for (int i = 0; 
                    i < Convert.ToInt32(ld.TermsOfLoan); i++)
                {
                    ////////////// if ( == true)//////////////////////////////////////<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    ////  {
                    if (Convert.ToDouble(ld.PMT()) < 0)
                    {
                        do
                        {
                            if (Convert.ToDouble(interestonly) > 0)
                            {
                                while (i < Convert.ToDouble(interestonly))
                                {
                                    i++;
                                    DateTime dateTime10 = ld.StartDate.AddDays(i);
                                    double interest10 = amount * dailyInterest;
                                    double principal10 = 0.00;
                                    balance = Convert.ToDouble(ld.LoanAmount);
                                    int x = 1;
                                    gridItem(x, dateTime10.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT(), interest10.ToString(), principal10.ToString(), balance.ToString());
                                    x++;
                                    amount = Convert.ToDouble(ld.LoanAmount);
                                }
                            }
                            DateTime dateTime3 = ld.StartDate.AddDays(i + 1);
                            double interest3 = amount * dailyInterest;
                            double principal3 = Convert.ToDouble(ld.Payment) - Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                            balance -= principal3;
                            gridItem(i, dateTime3.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest3.ToString(), principal3.ToString(), balance.ToString());
                            amount -= principal3;
                            i++;
                            //sumI += Math.Round(interest3, 2, MidpointRounding.AwayFromZero);
                            //sumP += Convert.ToDouble(ld.Payment);
                        }
                        while ((balance - Convert.ToDouble(ld.Payment)) > 0);
                        DateTime dateTime1 = ld.StartDate.AddDays(i + 1);
                        double interest1 = amount * dailyInterest;
                        double principal1 = balance;
                        balance -= principal1;
                        gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest1.ToString(), principal1.ToString(), balance.ToString());
                        amount -= principal1;
                        i = Convert.ToInt32(ld.TermsOfLoan);

                    }
                    else
                    {
                        if (Convert.ToDouble(ld.PMT()) > 0)
                        {
                            while (i < term)
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
                                    {
                                        i++;
                                        DateTime dateTime12 = ld.StartDate.AddDays(i);
                                        double interest12 = amount * dailyInterest;
                                        double principal12 = 0.00;
                                        balance = Convert.ToDouble(ld.LoanAmount);
                                        gridItem(i, dateTime12.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest12.ToString(), principal12.ToString(), balance.ToString());
                                        amount = Convert.ToDouble(ld.LoanAmount);
                                    }
                                }
                                DateTime dateTime4 = ld.StartDate.AddDays(i + 1);
                                double interest4 = amount * dailyInterest;
                                double principal4 = Convert.ToDouble(ld.Payment) - Math.Round(interest4, 2, MidpointRounding.AwayFromZero);
                                balance -= principal4;
                                gridItem(i, dateTime4.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest4.ToString(), principal4.ToString(), balance.ToString());
                                amount -= principal4;
                                i++;
                                //sumP += Math.Round(Convert.ToDouble(ld.Payment), 2, MidpointRounding.AwayFromZero);
                                //sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                            }
                            DateTime dateTime1 = ld.StartDate.AddDays(i + 1);
                            double interest1 = amount * dailyInterest;
                            double principal1 = amount;
                            balance -= principal1;
                            gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest1.ToString(), principal1.ToString(), balance.ToString());
                            amount -= principal1;
                        }
                        else
                        {
                            if (Convert.ToDouble(interestonly) > 0)
                            {
                                while (i < Convert.ToDouble(interestonly))
                                {
                                    i++;
                                    DateTime dateTime1 = ld.StartDate.AddDays(i);
                                    double interest1 = amount * dailyInterest;
                                    double principal1 = 0.00;
                                    balance = Convert.ToDouble(ld.LoanAmount);
                                    gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest1.ToString(), principal1.ToString(), balance.ToString());
                                    amount = Convert.ToDouble(ld.LoanAmount);
                                }
                            }

                            DateTime dateTime6 = ld.StartDate.AddDays(i + 1);
                            double interest6 = amount * dailyInterest;
                            double principal6 = Convert.ToDouble(ld.PMT()) - interest6;
                            balance -= principal6;
                            gridItem(i, dateTime6.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest6.ToString(), principal6.ToString(), balance.ToString());
                            amount -= principal6;
                        }
                    }
                    //////////////////////////////////////////   }<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //else,<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //{.,,,,,,,,,,,,,,,,,,<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    if (Convert.ToDouble(interestonly) > 0)
                    {
                        while (i < Convert.ToDouble(interestonly))
                        {
                            i++;
                            DateTime dateTime1 = ld.StartDate.AddDays(i);
                            double interest1 = amount * dailyInterest;
                            double principal1 = 0.00;
                            balance = Convert.ToDouble(ld.LoanAmount);
                            gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest1.ToString(), principal1.ToString(), balance.ToString());
                            amount = Convert.ToDouble(ld.LoanAmount);
                        }
                    }

                    DateTime dateTime = ld.StartDate.AddDays(i + 1);
                    double interest = amount * dailyInterest;
                    double principal = Convert.ToDouble(ld.PMT()) - interest;
                    balance -= principal;
                    gridItem(i, dateTime.Date.ToString("dd/MM/yyyy"), amount.ToString(), ld.PMT().ToString(), interest.ToString(), principal.ToString(), balance.ToString());
                    amount -= principal;
                    //////////////////  }<<<<<<<<<<<<<<<
                }
            }
            catch (Exception)
            {
                gridItem(1, "", "", "", "rr", "rr", "rrr");
            
            }

        }
    }
}
