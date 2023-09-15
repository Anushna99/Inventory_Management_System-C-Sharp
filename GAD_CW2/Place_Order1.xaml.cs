using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Place_Order1.xaml
    /// </summary>
    public partial class Place_Order1 : Page
    {
        public Place_Order1()
        {
            InitializeComponent();
            btn_proceed.Visibility = Visibility.Hidden;
            btn_proceed_Copy.Visibility = Visibility.Hidden;
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            txt_name.Visibility = Visibility.Hidden;
            txt_address.Visibility = Visibility.Hidden;
            txt_tp.Focus();
        }
        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[3];
        private void btn_proceed_Click(object sender, RoutedEventArgs e)
        {
            if (validate[2] == false || validate[1] == false)
            {
                MessageBox.Show("Please fill with valid info", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int line2 = obj.save_update_delete("insert into Customer values('" + txt_tp.Text + "','" + txt_name.Text + "','" + txt_address.Text + "')");

                    int line1 = obj.save_update_delete("insert into Orders(prefix,Cus_TP) values('" + "OD" + "','" + txt_tp.Text + "')");
                    if (line1 == 1 && line2 == 1)
                    {
                        Place_Order2 obj = new Place_Order2();
                        obj.ShowDialog();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Eror..", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                txt_address.Clear();
                txt_name.Clear();
                txt_tp.Clear();
                lbl_address1.Content = "";
                lbl_tp.Content = "";
                lbl_name1.Content = "";

                btn_proceed.Visibility = Visibility.Hidden;
                btn_proceed_Copy.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbl2.Visibility = Visibility.Hidden;
                txt_name.Visibility = Visibility.Hidden;
                txt_address.Visibility = Visibility.Hidden;
            }
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            if (validate[0] == false)
            {
                MessageBox.Show("Please enter a valid telephone number", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string count = obj.readData("select count(*) as count from Customer where Customer_TP='" + txt_tp.Text + "'", "count");
                if (count == "1")
                {
                    lbl_name.Content = "Customer Name:  " + obj.readData("select Customer_name from Customer where Customer_TP='" + txt_tp.Text + "'", "Customer_name");
                    lbl_address.Content = "Address:  " + obj.readData("select Address from Customer where Customer_TP='" + txt_tp.Text + "'", "Address");
                    btn_proceed_Copy.Visibility = Visibility.Visible;
                    lbl_address.Visibility = Visibility.Visible;
                    lbl_name.Visibility = Visibility.Visible;
                    btn_proceed.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbl1.Visibility = Visibility.Visible;
                    lbl2.Visibility = Visibility.Visible;
                    txt_name.Visibility = Visibility.Visible;
                    txt_address.Visibility = Visibility.Visible;
                    btn_proceed.Visibility = Visibility.Visible;
                    lbl_address.Visibility = Visibility.Hidden;
                    lbl_name.Visibility = Visibility.Hidden;
                    btn_proceed_Copy.Visibility = Visibility.Hidden;
                    txt_name.Focus();

                }
            }
        }

        private void btn_proceed_Copy_Click(object sender, RoutedEventArgs e)
        {
            int line1 = obj.save_update_delete("insert into Orders(prefix,Cus_TP) values('" + "OD" + "','" + txt_tp.Text + "')");
            if (line1 == 1)
            {
                Place_Order2 obj = new Place_Order2();
                obj.ShowDialog();
            }
            txt_tp.Clear();
            lbl_address.Content = "";
            lbl_name.Content = "";
            lbl_tp.Content = "";

            btn_proceed.Visibility = Visibility.Hidden;
            btn_proceed_Copy.Visibility = Visibility.Hidden;
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            txt_name.Visibility = Visibility.Hidden;
            txt_address.Visibility = Visibility.Hidden;
        }

        private void txt_name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Down)
            {
                txt_address.Focus();
            }
            if(e.Key==Key.Up)
            {
                txt_tp.Focus();
            }
        }

        private void txt_address_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Up)
            {
                txt_name.Focus();
            }
        }

        private void txt_tp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                validate[0] = false;

                if (txt_tp.Text.Length == 0)
                {
                    lbl_tp.Content = "This filed cannot be blank";
                }
                else
                {
                    lbl_tp.Content = "Invalid Telephone Number";
                }
            }
            else
            {
                lbl_tp.Content = "";
                validate[0] = true;
            }
        }

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_name.Text.Length==0)
            {
                validate[1] = false;
                lbl_name1.Content = "This field cannot be blank";
            }
            else
            {
                lbl_name1.Content = "";
                validate[1] = true;
            }
        }

        private void txt_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_address.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                validate[2] = false;
                lbl_address1.Content = "Invalid address";
            }
            else
            {
                lbl_address1.Content = "";
                validate[2] = true;
            }

        }
    }
}
