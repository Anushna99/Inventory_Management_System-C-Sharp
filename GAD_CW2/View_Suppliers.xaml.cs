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
    /// Interaction logic for View_Suppliers.xaml
    /// </summary>
    public partial class View_Suppliers : Page
    {
        public View_Suppliers()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            datagrid.ItemsSource = obj.getData("select Sno,Sname,Address,TP,MailID from Supplier").AsDataView();
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really wish to Remove this Supplier!..", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result.ToString() == "Yes")
            {
                begin:
                try
                {
                    int line1 = obj.save_update_delete("delete from Supplier where Sno='" + txt_sno.Text + "'");
                    if (line1 == 1)
                    {
                        MessageBox.Show("Supplier removed successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        datagrid.ItemsSource = obj.getData("select Sno,Sname,Address,TP,MailID from Supplier").AsDataView();
                        
                    }
                    

                }
                catch (SqlException)
                {
                                      
                      // MessageBox.Show("Supplier removing failed", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                    int line = obj.save_update_delete("delete from Supply_product where Sup_no='"+txt_sno.Text+"';");
                    goto begin;
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong, please try again...", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                txt_sno.Clear();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
               
                txt_sno.Text = row_selected["Sno"].ToString();
            }
        }
    }
}
