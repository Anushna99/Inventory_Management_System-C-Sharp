using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for Add_Employee.xaml
    /// </summary>
    public partial class Add_Employee : Page
    {
        DB_Connection obj = new DB_Connection();

        public Add_Employee()
        {
            InitializeComponent();
            txt_id.Text = "Emp"+(Convert.ToInt32(obj.readData("select max(ID) as id from Employee", "id")) + 1).ToString().PadLeft(3, '0');
        }
        //DB_Connection obj = new DB_Connection();
        bool[] validate = new bool[6];
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (validate.Contains(false))
            {
                MessageBox.Show("Please fill correctly", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(cmb_gender.SelectedItem == null || cmb_dep.SelectedItem == null || cmb_pos.SelectedItem == null || dob_picker.SelectedDate == null)
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
                    int line = obj.save_update_delete("insert into Employee values('" + "Emp" + "','" + txt_fname.Text + "','" + txt_sname.Text + "','" + cmb_gender.Text + "','" + txt_htown.Text + "','" + dob_picker.SelectedDate.Value + "','" + txt_age.Text + "','" + txt_tp.Text + "','" + cmb_pos.Text + "','" + txt_salary.Text + "','" + txt_mail.Text + "','" + a + "')");
                    if (line == 1)
                    {
                        MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        SmtpClient Client = new SmtpClient()
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential()
                            {
                                UserName = "ashashipriyajayathunga@gmail.com",
                                Password = "jumbojet"
                            }
                        };
                        MailAddress FromEmail = new MailAddress("ashashipriyajayathunga@gmail.com", "ABC AUTOMOTIVE (PVT) LTD.");
                        MailAddress ToEmail = new MailAddress(txt_mail.Text, txt_fname.Text);
                        MailMessage Message = new MailMessage()
                        {
                            From = FromEmail,
                            Subject = "Congratulations",
                            Body = txt_fname.Text + " ,You have been successfully enrolled as an employee at our company",
                        };
                        Message.To.Add(ToEmail);
                        try
                        {
                            Client.Send(Message);
                            MessageBox.Show("Mail has been sent to employee", "Done");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sending mail failed" , "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                            //MessageBox.Show("Sending mail failed \n" + ex.InnerException.Message, "Eror",MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                        txt_id.Text = "Emp" + (Convert.ToInt32(obj.readData("select max(ID) as id from Employee", "id")) + 1).ToString().PadLeft(3, '0');
                    }
                    if (line == 0)
                    {
                        MessageBox.Show("Registration failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Data insertion failed", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Eror", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                txt_age.Clear();
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

        private void dob_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dob_picker.SelectedDate != null)
            { 
                txt_age.Text = (DateTime.Now.Year - dob_picker.SelectedDate.Value.Year).ToString();
            }
            txt_tp.Focus();
        }

        private void txt_fname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Down)
            {
                txt_sname.Focus();
            }
            else if(e.Key==Key.Up)
            {
                txt_mail.Focus();
            }
        }

        private void txt_sname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
             if (e.Key == Key.Up)
            {
                txt_fname.Focus();
            }
        }

        private void cmb_gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_htown.Focus();
        }

        private void cmb_gender_DropDownClosed(object sender, EventArgs e)
        {
            txt_htown.Focus();
        }

        private void cmb_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_salary.Focus();
        }

        private void cmb_pos_DropDownClosed(object sender, EventArgs e)
        {
            txt_salary.Focus();
        }

        private void txt_mail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                txt_fname.Focus();
            }
            
        }

        private void cmb_dep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_mail.Focus();
        }

        private void cmb_dep_DropDownClosed(object sender, EventArgs e)
        {
            txt_mail.Focus();
        }

        private void txt_fname_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (txt_fname.Text.Any(char.IsDigit) || txt_fname.Text.Any(char.IsWhiteSpace) || txt_fname.Text.Length==0)
            if(!Regex.Match(txt_fname.Text, "^[A-Z][a-zA-Z]*$").Success)
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
            if(!Regex.Match(txt_sname.Text, "^[A-Z][a-zA-Z]*$").Success)
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
            //if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{9,10}$"))
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
            if(!Regex.IsMatch(txt_salary.Text, @"^\d+\.?\d*$"))
            {
                validate[4] = false;
                if(txt_salary.Text.Length==0)
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
            if(!Regex.IsMatch(txt_mail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
            {
                validate[5] = false;
                if(txt_mail.Text.Length==0)
                {
                    lbl_mail.Content = "This field cannot be blank";
                }
                else
                {
                    lbl_mail.Content="Invalid mail address";
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
