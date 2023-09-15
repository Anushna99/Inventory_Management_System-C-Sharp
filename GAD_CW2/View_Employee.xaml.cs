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
    /// Interaction logic for View_Employee.xaml
    /// </summary>
    public partial class View_Employee : Page
    {
        public View_Employee()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DB_Connection obj = new DB_Connection();
            dataGrid.ItemsSource = obj.getData("select Eno,Fname,Surname,Gender,Hometown,DOB,Age,TP,Position,Salary,Email,Dno from Employee").AsDataView();
        }
    }
}
