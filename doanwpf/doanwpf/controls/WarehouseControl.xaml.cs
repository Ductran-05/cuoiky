using doanwpf.ADD;
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
    /// Interaction logic for WarehouseControl.xaml
    /// </summary>
    public partial class WarehouseControl : UserControl
    {
        private ObservableCollection<SANPHAM> _khosanphamlist;
        public ObservableCollection<SANPHAM> khosanphamlist { get => _khosanphamlist; set { _khosanphamlist = value; } }
        private ObservableCollection<NHAPHANG> _nhaphanglist;
        public ObservableCollection<NHAPHANG> nhaphanglist { get => _nhaphanglist; set { _nhaphanglist = value; } }
        public WarehouseControl()
        {
            InitializeComponent();
            loadkhosanphamdata();
            loadnhaphangdata();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddImportInvoice addImportInvoice = new AddImportInvoice();
            addImportInvoice.Show();
        }
        void loadkhosanphamdata()
        {
            khosanphamlist= new ObservableCollection<SANPHAM>(dataprovider.Ins.DB.SANPHAMs.ToList());
        }
        void loadnhaphangdata()
        {
            nhaphanglist = new ObservableCollection<NHAPHANG>(dataprovider.Ins.DB.NHAPHANGs.ToList());
        }
    }
}
