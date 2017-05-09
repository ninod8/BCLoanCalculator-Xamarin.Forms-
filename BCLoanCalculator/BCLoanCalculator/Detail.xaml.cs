using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Windows.UI.Xaml.Documents;
using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
            bc.WidthRequest = 150;
            bc.HeightRequest = 150;
            Label1.Text = "ბიზნეს კრედიტი";
            Label2.Text = "___ფული, რომელიც გეხმარება___";
            App.LabelFontFamily(Label1);
            App.LabelFontFamily(Label2);
            Label1.FontSize = 25;
            Label2.FontSize = 16;
            Label1.VerticalTextAlignment = TextAlignment.Center;
            Label1.HorizontalTextAlignment = TextAlignment.Center;
            Label2.HorizontalTextAlignment = TextAlignment.Center;
            Label1.TextColor = Color.FromRgb(2, 117, 157);
            Label2.TextColor = Color.FromRgb(210, 87, 39);
        }  
    }
}
