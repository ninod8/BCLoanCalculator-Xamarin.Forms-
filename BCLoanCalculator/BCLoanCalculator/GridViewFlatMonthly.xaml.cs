using BCLoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class GridViewFlatMonthly : ContentPage
    {
        public FlatRateMonthlyModel ld { get; set; }
        public GridViewFlatMonthly(List<GraphViewModel> model)
        {
            {
                InitializeComponent();
                gridData.ItemsSource = model;
                gridData.WidthRequest = 660;
                scroll.Orientation = ScrollOrientation.Both;
            }
        }
    }
}
