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

namespace doanwpf.controls
{
    /// <summary>
    /// Interaction logic for CTHDwindow.xaml
    /// </summary>
    public partial class CTHDwindow : Window
    {
        private ObservableCollection<CTHOADON> _cthdlist;
        public ObservableCollection<CTHOADON> cthdlist { get => _cthdlist; set { _cthdlist = value; } }
        public InvoiceControl InvoiceControl { get; set; } // Kiểu phải đúng
        public CTHDwindow()
        {
            InitializeComponent();
        }

        

        private void dgproductininvoice_Loaded(object sender, RoutedEventArgs e)
        {
            var selected = InvoiceControl.dginvoice.SelectedItem as DONHANG;
            if (selected != null)
            {
                cthdlist = new ObservableCollection<CTHOADON>(dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaHD == selected.MaHD));
                dgproductininvoice.ItemsSource = cthdlist;
            }
        }
    }
}
