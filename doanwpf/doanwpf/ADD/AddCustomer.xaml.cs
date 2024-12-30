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
using System.Windows.Shapes;

namespace doanwpf
{
    
    public partial class AddCustomer : Window
    {
        private ObservableCollection<KHACHHANG> _khachhanglist;
        public ObservableCollection<KHACHHANG> khachhanglist { get => _khachhanglist; set { _khachhanglist = value; } }
        public AddCustomer()
        {
            InitializeComponent();

            DataContext = this;
        }
        void loadkhachhangdata()
        {
            khachhanglist = new ObservableCollection<KHACHHANG>(dataprovider.Ins.DB.KHACHHANGs.ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cusName = CustomerName.Text;
            string gender;
            if (rbNam.IsChecked == true)
            {
                gender = "Nam";
            }
            else if (rbNu.IsChecked == true)
            {
                gender = "Nữ";
            }
        }
    }
}
