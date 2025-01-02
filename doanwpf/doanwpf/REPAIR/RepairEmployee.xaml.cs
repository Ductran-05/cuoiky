using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace doanwpf.REPAIR
{
    /// <summary>
    /// Interaction logic for RepairEmployee.xaml
    /// </summary>
    public partial class RepairEmployee : Window
    {
        public NHANVIEN NHANVIEN { get; set; }
        public EmployeesControl EmployeesControl {  get; set; }
        public RepairEmployee()
        {
            InitializeComponent();
        }

        private void repair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region
                if (string.IsNullOrWhiteSpace(emplname.Text))
                {
                    MessageBox.Show("Tên nhân viên không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (date.SelectedDate == null || date.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn ngày nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(address.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(phonenum.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!IsValidPhoneNumber(phonenum.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion

                NHANVIEN = EmployeesControl.dgemployee.SelectedItem as NHANVIEN;
                try
                {
                    capnhat(dataprovider.Ins.DB.NHANVIENs.FirstOrDefault(p => p.MaNV == NHANVIEN.MaNV) as NHANVIEN);
                    dataprovider.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                EmployeesControl.dgemployee.Items.Refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra số điện thoại chỉ chứa số và có độ dài từ 9 đến 11 ký tự
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 9 && phoneNumber.Length <= 11;
        }

        void capnhat(NHANVIEN nv)
        {
            nv.TenNV = emplname.Text;
            nv.Gioitinh = rbNam.IsChecked == true ? "Nam" : "Nữ";
            nv.Ngaysinh = date.SelectedDate;
            nv.Diachi = address.Text;
            nv.Dienthoai = phonenum.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
