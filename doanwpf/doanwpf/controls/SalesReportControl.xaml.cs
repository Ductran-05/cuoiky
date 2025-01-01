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
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for SalesReportControl.xaml
    /// </summary>
    public partial class SalesReportControl : UserControl
    {
        private ObservableCollection<CTHOADON> _cthdlist;
        public ObservableCollection<CTHOADON> cthdlist { get => _cthdlist; set { _cthdlist = value; } }
        private ObservableCollection<CTNHAP> _ctnhaplist;
        public ObservableCollection<CTNHAP> ctnhaplist { get => _ctnhaplist; set { _ctnhaplist = value; } }
        private ObservableCollection<DoanhThu> _doanhthu;
        public ObservableCollection<DoanhThu> doanhthu { get => _doanhthu; set { _doanhthu = value; } }
        public DoanhThu DoanhThu { get; set; }
        public SalesReportControl()
        {
            InitializeComponent();
            loaddata(); // Gọi trước
            DataContext = this;
        }

        void loaddata()
        {
            cthdlist = new ObservableCollection<CTHOADON>(dataprovider.Ins.DB.CTHOADONs.ToList());
            ctnhaplist = new ObservableCollection<CTNHAP>(dataprovider.Ins.DB.CTNHAPs.ToList());
            DoanhThu = new DoanhThu
            {
                NhapHang = getnhaphang(),
                DonHang = getdonhang(),
                LoiNhuan = getdonhang() - getnhaphang()
            };
            doanhthu = new ObservableCollection<DoanhThu>();
            doanhthu.Add(DoanhThu);
        }
        double getnhaphang()
        {
            return ctnhaplist.Sum(ct => ct.Thanhtien ?? 0);
        }

        double getdonhang()
        {
            return cthdlist.Sum(ct => ct.Thanhtien ?? 0);
        }
    }
}
