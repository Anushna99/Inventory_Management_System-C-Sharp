using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Update_Suppliers.xaml
    /// </summary>
    public partial class Update_Suppliers : Page
    {
        public Update_Suppliers()
        {
            InitializeComponent();
        }

        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[4];

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int line = obj.save_update_delete("update Supplier set Sname='" + txt_name.Text + "',Address='" + txt_address.Text + "', TP='" + txt_tp.Text + "',MailID='" + txt_mail.Text + "' where Sno='" + txt_sno.Text + "'");
                    if (line == 1)
                    {
                        MessageBox.Show("Supplier updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Supplier updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Supplier updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong, please try again", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                txt_address.Clear();
                txt_mail.Clear();
                txt_name.Clear();
                txt_sno.Clear();
                txt_tp.Clear();

                lbl_address.Content = "";
                lbl_mail.Content = "";
                lbl_name.Content = "";
                lbl_tp.Content = "";
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select Sno,Sname,Address,TP,MailID from Supplier").AsDataView();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_address.Text = row_selected["Address"].ToString();
                txt_mail.Text = row_selected["MailID"].ToString();
                txt_name.Text = row_selected["Sname"].ToString();
                txt_sno.Text = row_selected["Sno"].ToString();
                txt_tp.Text = row_selected["TP"].ToString();
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
