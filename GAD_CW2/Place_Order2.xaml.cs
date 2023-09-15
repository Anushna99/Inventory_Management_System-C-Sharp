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
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for Place_Order2.xaml
    /// </summary>
    public partial class Place_Order2 : Window
    {
        int qt;
        
        public Place_Order2()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            txt_oid.Text = obj.readData("select OrID from Orders where ID=(select max(ID) from Orders)", "OrID");
            datagrid.ItemsSource = obj.getData("select * from Product where QtyInHand>0").AsDataView();
        }

        bool lbl = false;
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_pid.Text = row_selected["ProdId"].ToString();
                txt_description.Text = row_selected["Prod_description"].ToString();
                qt = Convert.ToInt32(row_selected["QtyInHand"].ToString());
                txt_unit_price.Text = row_selected["Price"].ToString();
            }
            txt_qty.Focus();
            lbl = true;
        }

        private void btn_checkout_Click(object sender, RoutedEventArgs e)
        {
            int ct = Convert.ToInt32( obj.readData("select count(*) as count from Order_product where OID='"+txt_oid.Text+"'", "count"));
            if (ct >= 1)
            {
                string a = obj.readData("select sum(unit_price * Qty) as Total from Order_product where OID = '" + txt_oid.Text + "'", "Total");
                MessageBox.Show("Order has been placed successfully,Order Total is Rs." + a, "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Your cart is empty.Please add at least one item", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //bool lbl = false;
        private void btn_add_more_Click(object sender, RoutedEventArgs e)
        {
            lbl = false;
            if (txt_pid.Text.Length == 0) 
            { 
                MessageBox.Show("Please select the item you wish to add", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            { 
                if (txt_qty.Text.Length == 0) { lbl_qty.Content = "Please enter a value for quantity"; txt_qty.Focus(); }
                else if (txt_qty.Text.Any(char.IsLetter) || txt_qty.Text.Any(char.IsWhiteSpace)) { lbl_qty.Content = "Invalid Value"; }
                else if (!(txt_qty.Text.Any(char.IsDigit))) { lbl_qty.Content = "Invalid Value"; }
                else if (!Regex.Match(txt_qty.Text, @"^[0-9]+$").Success) { lbl_qty.Content = "Invalid Value,Please enter only integers"; }
                else if (Convert.ToInt32(txt_qty.Text) == 0) { lbl_qty.Content = "Invalid Value"; }
                else
            {
                lbl_qty.Content = "";
                lbl = true;
                int Q = Convert.ToInt32(txt_qty.Text);
                if (Q > qt)
                {
                    MessageBox.Show("Sorry..You have exceeded the available quantity in hand...maximum quantity available will be given", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_qty.Text = qt.ToString();
                }
                try
                {
                    int line = obj.save_update_delete("insert into Order_product values('" + txt_oid.Text + "','" + txt_pid.Text + "','" + txt_qty.Text + "','"+txt_unit_price.Text+"')");
                    int line1 = obj.save_update_delete("update Product set QtyInHand-='" + txt_qty.Text + "' where ProdId='" + txt_pid.Text + "'");
                    datagrid.ItemsSource = obj.getData("select * from Product where QtyInHand>0").AsDataView();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Something went wrong, order cannot proceed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong, order cannot proceed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                txt_description.Clear();
                txt_pid.Clear();
                txt_qty.Clear();
                txt_unit_price.Clear();
                datagrid1.ItemsSource = obj.getData("select Order_product.PrID,Order_product.Qty,Product.Prod_description from Order_product inner join Product on Order_product.PrID=Product.ProdId where OID='" + txt_oid.Text + "'").AsDataView();
                    txt_total.Text = obj.readData("select sum(unit_price*Qty) as total from Order_product where OID='" + txt_oid.Text + "'", "total");
            }
        }
        }
        string pid="",qty;
        private void remove_item_Click(object sender, RoutedEventArgs e)
        {
            if (pid == "") { MessageBox.Show("Please select the item you want to remove from cart", "Eror", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                int line5 = obj.save_update_delete("delete from Order_product where PrID='" + pid + "' and OID='"+txt_oid.Text+"'");
                int line6 = obj.save_update_delete("update Product set QtyInHand+='" + qty + "' where ProdId='" + pid + "'");
                datagrid.ItemsSource = obj.getData("select * from Product where QtyInHand>0").AsDataView();
                datagrid1.ItemsSource = obj.getData("select OID,PrID,Qty from Order_product where OID='" + txt_oid.Text + "'").AsDataView();
                pid = "";
                txt_total.Text = obj.readData("select sum(unit_price*Qty) as total from Order_product where OID='" + txt_oid.Text + "'", "total");
            }
        }

       
        private void txt_qty_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_pid.Text.Length == 0 && lbl==false)
            {
                lbl_qty.Content = "Please select an item first";
            }
            else if(lbl==false)
            {
                if (txt_qty.Text.Length == 0) 
                { lbl_qty.Content = "Please enter a value for quantity"; }
                else if (txt_qty.Text.Any(char.IsLetter) || txt_qty.Text.Any(char.IsWhiteSpace)) 
                { lbl_qty.Content = "Invalid Value"; }
                else if (!(txt_qty.Text.Any(char.IsDigit))) 
                { lbl_qty.Content = "Invalid Value"; }
                else if(!Regex.Match(txt_qty.Text, @"^[0-9]+$").Success) 
                        { lbl_qty.Content = "Invalid Value,Please enter only integes"; }
                else if (Convert.ToInt32(txt_qty.Text) == 0)
                { lbl_qty.Content = "Invalid Value"; }
                else
                {
                    lbl_qty.Content = "";
                }
            }
            lbl = false;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            int ct = Convert.ToInt32(obj.readData("select count(*) as count from Order_product where OID='" + txt_oid.Text + "'", "count"));
            if (ct >= 1)
            {
                MessageBox.Show("Please empty your cart before cancelling order", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are your sure that you want to cancel this order", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result.ToString() == "Yes")
                {
                    int line = obj.save_update_delete("delete from Orders where OrID='" + txt_oid.Text + "'");
                    if (line == 1) { MessageBox.Show("Order cancelled successfully", "INFO", MessageBoxButton.OK, MessageBoxImage.Information); }
                    this.Close();
                }
            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select * from Product where QtyInHand>0 and Prod_description like'%"+txt_search.Text+"%'").AsDataView();
            int ct = Convert.ToInt32(obj.readData("select count(*) as count from Product where QtyInHand>0 and Prod_description like '%"+txt_search.Text+"%'", "count"));
            if (ct == 0) { lbl_sh.Content = "No Items Match"; }
            else { lbl_sh.Content = ""; }
        }

        private void txt_search_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txt_search.Text.Length==0)
            {
                datagrid.ItemsSource = obj.getData("select * from Product where QtyInHand>0").AsDataView();
                lbl_sh.Content = "";
            }
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                pid = row_selected["PrID"].ToString();
                qty = row_selected["Qty"].ToString();
            }
        }
    }
}
