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
using MahApps.Metro.Controls;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for Employees_Page.xaml
    /// </summary>
    public partial class Employees_Page : Page
    {
        public Employees_Page()
        {
            InitializeComponent();
        }

        private void tile_add_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Add_Employee();
        }

        private void tile_view_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new View_Employee();
        }

        private void tile_delete_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Delete_Employee();
        }

        private void tile_update_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new Update_Employee();
        }
    }
}
