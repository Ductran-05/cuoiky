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
    /// Interaction logic for CTNhap.xaml
    /// </summary>
    public partial class CTNhap : Window
    {
        public WarehouseControl WarehouseControl { get; set; }
        private ObservableCollection<CTNHAP> _ctnhaplist;
        public ObservableCollection<CTNHAP> ctnhaplist { get => _ctnhaplist; set { _ctnhaplist = value; } }
        public CTNhap()
        {
            InitializeComponent();
        }

        private void dgproductininvoice_Loaded(object sender, RoutedEventArgs e)
        {
            var selectedinvoice = WarehouseControl.dgimportinvoice.SelectedItem as NHAPHANG;
            if (selectedinvoice != null)
            {
                ctnhaplist = new ObservableCollection<CTNHAP>(dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaHD == selectedinvoice.MaHD).ToList());
            }
        }
    }
}
