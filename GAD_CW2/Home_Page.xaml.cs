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
    /// Interaction logic for Home_Page.xaml
    /// </summary>
    public partial class Home_Page : Page
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void tile_users_Click(object sender, RoutedEventArgs e)
        {
            if (DB_Connection.admin == true)
            {
                ManageUsers obj = new ManageUsers();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("SORRY YOU DO NOT HAVE THE PERMISSION TO MANAGE USERS.PLEASE CONTACT A SYSTEM ADMIN", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void theme_Click(object sender, RoutedEventArgs e)
        {
            Themes obj = new Themes();
            obj.ShowDialog();
        }

      
    }
}
