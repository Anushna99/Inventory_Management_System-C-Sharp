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
    /// Interaction logic for Themes.xaml
    /// </summary>
    public partial class Themes : Window
    {
        public Themes()
        {
            InitializeComponent();
            string theme = obj.readData("select * from theme", "theme");
            if(theme=="A")
            {
                rb1.IsChecked = true;
            }
            else if(theme=="B")
            {
                rb2.IsChecked = true;
            }
            else if(theme=="C")
            {
                rb3.IsChecked = true;
            }
            else if(theme=="D")
            {
                rb4.IsChecked = true;
            }
            else if(theme=="E")
            {
                rb5.IsChecked = true;
            }
            else if (theme == "F")
            {
                rb6.IsChecked = true;
            }
            else if (theme == "G")
            {
                rb7.IsChecked = true;
            }
        }
        DB_Connection obj = new DB_Connection();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(rb1.IsChecked==true)
            {
                obj.save_update_delete("update theme set theme='" + "A" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(rb2.IsChecked==true)
            {
                obj.save_update_delete("update theme set theme='" + "B" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(rb3.IsChecked==true)
            {
                obj.save_update_delete("update theme set theme='" + "C" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(rb4.IsChecked==true)
            {
                obj.save_update_delete("update theme set theme='" + "D" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(rb5.IsChecked==true)
            {
                obj.save_update_delete("update theme set theme='" + "E" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (rb6.IsChecked == true)
            {
                obj.save_update_delete("update theme set theme='" + "F" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (rb7.IsChecked == true)
            {
                obj.save_update_delete("update theme set theme='" + "G" + "' where id=1");
                MessageBox.Show("Theme Apllied,Application will restart..", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //this.Close();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
