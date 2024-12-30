using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        private ObservableCollection<SANPHAM> _sanphamlist;
        public ObservableCollection<SANPHAM> sanphamlist { get => _sanphamlist; set { _sanphamlist = value; } }
        private ObservableCollection<LOAISANPHAM> _loaisanphamlist;
        public ObservableCollection<LOAISANPHAM> loaisanphamlist { get => _loaisanphamlist;set { _loaisanphamlist= value; } }
        private ObservableCollection<CHATLIEU> _chatlieulist;
        public ObservableCollection<CHATLIEU> chatlieulist { get => _chatlieulist; set { _chatlieulist = value; } }
        public ProductsControl()
        {
            InitializeComponent();
            loadsanphamdata();
            loadloaisanphamdata();
            loadchatlieudata(); 
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();          
            addProduct.ProductsControl=this;
            addProduct.ShowDialog();
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            RepairProduct repairProduct = new RepairProduct();
            var selectedProduct = dgproduct.SelectedItem as SANPHAM;
            if (selectedProduct != null)
            {
                repairProduct.DataContext = selectedProduct;
            }
            repairProduct.ProductsControl = this;
            repairProduct.ShowDialog();
        }
        void loadsanphamdata()
        {
            sanphamlist = new ObservableCollection<SANPHAM>(dataprovider.Ins.DB.SANPHAMs.ToList());
        }
        void loadloaisanphamdata()
        {
            loaisanphamlist = new ObservableCollection<LOAISANPHAM>(dataprovider.Ins.DB.LOAISANPHAMs.ToList());
        }
        void loadchatlieudata()
        {
            chatlieulist = new ObservableCollection<CHATLIEU>(dataprovider.Ins.DB.CHATLIEUx.ToList());
        }
    }
}
