using doanwpf.ADD;
using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        private ObservableCollection<CTHOADON> _cthdlist;
        public ObservableCollection<CTHOADON> cthdlist { get => _cthdlist; set { _cthdlist = value; } }
        private ObservableCollection<CTNHAP> _ctnhaplist;
        public ObservableCollection<CTNHAP> ctnhaplist { get => _ctnhaplist; set { _ctnhaplist = value; } }
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
            addImportInvoice.WarehouseControl = this;
            addImportInvoice.ShowDialog();
        }
        void loadkhosanphamdata()
        {
            khosanphamlist= new ObservableCollection<SANPHAM>(dataprovider.Ins.DB.SANPHAMs.ToList());
            cthdlist = new ObservableCollection<CTHOADON>(dataprovider.Ins.DB.CTHOADONs.ToList());
            ctnhaplist = new ObservableCollection<CTNHAP>(dataprovider.Ins.DB.CTNHAPs.ToList());
            foreach (var item in khosanphamlist)
            {
                item.Tonkho = GetTonkho(item);
            }

        }
        int GetTonkho(SANPHAM item)
        {

            var soluongnhap = this.ctnhaplist.Where(ct=>ct.MaSP==item.MaSP).Sum(ct => ct.Soluong)??0;
            var soluongxuat = this.cthdlist.Where(ct=>ct.MaSP==item.MaSP).Sum(ct => ct.Soluong)??0;
            return soluongnhap-soluongxuat;
        }
        void loadnhaphangdata()
        {
            nhaphanglist = new ObservableCollection<NHAPHANG>(dataprovider.Ins.DB.NHAPHANGs.ToList());
        }

        private void nhtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nhaphanglist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(nhtxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgimportinvoice.ItemsSource = nhaphanglist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = nhaphanglist.Where(p => RemoveDiacritics(p.NgayHD.Value.ToString().ToLower()).Contains(searchText)).ToList();
                dgimportinvoice.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
            }
        }
        // Phương thức để loại bỏ dấu
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                // Thêm ký tự không có dấu vào string builder nếu không phải là ký tự dấu
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void sptxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ( khosanphamlist== null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(sptxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgwarehouse.ItemsSource = khosanphamlist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = khosanphamlist.Where(p => RemoveDiacritics(p.TenSP.ToLower()).Contains(searchText)).ToList();
                dgwarehouse.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
            }
        }
    }
}
