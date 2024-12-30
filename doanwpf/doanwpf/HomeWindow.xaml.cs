using doanwpf.MODEL;
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

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public bool islogin;
        private THONGTINTAIKHOAN _selectedAccount;
        public THONGTINTAIKHOAN SelectedAccount
        {
            get => _selectedAccount;
            set { _selectedAccount = value; }
        }
        public HomeWindow()
        {
            InitializeComponent();
            loadthongtintaikhoandata();
            DataContext = this;
        }
        void loadthongtintaikhoandata()
        {
            SelectedAccount = dataprovider.Ins.DB.THONGTINTAIKHOANs
            .FirstOrDefault(taikhoan => taikhoan.TenDangNhap == App.username && taikhoan.Matkhau == App.password);


        }
        private void btnproductclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new ProductsControl());
        }
        //mở tab
        #region
        private void btnwarehouseclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new WarehouseControl());
        }

        private void btnimportclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new ImportInvoiceControl());
        }

        private void btncustomerclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new CustomerControl());
        }

        private void btninvoiceclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new InvoiceControl());
        }

        private void btnproviderclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new ProviderControl());
        }

        private void btnemployeeclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new EmployeesControl());    
        }

        private void btnsaleclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new SalesReportControl());
        }

        private void btnhomeclick(object sender, RoutedEventArgs e)
        {
            ContenArea.Children.Add(new HomeControl());
        }
        #endregion

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            InfoAccount infoAccount = new InfoAccount();
            infoAccount.Show();
        }

    }
}
