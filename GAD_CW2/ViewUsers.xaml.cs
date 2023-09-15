using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : Page
    {
        public ViewUsers()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = obj.getData("select UserId,userName from Users").AsDataView();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txt_username.Text= row_selected["userName"].ToString();
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QG25JEH\\SQLEXPRESS;Initial Catalog=automotive;Integrated Security=True");
            if (con.State == ConnectionState.Closed) { con.Open(); }
            string q = "select Count(1) from users where userName='" + txt_username.Text + "' and password='" + pwd.Password + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1 || DB_Connection.admin)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure that you want to remove this user", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result.ToString() == "Yes")
                {
                    SqlCommand cmd1 = new SqlCommand("delete from Users where UserName='" + txt_username.Text + "'", con);
                    int i= cmd1.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("User removed successfully", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                txt_username.Clear();
                pwd.Clear();
                datagrid.ItemsSource = obj.getData("select UserId,userName from Users").AsDataView();

            }
            else
            {
                MessageBox.Show("Password is incorrect.", "Eror", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
