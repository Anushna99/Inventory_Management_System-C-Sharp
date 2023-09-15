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
    /// Interaction logic for Add_Supplier.xaml
    /// </summary>
    public partial class Add_Supplier : Page
    {
        public Add_Supplier()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[4];
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int line = obj.save_update_delete("insert into Supplier values('" + "Sup" + "','" + txt_name.Text + "','" + txt_address.Text + "','" + txt_tp.Text + "','" + txt_mail.Text + "')");
                    if (line == 1)
                    {
                        MessageBox.Show("Supplier added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Supplier adding failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Supplier adding failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show("Operation failed, please try again", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                txt_address.Clear();
                txt_mail.Clear();
                txt_name.Clear();
                txt_tp.Clear();
                lbl_address.Content = "";
                lbl_mail.Content = "";
                lbl_name.Content = "";
                lbl_tp.Content = "";

            }
        }

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_name.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                validate[0] = false;
                if (txt_name.Text.Length == 0)
                {
                    lbl_name.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_name.Content = "Invalid Name";

                }
            }
            else
            {
                lbl_name.Content = "";
                validate[0] = true;
            }
        }

        private void txt_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_address.Text, "^[a-zA-Z0-9,/.-]*$").Success)
            {
                validate[1] = false;
                if (txt_address.Text.Length == 0)
                {
                    lbl_address.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_address.Content = "Invalid Address";

                }
            }
            else if (txt_address.Text.Length == 0)
            {
                validate[1] = false;
                lbl_address.Content = "This field cannot be blank";
            }
            else
            {
                lbl_address.Content = "";
                validate[1] = true;
            }
        }

        private void txt_tp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                validate[2] = false;
                if (txt_tp.Text.Length == 0)
                {
                    lbl_tp.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_tp.Content = "Invalid Telephone number";

                }
            }
            else
            {
                lbl_tp.Content = "";
                validate[2] = true;
            }
        }

        private void txt_mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_mail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
            {
                validate[3] = false;
                if (txt_mail.Text.Length == 0)
                {
                    lbl_mail.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_mail.Content = "Invalid mail address";
                }
            }
            else
            {
                lbl_mail.Content = "";
                validate[3] = true;
            }
        }
    }
}
