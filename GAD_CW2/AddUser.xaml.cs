using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(obj.readData("select count(*) as count from Users where userName='" + txt_username.Text + "'", "count"));
           
           
                if (txt_username.Text.Length==0)
                {
                lbl_username.Content = "This field cannot be blank";
                }
                else if(count==1)
            {
                lbl_username.Content = "Sorry that user name is already taken..";
            }
                else if(pwd.Password.Length==0)
            {
                lbl_username.Content = "";
                lbl_pwd.Content = "This field cannot be blank";
            }
                else if(pwd.Password.Length<=4)
            {
                lbl_username.Content = "";
                lbl_pwd.Content = "Password is too short";
            }
                else if(pwd.Password!=confirm_pwd.Password)
            {
                lbl_username.Content = "";
                lbl_pwd.Content = "";
                lbl_cpwd.Content = "Confirmed password does not match";
            }
            
            else
            {
                lbl_username.Content = "";lbl_pwd.Content = ""; lbl_cpwd.Content = "";
                try
                {
                    if (ck_admin.IsChecked == true)
                    {
                        int line = obj.save_update_delete("insert into Users values('" + txt_username.Text + "','" + pwd.Password + "','"+"true"+"')");
                        if (line == 1)
                        {
                            MessageBox.Show("User Added To The System Successfuly", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                            txt_username.Clear();
                            pwd.Clear();
                            confirm_pwd.Clear();
                        }
                    }
                    else
                    {
                        int line = obj.save_update_delete("insert into Users values('" + txt_username.Text + "','" + pwd.Password + "','"+"false"+"')");
                        if (line == 1)
                        {
                            MessageBox.Show("User Added To The System Successfuly", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                            txt_username.Clear();
                            pwd.Clear();
                            confirm_pwd.Clear();
                        }
                    }
                    
                }
                catch(SqlException)
                {
                    MessageBox.Show("Sorry this username is not available,please pick another one", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch(Exception)
                {
                    MessageBox.Show("Something Wrong, Please try again", "EROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

       

        
    }
}
