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
           ////////////////////////////////////////////////////////<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<gasuptaveba
            Label.Text = "ბიზნეს კრედიტი";
            Label2.Text = "___ფული, რომელიც გეხმარება___";
            LabelFontFamily(Label);
            LabelFontFamily(Label2);
        Label.FontSize = 25;
            Label2.FontSize = 16;
            Label.VerticalTextAlignment = TextAlignment.Center;
                Label.HorizontalTextAlignment = TextAlignment.Center;
            Label2.HorizontalTextAlignment = TextAlignment.Center;
            Label.TextColor = Color.FromRgb(2,117,157);
            Label2.TextColor = Color.FromRgb(210,87,39);

         

        }          public void LabelFontFamily(Label label)
        {
            label.FontFamily = Device.OnPlatform(
                                                null,
                                                 "bpg_nino_mtavruli_bold.ttf#bpg_nino_mtavruli_bold", // Android
                                                  null
                                                );
        //    label.FontAttributes = FontAttributes.Bold;

        }
        
    }
}
