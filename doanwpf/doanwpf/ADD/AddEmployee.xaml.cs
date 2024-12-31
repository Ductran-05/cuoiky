using doanwpf.MODEL;
using System;
using System.Collections.Generic;
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

namespace doanwpf.ADD
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public EmployeesControl EmployeesControl {  get; set; }
        public NHANVIEN nhanvienmoi { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            #region
            // Kiểm tra các trường không được để trống hoặc null
            if (string.IsNullOrWhiteSpace(emplname.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (rbNam.IsChecked == false && rbNu.IsChecked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(phonenum.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!date.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            #endregion
            try
            {
                nhanvienmoi = new NHANVIEN
                {
                    MaNV = AutoGenerateMaNV(),
                    TenNV = emplname.Text,
                    Gioitinh = rbNam.IsChecked == true ? "Nam" : "Nữ",
                    Diachi = address.Text,
                    Dienthoai = phonenum.Text,
                    Ngaysinh = date.SelectedDate
                };

                try
                {
                    dataprovider.Ins.DB.NHANVIENs.Add(nhanvienmoi);
                    dataprovider.Ins.DB.SaveChanges();
                    MessageBox.Show("Nhân viên đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                EmployeesControl.nhanvienlist.Add(nhanvienmoi);
                EmployeesControl.dgemployee.ItemsSource= EmployeesControl.nhanvienlist;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
          
        }
        private string AutoGenerateMaNV()
        {
            var lastEmloyee = dataprovider.Ins.DB.NHANVIENs.OrderByDescending(sp => sp.MaNV).FirstOrDefault();
            if (lastEmloyee != null && int.TryParse(lastEmloyee.MaNV.Replace("NV", ""), out int lastNumber))
            {
                return $"NV{lastNumber + 1:D3}";
            }
            else
            {
                return "NV001";
            }
        }
    }
}
