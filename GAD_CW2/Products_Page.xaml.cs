using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for Products_Page.xaml
    /// </summary>
    public partial class Products_Page : Page
    {
        public Products_Page()
        {
            InitializeComponent();


        }

        private void tile_tyre_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Tyres();
        }

        private void tile_alloy_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Alloy();
        }

        private void tile_lights_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Lights();
        }

        private void tile_oil_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Oil();
        }

        private void tile_add_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Add_Product();
        }

        private void tile_update_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Update_Products();
        }

        private void tile_add_supplies_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Add_Supplies();
        }

        private void tile_supply_product_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new SuppliedProducts();
        }
    }
}
