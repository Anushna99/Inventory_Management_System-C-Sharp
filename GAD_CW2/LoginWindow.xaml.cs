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

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-QG25JEH\\SQLEXPRESS;Initial Catalog=automotive;Integrated Security=True");
            //con.Open();
            SqlConnection con = new DB_Connection().GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("select userName from Users", con);
            SqlDataReader reader = cmd.ExecuteReader();
            //int x = 0;
            while (reader.Read())
            {
                cmb_user.Items.Add(reader["userName"].ToString());
                
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            /*
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QG25JEH\\SQLEXPRESS;Initial Catalog=automotive;Integrated Security=True");
            if (con.State == ConnectionState.Closed) { con.Open(); }
            string q="select Count(1) from users where userName='"+cmb_user.Text+"' and password='"+pwd_box.Password+"'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());*/
            //new
            string q = "select Count(1) as ct from users where userName='" + cmb_user.Text + "' and password='" + pwd_box.Password + "'";
            DB_Connection obj2 = new DB_Connection();
            int count = Convert.ToInt32(obj2.readData(q, "ct"));
            //
            if (count==1)
            {
                DB_Connection obj1 = new DB_Connection();
                DB_Connection.admin = bool.Parse(obj1.readData("select sAdmin from Users where userName='" + cmb_user.Text + "'", "sAdmin"));
                MainWindow obj = new MainWindow();
                obj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is incorrect.", "Eror", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                pwd_box.Clear();
                pwd_box.Focus();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pwd_box.Focus();
        }

        private void cmb_user_DropDownClosed(object sender, EventArgs e)
        {
            pwd_box.Focus();
        }
    }
}
