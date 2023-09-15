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
    /// Interaction logic for Update_Employee.xaml
    /// </summary>
    public partial class Update_Employee : Page
    {
        public Update_Employee()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[6];
        private void dob_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_age.Text = (DateTime.Now.Year - dob_picker.SelectedDate.Value.Year).ToString();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (cmb_gender.SelectedItem == null || cmb_dep.SelectedItem == null || cmb_pos.SelectedItem == null || dob_picker.SelectedDate == null)
            {
                if (cmb_gender.SelectedItem == null)
                {
                    lbl_gender.Content = "Please select gender";
                }
                if (cmb_dep.SelectedItem == null)
                {
                    lbl_dept.Content = "Please select department";
                }
                if (cmb_pos.SelectedItem == null)
                {
                    lbl_position.Content = "Please select the position";
                }
                if (dob_picker.SelectedDate == null)
                {
                    lbl_dob.Content = "Please select the DOB";
                }
            }

            else
            {

                try
                {
                    string a;
                    if (cmb_dep.SelectedIndex == 0) { a = "D01"; }
                    else if (cmb_dep.SelectedIndex == 1) { a = "D02"; }
                    else { a = "D03"; }
                    int line = obj.save_update_delete("update Employee set Fname='" + txt_fname.Text + "',Surname='" + txt_sname.Text + "',Gender='" + cmb_gender.Text + "',Hometown='" + txt_htown.Text + "',DOB='" + dob_picker.SelectedDate.Value + "',Age='" + txt_age.Text + "',TP='" + txt_tp.Text + "',Position='" + cmb_pos.Text + "',Salary='" + txt_salary.Text + "',Email='" + txt_mail.Text + "',Dno='" + a + "' where Eno='" + txt_eno.Text + "'");
                    if (line == 1)
                    {
                        MessageBox.Show("Data updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    if (line == 0)
                    {
                        MessageBox.Show("Data updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Data updating failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show("Please check again", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                txt_age.Clear();
                txt_eno.Clear();
                txt_fname.Clear();
                txt_htown.Clear();
                txt_mail.Clear();
                txt_salary.Clear();
                txt_sname.Clear();
                txt_tp.Clear();


                cmb_gender.SelectedItem = null;
                cmb_dep.SelectedItem = null;
                cmb_pos.SelectedItem = null;
                dob_picker.SelectedDate = null;

                lbl_dept.Content = "";
                lbl_dob.Content = "";
                lbl_fname.Content = "";
                lbl_gender.Content = "";
                lbl_hometown.Content = "";
                lbl_mail.Content = "";
                lbl_position.Content = "";
                lbl_salary.Content = "";
                lbl_sname.Content = "";
                lbl_tp.Content = "";


            }
        }
        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select Eno,Fname,Surname,Gender,Hometown,DOB,Age,TP,Position,Salary,Email,Dno from Employee").AsDataView();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_age.Text = row_selected["Age"].ToString();
                txt_eno.Text = row_selected["Eno"].ToString();
                txt_fname.Text = row_selected["Fname"].ToString();
                txt_htown.Text = row_selected["Hometown"].ToString();
                txt_mail.Text = row_selected["Email"].ToString();
                txt_salary.Text = row_selected["Salary"].ToString();
                txt_sname.Text = row_selected["Surname"].ToString();
                txt_tp.Text = row_selected["TP"].ToString();
            }
        }

        private void txt_fname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_fname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                validate[0] = false;
                if (txt_fname.Text.Length == 0)
                {
                    lbl_fname.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_fname.Content = "Invalid Name";

                }
            }
            else
            {
                lbl_fname.Content = "";
                validate[0] = true;
            }

        }

        private void txt_sname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_sname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                validate[1] = false;
                if (txt_sname.Text.Length == 0)
                {
                    lbl_sname.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_sname.Content = "Invalid Name";

                }
            }
            else
            {
                lbl_sname.Content = "";
                validate[1] = true;
            }

        }

        private void txt_htown_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.Match(txt_htown.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                validate[2] = false;
                if (txt_htown.Text.Length == 0)
                {
                    lbl_hometown.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_hometown.Content = "Invalid value";

                }
            }
            else
            {
                lbl_hometown.Content = "";
                validate[2] = true;
            }
        }

        private void txt_tp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                validate[3] = false;

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
                validate[3] = true;
            }
        }

        private void txt_salary_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_salary.Text, @"^\d+\.?\d*$"))
            {
                validate[4] = false;
                if (txt_salary.Text.Length == 0)
                {
                    lbl_salary.Content = "This filed cannot be blank";
                }
                else
                {
                    lbl_salary.Content = "Invalid value";
                }
            }
            else
            {
                lbl_salary.Content = "";
                validate[4] = true;
            }
        }

        private void txt_mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_mail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
            {
                validate[5] = false;
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
                validate[5] = true;
            }
        }
    }
}
