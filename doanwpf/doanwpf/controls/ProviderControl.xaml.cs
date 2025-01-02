using doanwpf.ADD;
using doanwpf.MODEL;
using doanwpf.REPAIR;
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
    /// Interaction logic for ProviderControl.xaml
    /// </summary>
    public partial class ProviderControl : UserControl
    {
        private ObservableCollection<NHACUNGCAP> _nhacungcaplist;
        public ObservableCollection<NHACUNGCAP> nhacungcaplist { get => _nhacungcaplist; set { _nhacungcaplist = value; } }
        public ProviderControl()
        {
            InitializeComponent();
            loadnhacungcapdata();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           AddProvider addProvider = new AddProvider(); 
           addProvider.ProviderControl = this;
           addProvider.Show();
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            RepairProvider repairProvider = new RepairProvider();
            var selectedprovider = dgprovider.SelectedItem as NHACUNGCAP;
            if(selectedprovider != null)
            {
                repairProvider.DataContext = selectedprovider;
            }
            repairProvider.ProviderControl=this;
            repairProvider.ShowDialog();
        }
        void loadnhacungcapdata()
        {
            nhacungcaplist = new ObservableCollection<NHACUNGCAP>(dataprovider.Ins.DB.NHACUNGCAPs.ToList());
        }

        private void ncctxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nhacungcaplist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(ncctxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgprovider.ItemsSource = nhacungcaplist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = nhacungcaplist.Where(p => RemoveDiacritics(p.TenNCC.ToLower()).Contains(searchText)).ToList();
                dgprovider.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
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

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Mọi thứ liên quan tới nhà cung cấp này sẽ bị xóa!", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                NHACUNGCAP ncc = dgprovider.SelectedItem as NHACUNGCAP;

                var nhaphanglist = dataprovider.Ins.DB.NHAPHANGs.Where(p => p.MaNCC == ncc.MaNCC).ToList();
                foreach (var donhang in nhaphanglist)
                {
                    var ctnhaplist = dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaHD == donhang.MaHD).ToList();
                    foreach (var ctnhap in ctnhaplist)
                    {
                        dataprovider.Ins.DB.CTNHAPs.Remove(ctnhap);
                    }
                    dataprovider.Ins.DB.NHAPHANGs.Remove(donhang);
                }

                dataprovider.Ins.DB.NHACUNGCAPs.Remove(ncc);

                dataprovider.Ins.DB.SaveChanges();
                dgprovider.ItemsSource = dataprovider.Ins.DB.NHACUNGCAPs.ToList();
                dgprovider.Items.Refresh();
            }
        }
    }
}
