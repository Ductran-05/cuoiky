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
    /// Interaction logic for EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl
    {
        private ObservableCollection<NHANVIEN> _nhanvienlist;
        public ObservableCollection<NHANVIEN> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; } }
        public EmployeesControl()
        {
            InitializeComponent();
            loadnhanviendata();
            DataContext =this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.EmployeesControl = this;
            addEmployee.ShowDialog();
            dgemployee.Items.Refresh();
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            RepairEmployee repairEmployee = new RepairEmployee();
            var selectedemployee = dgemployee.SelectedItem as NHANVIEN;
            if (selectedemployee != null)
            {
                repairEmployee.DataContext = selectedemployee;
            }
            repairEmployee.EmployeesControl = this;
            repairEmployee.ShowDialog();
        }
        void loadnhanviendata()
        {
            nhanvienlist = new ObservableCollection<NHANVIEN>(dataprovider.Ins.DB.NHANVIENs.ToList());
        }

        private void nvtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nhanvienlist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(nvtxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgemployee.ItemsSource = nhanvienlist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = nhanvienlist.Where(p => RemoveDiacritics(p.TenNV.ToLower()).Contains(searchText)).ToList();
                dgemployee.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
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
            var result = MessageBox.Show("Mọi thứ liên quan tới nhân viên này sẽ bị xóa!", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                NHANVIEN nhanvien = dgemployee.SelectedItem as NHANVIEN;

                var donhanglist = dataprovider.Ins.DB.DONHANGs.Where(p => p.MaNV == nhanvien.MaNV).ToList();
                foreach (var donhang in donhanglist)
                {
                    var cthdlist = dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaHD == donhang.MaHD).ToList();
                    foreach (var cthd in cthdlist)
                    {
                        dataprovider.Ins.DB.CTHOADONs.Remove(cthd);
                    }
                    dataprovider.Ins.DB.DONHANGs.Remove(donhang);
                }

                var nhaphanglist = dataprovider.Ins.DB.NHAPHANGs.Where(p => p.MaNV == nhanvien.MaNV).ToList();
                foreach (var donhang in nhaphanglist)
                {
                    var ctnhaplist = dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaHD == donhang.MaHD).ToList();
                    foreach (var ctnhap in ctnhaplist)
                    {
                        dataprovider.Ins.DB.CTNHAPs.Remove(ctnhap);
                    }
                    dataprovider.Ins.DB.NHAPHANGs.Remove(donhang);
                }

                dataprovider.Ins.DB.NHANVIENs.Remove(nhanvien);

                dataprovider.Ins.DB.SaveChanges();
                dgemployee.ItemsSource = dataprovider.Ins.DB.NHANVIENs.ToList();
                dgemployee.Items.Refresh();
            }
        }
    }
}
