using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Add_Product.xaml
    /// </summary>
    public partial class Add_Product : Page
    {
        public Add_Product()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[2];
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_type.SelectedItem == null)
            {
                MessageBox.Show("Product please select the type of product you want to add", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            else if (txt_description.Text.Length == 0)
            {
                lblDescription.Content = "This field cannot be blank";
            }
            else if (txt_brand.Text.Length == 0)
            {
                lblDescription.Content = "";
                lblBrand.Content = "This field cannot be blank";
            }
            else if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                lblBrand.Content = "";
                lblDescription.Content = "";
                string prefix;
                if (cmb_type.SelectedIndex == 0) { prefix = "T"; }
                else if (cmb_type.SelectedIndex == 1) { prefix = "A"; }
                else if (cmb_type.SelectedIndex == 2) { prefix = "L"; }
                else { prefix = "O"; }

                try
                {
                    int line = obj.save_update_delete("insert into Product values('" + prefix + "','" + txt_description.Text + "','" + txt_price.Text + "','" + txt_brand.Text + "','" + txt_qt.Text + "')");
                    if (txt_sno.Text.Length != 0)
                    {
                        string pid = obj.readData("select ProdId from Product where ID=(select max(ID) from Product)", "ProdId");
                        int line1 = obj.save_update_delete("insert into Supply_product(PID,Sup_no) values('" + pid + "','" + txt_sno.Text + "')");
                    }
                    if (line == 1)
                    {
                        MessageBox.Show("Product added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product adding failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Product adding failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show("Something went Wrong,Please try again!...", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                txt_brand.Clear();
                txt_description.Clear();
                txt_price.Clear();
                txt_qt.Clear();
                txt_sno.Clear();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select Sno,Sname from Supplier").AsDataView();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_sno.Text = row_selected["Sno"].ToString();
            }
        }

        private void txt_price_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal d;
            if (!(decimal.TryParse(txt_price.Text, out d) && d >= 0 && d * 100 == Math.Floor(d * 100)))

            {
                validate[0] = false;
                lblPrice.Content = "Invalid Price";
            }
            else
            {
                lblPrice.Content = "";
                validate[0] = false;
            }
        }

        private void txt_qt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txt_qt.Text.All(char.IsDigit) || txt_qt.Text.Length == 0)
            {
                validate[1] = false;
                if (txt_qt.Text.Length == 0)
                {
                    lblQty.Content = "This field cannot be blank";
                }
                else
                {
                    lblQty.Content = "This field accepts only Integers";

                }
            }
            else
            {
                lblQty.Content = "";
                validate[1] = true;
            }
        }
    }
}
