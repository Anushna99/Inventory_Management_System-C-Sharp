using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for Delete_Employee.xaml
    /// </summary>
    public partial class Delete_Employee : Page
    {
        public Delete_Employee()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result= MessageBox.Show("Do you really wish to delete this record !..", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result.ToString() == "Yes")
            {
                try
                {
                    int line = obj.save_update_delete("delete from Employee where Eno='" + txt_eno.Text + "'");
                    if (line == 1)
                    {
                        MessageBox.Show("Data deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data deletion failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Data deletion failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception)
                {
                    MessageBox.Show("Eror", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                txt_eno.Clear();
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
                txt_eno.Text = row_selected["Eno"].ToString();                
            }
        }
    }
}
