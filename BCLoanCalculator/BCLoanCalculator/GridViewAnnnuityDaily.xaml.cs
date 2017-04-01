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
        public GridViewAnnnuityDaily()
        {
            BindingContext = new AnnuityDailyCalc();

            InitializeComponent();

            //grid.BindingContext=Items;
            var ld = this.BindingContext as AnnuityDailyCalc;
            //grid = new Grid();
            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //var topLeft = new Label { Text = "Top Left" };
            //var topRight = new Label { Text = "Top Right" };
            //var bottomLeft = new Label { Text = "Bottom Left" };
            //var bottomRight = new Label { Text = "Bottom Right" };
            //var bottomLefti = new Label { Text = "Bottom Left" };
            //var bottomRighti = new Label { Text = "Bottom Right" };
            //grid.Children.Add(topLeft, 0, 0);
            //grid.Children.Add(topRight, 1, 0);
            //grid.Children.Add(bottomLeft, 0, 1);
            //grid.Children.Add(bottomRight, 1, 1);
            //grid.Children.Add(bottomLefti, 0, 2);
            //grid.Children.Add(bottomRighti, 1, 2);
        //    var listView = new ListView();
//         //   ddd.ItemsSource = new string[]{
//  "mono",
//  "monodroid",
//  "monotouch",
//  "monorail",
//  "monodevelop",
//  "monotone",
//  "monopoly",
//  "monomodal",
//  "mononucleosis"
//};

            Items = new ObservableCollection<GridItem>();
            Items.Add(new GridItem()
            {
                Date = "თარიღი",
                EndingBalance = "საბოლოო ბალანსი",
                Interest = "პროცენტი",
                Payment = "გადასახადი",
                PaymentNumber = "#",
                Principal = "ძირი",
                StartingBalance = "საწყისი ბალანსი"
            });
        
        }
                  
public ObservableCollection<GridItem> Items { get; set; }
      //  public ObservableCollection<GridItem> FlatDailyItems { get; set; }
        //public void addItem(string n)
        //{
        //    var name = new Label { Text = n };
        //    grid.Children.Add(name);
        //}
    }
}
