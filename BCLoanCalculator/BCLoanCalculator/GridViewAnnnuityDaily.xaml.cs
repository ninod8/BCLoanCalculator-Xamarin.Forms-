using BCLoanCalculator.Models;
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
           public AnnuityDailyModel ld { get; set; }

        
        
        public GridViewAnnnuityDaily(List<GraphViewModel> model)
        {
            InitializeComponent();
            gridData.ItemsSource = model;
            gridData.WidthRequest = 660;
            scroll.Orientation = ScrollOrientation.Both;
        }     
    }
}
