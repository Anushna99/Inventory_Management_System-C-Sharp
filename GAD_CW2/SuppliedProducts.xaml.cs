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

namespace GAD_CW2
{
    /// <summary>
    /// Interaction logic for SuppliedProducts.xaml
    /// </summary>
    public partial class SuppliedProducts : Page
    {
        public SuppliedProducts()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //datagrid.ItemsSource = obj.getData("select PID,Sup_no from Supply_product").AsDataView();
            datagrid.ItemsSource = obj.getData("select Supply_product.PID,Product.Prod_description,Supply_product.Sup_no,Supplier.Sname from ((Supply_product inner join Supplier on Supply_product.Sup_no=Supplier.Sno) inner join Product on Supply_product.PID=Product.ProdId)").AsDataView();

        }
    }
}
