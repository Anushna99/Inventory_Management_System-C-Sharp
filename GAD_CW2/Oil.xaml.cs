using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Oil.xaml
    /// </summary>
    public partial class Oil : Page
    {
        public Oil()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = obj.getData("select ProdId,Prod_description,Price,Brand,QtyInHand from Product where ProdId like '" + "O" + "%'").AsDataView();

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            dg.ItemsSource = obj.getData("select * from Product where QtyInHand>0 and prefix='" + "O" + "' and Prod_description like'%" + txt_search.Text + "%'").AsDataView();
            int ct = Convert.ToInt32(obj.readData("select count(*) as count from Product where QtyInHand>0 and prefix='" + "T" + "' and Prod_description like '%" + txt_search.Text + "%'", "count"));
            if (ct == 0) { lbl_sh.Content = "No Items Match"; }
            else { lbl_sh.Content = ""; }
        }

        private void txt_search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_search.Text.Length == 0)
            {
                dg.ItemsSource = obj.getData("select * from Product where QtyInHand>0 and prefix='" + "O" + "'").AsDataView();
                lbl_sh.Content = "";
            }
        }
    }
}
