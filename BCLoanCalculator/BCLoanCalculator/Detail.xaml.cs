using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Label.Text = "ბიზნეს კრედიტი";
            Label2.Text = "___ფული, რომელიც გეხმარება___";
            Label.FontSize = 25;
            Label2.FontSize = 16;
            Label.VerticalTextAlignment = TextAlignment.Center;
            Label2.VerticalTextAlignment = TextAlignment.Center;
            Label.HorizontalTextAlignment = TextAlignment.Center;
            Label2.HorizontalTextAlignment = TextAlignment.Center;
            Label.TextColor = Color.FromRgb(237, 139, 28);
            Label2.TextColor = Color.FromRgb(237, 139, 28);

         

        } 
    }
}
