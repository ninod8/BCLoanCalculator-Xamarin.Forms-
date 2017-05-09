using BCLoanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BCLoanCalculator
{
    public partial class GridViewScenario : ContentPage
    {
        public ScenarioModel ld { get; set; }
        public GridViewScenario(List<GraphViewModel> model)
        {
            InitializeComponent();
            gridData.ItemsSource = model;
            gridData.WidthRequest = 740;
            scrollView.Orientation = ScrollOrientation.Both;
        }
    }
}
