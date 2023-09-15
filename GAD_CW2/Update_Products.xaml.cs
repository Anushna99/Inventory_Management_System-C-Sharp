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
    /// Interaction logic for Update_Products.xaml
    /// </summary>
    public partial class Update_Products : Page
    {
        public Update_Products()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[2];
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (txt_pid.Text.Length == 0)
            {
                MessageBox.Show("Please select the product you wish to update", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(txt_description.Text.Length==0 || txt_brand.Text.Length == 0)
            {
                MessageBox.Show("Please fill every field", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int line = obj.save_update_delete("update Product set Prod_description='" + txt_description.Text + "', Price='" + txt_price.Text + "',Brand='" + txt_brand.Text + "', QtyInHand ='" + txt_qt.Text + "' where ProdId='" + txt_pid.Text + "'");

                    if (txt_sno.Text.Length != 0)
                    {
                        int ct = Convert.ToInt32(obj.readData("select count(*) as count from Supply_product where PID='" + txt_pid.Text + "'", "count"));
                        if (ct == 1)
                        {
                            int line1 = obj.save_update_delete("update Supply_product set PID='" + txt_pid.Text + "',Sup_no='" + txt_sno.Text + "'");
                        }
                        else
                        {
                            int line1 = obj.save_update_delete("insert into Supply_product(PID,Sup_no) values('" + txt_pid.Text + "','" + txt_sno.Text + "')");
                        }
                    }

                    if (line == 1)
                    {
                        MessageBox.Show("Product updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Product updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong, please try again", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                datagrid.ItemsSource = obj.getData("select ProdId,Prod_description,Price,Brand,QtyInHand from Product").AsDataView();

                txt_brand.Clear();
                txt_description.Clear();
                txt_pid.Clear();
                txt_price.Clear();
                txt_qt.Clear();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select ProdId,Prod_description,Price,Brand,QtyInHand from Product").AsDataView();
            datagrid1.ItemsSource = obj.getData("select Sno,Sname from Supplier").AsDataView();
        }


        private void datagrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_pid.Text = row_selected["ProdId"].ToString();
                txt_description.Text = row_selected["Prod_description"].ToString();
                txt_brand.Text = row_selected["Brand"].ToString();
                txt_price.Text = row_selected["Price"].ToString();
                txt_qt.Text = row_selected["QtyInHand"].ToString();
            }
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
