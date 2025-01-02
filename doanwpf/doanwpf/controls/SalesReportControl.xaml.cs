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
        private ObservableCollection<DONHANG> _donhanglist;
        public ObservableCollection<DONHANG> donhanglist { get => _donhanglist; set { _donhanglist = value; } }
        private ObservableCollection<NHAPHANG> _nhaphanglist;
        public ObservableCollection<NHAPHANG> nhaphanglist { get => _nhaphanglist; set { _nhaphanglist = value; } }
        private ObservableCollection<DoanhThu> _doanhthu;
        public ObservableCollection<DoanhThu> doanhthu { get => _doanhthu; set { _doanhthu = value; } }
        public DoanhThu DoanhThu { get; set; }
        public SalesReportControl()
        {
            InitializeComponent();
            doanhthu = new ObservableCollection<DoanhThu>();

            donhanglist = new ObservableCollection<DONHANG>(dataprovider.Ins.DB.DONHANGs.ToList());
            nhaphanglist = new ObservableCollection<NHAPHANG>(dataprovider.Ins.DB.NHAPHANGs.ToList());
            loaddata(); // Gọi trước
            DataContext = this;
        }

        void loaddata()
        {
            
            DoanhThu = new DoanhThu
            {
                NhapHang = getnhaphang(),
                DonHang = getdonhang(),
                LoiNhuan = getdonhang() - getnhaphang()
            };
            doanhthu.Clear();
            doanhthu.Add(DoanhThu);

        }
        double getnhaphang()
        {
            return nhaphanglist.Sum(ct => ct.Trigia ?? 0);
        }

        double getdonhang()
        {
            return donhanglist.Sum(ct => ct.Trigia ?? 0);
        }

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if(comboBox.SelectedItem.ToString().Equals(nam.ToString()))
            {
                datanam();
                
            }
            else if(comboBox.SelectedItem.ToString().Equals(thang.ToString()))
            {
                datathang();
            }
            else if(comboBox.SelectedItem.ToString().Equals(tatca.ToString()))
            {
                loaddata();
            }
            dgdoanhthu.Items.Refresh();
        }
        void datanam()
        {
            DoanhThu = new DoanhThu
            {
                DonHang = tinhTongTriGiaNamGanNhat(),
                NhapHang = tinhtongnhap(),
                LoiNhuan = tinhTongTriGiaNamGanNhat() - tinhtongnhap()
            };
            doanhthu.Clear();
            doanhthu.Add(DoanhThu);
            
        }
        void datathang()
        {
            DoanhThu = new DoanhThu
            {
                DonHang = tinhTongTriGiaThangGanNhat(),
                NhapHang = tinhtongnhapthang(),
                LoiNhuan = tinhTongTriGiaThangGanNhat() - tinhtongnhapthang()
            };
            doanhthu.Clear();
            doanhthu.Add(DoanhThu);
        }
        double tinhTongTriGiaNamGanNhat()
        {
            int? namGanNhat = donhanglist
                .Where(p => p.NgayHD.HasValue) 
                .Max(p => p.NgayHD.Value.Year); 

            if (namGanNhat.HasValue)
            {
              
                var hoaDonNamGanNhat = donhanglist
                    .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value);

              
                double tongTriGia = hoaDonNamGanNhat.Sum(p => p.Trigia ?? 0);
                return tongTriGia;
            }
            return 0;
        }
        double tinhtongnhap()
        {
            int? namGanNhat = nhaphanglist
                .Where(p => p.NgayHD.HasValue)
                .Max(p => p.NgayHD.Value.Year);

            if (namGanNhat.HasValue)
            {

                var hoaDonNamGanNhat = nhaphanglist
                    .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value);


                double tongTriGia = hoaDonNamGanNhat.Sum(p => p.Trigia ?? 0);
                return tongTriGia;
            }
            return 0;
        }
        double tinhTongTriGiaThangGanNhat()
        {
            int? namGanNhat = donhanglist
                .Where(p => p.NgayHD.HasValue)
                .Max(p => p.NgayHD.Value.Year);

            if (namGanNhat.HasValue)
            {
                int? thangGanNhat = donhanglist
                    .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value)
                    .Max(p => p.NgayHD.Value.Month);

                if (thangGanNhat.HasValue)
                {
                    var hoaDonThangGanNhat = donhanglist
                        .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value && p.NgayHD.Value.Month == thangGanNhat.Value);

                    double tongTriGia = hoaDonThangGanNhat.Sum(p => p.Trigia ?? 0);
                    return tongTriGia;
                }
            }
            return 0;
        }
        double tinhtongnhapthang()
        {
            int? namGanNhat = nhaphanglist
                .Where(p => p.NgayHD.HasValue)
                .Max(p => p.NgayHD.Value.Year);

            if (namGanNhat.HasValue)
            {
                int? thangGanNhat = nhaphanglist
                    .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value)
                    .Max(p => p.NgayHD.Value.Month);

                if (thangGanNhat.HasValue)
                {
                    var hoaDonThangGanNhat = nhaphanglist
                        .Where(p => p.NgayHD.HasValue && p.NgayHD.Value.Year == namGanNhat.Value && p.NgayHD.Value.Month == thangGanNhat.Value);

                    double tongTriGia = hoaDonThangGanNhat.Sum(p => p.Trigia ?? 0);
                    return tongTriGia;
                }
            }
            return 0;
        }
    }
}
