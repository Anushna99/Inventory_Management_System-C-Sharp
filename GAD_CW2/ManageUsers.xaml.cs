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
using System.Windows.Shapes;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new AddUser();
            img_user.Visibility = Visibility.Collapsed;
            lbl_user.Visibility = Visibility.Collapsed;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new ViewUsers();
            img_user.Visibility = Visibility.Collapsed;
            lbl_user.Visibility = Visibility.Collapsed;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = new UpdateUser();
            img_user.Visibility = Visibility.Collapsed;
            lbl_user.Visibility = Visibility.Collapsed;
        }
    }
}
