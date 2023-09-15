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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DB_Connection obj = new DB_Connection();
        public MainWindow()
        {
            InitializeComponent();
            string theme=obj.readData("select * from theme", "theme");
            if (theme == "A")
            {
                main.Background = Brushes.LightCyan;
                nav_pnl.Background = Brushes.LightBlue;
            }
            else if(theme=="B")
            {
                main.Background = Brushes.WhiteSmoke;
                nav_pnl.Background = Brushes.Silver;
            }
            else if(theme=="C")
            {
                main.Background = Brushes.PapayaWhip;
                nav_pnl.Background = Brushes.PeachPuff;
            }
            else if(theme=="D")
            {
                main.Background = Brushes.Azure;
                nav_pnl.Background = Brushes.Aquamarine;
            }
            else if(theme=="E")
            {
                main.Background = Brushes.Aqua;
                nav_pnl.Background = Brushes.LightSeaGreen;
            }
            else if (theme == "F")
            {
                main.Background = Brushes.GreenYellow;
                nav_pnl.Background = Brushes.Gray;
            }
            else if (theme == "G")
            {
                main.Background = Brushes.Silver;
                nav_pnl.Background = Brushes.DodgerBlue;
            }
        }
       
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_dashboard.Visibility = Visibility.Collapsed;
                tt_products.Visibility = Visibility.Collapsed;
                tt_orders.Visibility = Visibility.Collapsed;
                tt_employee.Visibility = Visibility.Collapsed;
                tt_suppliers.Visibility = Visibility.Collapsed;

            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_dashboard.Visibility = Visibility.Visible;
                tt_products.Visibility = Visibility.Visible;
                tt_orders.Visibility = Visibility.Visible;
                tt_employee.Visibility = Visibility.Visible;
                tt_suppliers.Visibility = Visibility.Visible;

            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pages.Content = new Home_Page();
        }

        private void StackPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (DB_Connection.admin)
            {
                pages.Content = new Dash_Page();
            }
            else
            {
                MessageBox.Show("SORRY YOU DO NOT HAVE THE PERMISSION TO VIEW DASHBOARD.PLEASE CONTACT A SYSTEM ADMIN", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StackPanel_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            pages.Content = new Products_Page();
            
        }

        private void StackPanel_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            pages.Content = new Suppliers_Page();
        }

        private void StackPanel_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            pages.Content = new Orders_Page();
        }

        private void StackPanel_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            pages.Content = new Employees_Page();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pages.Content = new Home_Page();
        }
    }
}
