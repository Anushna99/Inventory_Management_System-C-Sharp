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
    /// Interaction logic for View_Orders.xaml
    /// </summary>
    public partial class View_Orders : Page
    {
        public View_Orders()
        {
            InitializeComponent();
        }
        DB_Connection obj = new DB_Connection();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid1.ItemsSource = obj.getData("select Order_product.OID,Order_product.PrID,convert(varchar(10),Orders.Order_date,111) as OrderDate,Order_product.Qty,Product.Prod_description,Product.Brand from ((Order_product inner join Product on Order_product.PrID=Product.ProdId)inner join Orders on Orders.OrID=Order_product.OID)").AsDataView();
            // datagrid2.ItemsSource = obj.getData("select D.OID,sum( P.Price*D.Qty) as Order_Total from Order_product D, Product P where D.PrID = P.ProdId group by D.OID; ").AsDataView();
            datagrid2.ItemsSource = obj.getData("select Order_product.OID,convert(varchar(10),Orders.Order_date,111) as OrderDate,Customer.Customer_name,Customer.Customer_TP,sum( Order_product.unit_price*Order_product.Qty) as Order_Total from(((Order_product inner join Product on Order_product.PrID = Product.ProdId)inner join Orders on Orders.OrID=Order_product.OID)inner join Customer on Orders.Cus_TP=Customer.Customer_TP ) group by Order_product.OID,Customer.Customer_name,Customer.Customer_TP,Orders.Order_date;").AsDataView();

        }
    }
}
