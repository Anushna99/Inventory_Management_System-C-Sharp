using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Add_Supplies.xaml
    /// </summary>
    public partial class Add_Supplies : Page
    {
        public Add_Supplies()
        {
            InitializeComponent();
        }
        bool validate = false;
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select * from Product order by QtyInHand").AsDataView();
        }

       

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text.Length == 0)
            {
                MessageBox.Show("Please select the product you wish to add", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (validate == false)
            {
                MessageBox.Show("Please fill correctly", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                obj.save_update_delete("update Product set QtyInHand+='" + txt_qty.Text + "' where ProdId='" + txt_id.Text + "'");
                MessageBox.Show("Supplies added successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                datagrid.ItemsSource = obj.getData("select * from Product order by QtyInHand").AsDataView();
                txt_description.Clear();
                txt_id.Clear();
                txt_qty.Clear();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_id.Text = row_selected["ProdId"].ToString();
                txt_description.Text = row_selected["Prod_description"].ToString();
            }

        }

        private void txt_qty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txt_qty.Text.All(char.IsDigit) || txt_qty.Text.Length == 0)
            {
                validate = false;
                if (txt_qty.Text.Length == 0)
                {
                    lblValidate.Content = "This field cannot be blank";
                }
                else
                {
                    lblValidate.Content = "This field accepts only Integers";

                }
            }
            else
            {
                lblValidate.Content = "";
                validate = true;
            }
        }
    }
}
