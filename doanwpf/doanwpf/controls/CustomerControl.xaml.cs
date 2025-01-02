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

        private void Addcustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.customerControl = this;
            addCustomer.ShowDialog();
            dgcustomer.Items.Refresh();
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            RepairCustomer repairCustomer = new RepairCustomer();
            var selectedCustomer = dgcustomer.SelectedItem as KHACHHANG;
            if(selectedCustomer != null)
            {
                repairCustomer.DataContext = selectedCustomer;
            }
            repairCustomer.CustomerControl = this;
            repairCustomer.ShowDialog();
            dgcustomer.Items.Refresh();
        }
        void loadkhachhangdata()
        {
            khachhanglist = new ObservableCollection<KHACHHANG>(dataprovider.Ins.DB.KHACHHANGs.ToList());
        }

        private void khtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (khachhanglist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(khtxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgcustomer.ItemsSource = khachhanglist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = khachhanglist.Where(p => RemoveDiacritics(p.TenKH.ToLower()).Contains(searchText)).ToList();
                dgcustomer.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
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
            var result = MessageBox.Show("Mọi thứ liên quan tới khách hàng này sẽ bị xóa!", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                KHACHHANG khachhang = dgcustomer.SelectedItem as KHACHHANG;

                var donhanglist = dataprovider.Ins.DB.DONHANGs.Where(p => p.MaKH == khachhang.MaKH).ToList();
                foreach (var donhang in donhanglist)
                {
                    var cthdlist = dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaHD == donhang.MaHD).ToList();
                    foreach (var cthd in cthdlist)
                    {
                        dataprovider.Ins.DB.CTHOADONs.Remove(cthd);
                    }
                    dataprovider.Ins.DB.DONHANGs.Remove(donhang);
                }

                dataprovider.Ins.DB.KHACHHANGs.Remove(khachhang);

                dataprovider.Ins.DB.SaveChanges();
                dgcustomer.ItemsSource=dataprovider.Ins.DB.KHACHHANGs.ToList();
                dgcustomer.Items.Refresh();
            }
        }
    }
}
