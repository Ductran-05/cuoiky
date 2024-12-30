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
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        private ObservableCollection<KHACHHANG> _khachhanglist;
        public ObservableCollection<KHACHHANG>  khachhanglist{ get => _khachhanglist; set { _khachhanglist = value; } }
        public CustomerControl()
        {
            InitializeComponent();
            loadkhachhangdata();
            DataContext=this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }
        void loadkhachhangdata()
        {
            khachhanglist = new ObservableCollection<KHACHHANG>(dataprovider.Ins.DB.KHACHHANGs.ToList());
        }
    }
}
