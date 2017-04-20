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
        {
            try
            {
                // CultureInfo ci = new CultureInfo("en-US");
                double sumI = 0;
                double sumP = 0;
                bool Toggle1 = true;
                double amount = Convert.ToDouble(App.LoanAmountAD);
                double balance = Convert.ToDouble(App.LoanAmountAD);


                double LoanAmount = Convert.ToDouble(App.LoanAmountAD);
                int Term = Convert.ToInt32(App.TermAD);
                DateTime StartDate = App.StartDateAD;
                double AnnualRate = Convert.ToDouble(App.AnnualRateAD);
                double DailyRate = Convert.ToDouble(App.DailyRateAD);
                string InterestOnly = App.InterestOnlyAD;
                double Payment = Convert.ToDouble(App.PaymentAD);
                double PMT = Convert.ToDouble(App.PmtAD);
                double dailyInterest = Convert.ToDouble(DailyRate) / 100;
                int term = Term - 1;
      
                int interestonly;
                if (String.IsNullOrEmpty(InterestOnly))
                {
                    interestonly = 0;
                }
                else interestonly = Convert.ToInt32(InterestOnly);

                for (int i = 0; i < Term; i++)
                {
                    if (Toggle1 == true)
                    {
                        if (PMT < Payment)
                        {
                            do
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
                                    {
                                        i++;
                                        DateTime dateTime10 = StartDate.AddDays(i);
                                        double interest10 = amount * dailyInterest;
                                        double principal10 = 0.00;
                                        balance = LoanAmount;
                                        //Items.Add(new GridItem()
                                        //{
                                        //    PaymentNumber = i.ToString(),
                                        //    Date = dateTime10.Date.ToString("dd/MM/yyyy"),
                                        //    Payment = Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    Principal = Math.Rou  nd(principal10, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    Interest = Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                        //})
                                        //;
                                        gridItem(i, dateTime10.Date.ToString("dd/MM/yyyy"),
                                            Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Math.Round(principal10, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest10, 2, MidpointRounding.AwayFromZero).ToString(), 
                                            Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                        amount = LoanAmount;
                                        sumI += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                        sumP += Math.Round(interest10, 2, MidpointRounding.AwayFromZero);
                                    }
                                }
                                DateTime dateTime = StartDate.AddDays(i + 1);
                                double interest = amount * dailyInterest;
                                double principal = Payment - Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                balance -= principal;
                                //Items.Add(new GridItem()
                                //{
                                //    PaymentNumber = (i + 1).ToString(),
                                //    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                //    Payment = Math.Round(Payment, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                //});
                                gridItem(i+1, dateTime.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(Payment, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                amount -= principal;
                                i++;
                                sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                sumP += Payment;
                            }
                            while ((balance - Payment) > 0);
                            DateTime dateTime1 = StartDate.AddDays(i + 1);
                            double interest1 = amount * dailyInterest;
                            double principal1 = balance;
                            balance -= principal1;
                            //Items.Add(new GridItem()
                            //{
                            //    PaymentNumber = (i + 1).ToString(),
                            //    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                            //    Payment = Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero).ToString(),
                            //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                            //    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                            //    Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                            //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                            //});
                            gridItem(i+1, dateTime1.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                               Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                               Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                            amount -= principal1;
                            sumP += Math.Round((interest1 + amount), 2, MidpointRounding.AwayFromZero);
                            sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            i = Term;
                        }
                        else
                        {
                            if (PMT > Payment)
                            {
                                while (i < term)
                                {
                                    if (Convert.ToDouble(interestonly) > 0)
                                    {
                                        while (i < Convert.ToDouble(interestonly))
                                        {
                                            i++;
                                            DateTime dateTime12 = StartDate.AddDays(i);
                                            double interest12 = amount * dailyInterest;
                                            double principal12 = 0.00;
                                            balance = LoanAmount;
                                            //Items.Add(new GridItem()
                                            //{
                                            //    PaymentNumber = i.ToString(),
                                            //    Date = dateTime12.Date.ToString("dd/MM/yyyy"),
                                            //    Payment = Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                            //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                            //    Principal = Math.Round(principal12, 2, MidpointRounding.AwayFromZero).ToString(),
                                            //    Interest = Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(),
                                            //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                            //});
                                            gridItem(i, dateTime12.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(principal12, 2, MidpointRounding.AwayFromZero).ToString(),
                                                Math.Round(interest12, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString()
                                                );
                                            amount = LoanAmount;
                                            sumI += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);
                                            sumP += Math.Round(interest12, 2, MidpointRounding.AwayFromZero);

                                        }
                                    }
                                    DateTime dateTime = StartDate.AddDays(i + 1);
                                    double interest = amount * dailyInterest;
                                    double principal = Payment - Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                    balance -= principal;
                                    //Items.Add(new GridItem()
                                    //{
                                    //    PaymentNumber = (i + 1).ToString(),
                                    //    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                    //    Payment = Math.Round(Payment, 2, MidpointRounding.AwayFromZero).ToString(),
                                    //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                    //    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                    //    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                    //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                    //});
                                    gridItem(i+1, dateTime.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Math.Round(Payment, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                        Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                    amount -= principal;
                                    i++;
                                    sumP += Math.Round(Payment, 2, MidpointRounding.AwayFromZero);
                                    sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                }
                                DateTime dateTime1 = StartDate.AddDays(i + 1);
                                double interest1 = amount * dailyInterest;
                                double principal1 = amount;
                                balance -= principal1;
                                //Items.Add(new GridItem()
                                //{
                                //    PaymentNumber = (i + 1).ToString(),
                                //    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                //    Payment = Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                //});
                                gridItem(i+1, dateTime1.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                     Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                amount -= principal1;
                                sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                sumP += Math.Round(interest1 + amount, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                if (Convert.ToDouble(interestonly) > 0)
                                {
                                    while (i < Convert.ToDouble(interestonly))
                                    {
                                        i++;
                                        DateTime dateTime1 = StartDate.AddDays(i);
                                        double interest1 = amount * dailyInterest;
                                        double principal1 = 0.00;
                                        balance = LoanAmount;
                                        //Items.Add(new GridItem()
                                        //{
                                        //    PaymentNumber = i.ToString(),
                                        //    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                        //    Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                        //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                        //});
                                        gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                            Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                        amount = LoanAmount;
                                        sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                        sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                    }
                                }

                                DateTime dateTime = StartDate.AddDays(i + 1);
                                double interest = amount * dailyInterest;
                                double principal = PMT - interest;
                                balance -= principal;
                                //Items.Add(new GridItem()
                                //{
                                //    PaymentNumber = (i + 1).ToString(),
                                //    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                                //    Payment = Math.Round(PMT, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                //});
                                gridItem(i + 1, dateTime.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(PMT, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                amount -= principal;
                                sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                                sumP += Math.Round(PMT, 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(interestonly) > 0)
                        {
                            while (i < Convert.ToDouble(interestonly))
                            {
                                i++;
                                DateTime dateTime1 = StartDate.AddDays(i);
                                double interest1 = amount * dailyInterest;
                                double principal1 = 0.00;
                                balance = LoanAmount;
                                //Items.Add(new GridItem()
                                //{
                                //    PaymentNumber = i.ToString(),
                                //    Date = dateTime1.Date.ToString("dd/MM/yyyy"),
                                //    Payment = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Principal = Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    Interest = Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                                //});
                                gridItem(i, dateTime1.Date.ToString("dd/MM/yyyy"), Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(principal1, 2, MidpointRounding.AwayFromZero).ToString(), Math.Round(interest1, 2, MidpointRounding.AwayFromZero).ToString(),
                                    Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString());
                                amount = LoanAmount;
                                sumP += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                                sumI += Math.Round(interest1, 2, MidpointRounding.AwayFromZero);
                            }
                        }

                        DateTime dateTime = StartDate.AddDays(i + 1);
                        double interest = amount * dailyInterest;
                        double principal = PMT - interest;
                        balance -= principal;
                        //Items.Add(new GridItem()
                        //{
                        //    PaymentNumber = (i + 1).ToString(),
                        //    Date = dateTime.Date.ToString("dd/MM/yyyy"),
                        //    Payment = Math.Round(PMT, 2, MidpointRounding.AwayFromZero).ToString(),
                        //    EndingBalance = Math.Round(balance, 2, MidpointRounding.AwayFromZero).ToString(),
                        //    Principal = Math.Round(principal, 2, MidpointRounding.AwayFromZero).ToString(),
                        //    Interest = Math.Round(interest, 2, MidpointRounding.AwayFromZero).ToString(),
                        //    StartingBalance = Math.Round(amount, 2, MidpointRounding.AwayFromZero).ToString()
                        //});
                        amount -= principal;
                        sumI += Math.Round(interest, 2, MidpointRounding.AwayFromZero);
                        sumP += Math.Round(PMT, 2, MidpointRounding.AwayFromZero);
                    }
                }
                //ItemsSum.Add(new GridItem()
                //{
                //    InterestSum = Math.Round(sumI, 2, MidpointRounding.AwayFromZero).ToString(),
                //    PeymentSum = Math.Round(sumP, 2, MidpointRounding.AwayFromZero).ToString(),
                //    sumSum = Math.Round(sumP / sumI, 2, MidpointRounding.AwayFromZero).ToString()
                //});
            }
            catch (Exception)
            {
            }
        }

    }
}
