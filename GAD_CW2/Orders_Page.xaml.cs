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
    /// Interaction logic for Orders_Page.xaml
    /// </summary>
    public partial class Orders_Page : Page
    {
        public Orders_Page()
        {
            InitializeComponent();
        }

        private void tile_place_order_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Place_Order1();
        }

        private void tile_view_orders_Click(object sender, RoutedEventArgs e)
        {
            if (DB_Connection.admin)
            {
                pages.Content = new View_Orders();
            }
            else
            {
                MessageBox.Show("SORRY YOU DO NOT HAVE THE PERMISSION TO VIEW ORDERS.PLEASE CONTACT A SYSTEM ADMIN", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
