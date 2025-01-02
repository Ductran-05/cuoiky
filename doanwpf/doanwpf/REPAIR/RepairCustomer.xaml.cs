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

namespace doanwpf.REPAIR
{
    /// <summary>
    /// Interaction logic for RepairCustomer.xaml
    /// </summary>
    public partial class RepairCustomer : Window
    {
        public KHACHHANG KHACHHANG { get; set; }
        public CustomerControl CustomerControl { get; set; }
        public RepairCustomer()
        {
            InitializeComponent();

        }

        private void btnrepair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region
                if (string.IsNullOrWhiteSpace(CustomerName.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (Date.SelectedDate == null || Date.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn ngày nhỏ hơn hoặc bằng ngày hiện tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Address.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(PhoneNum.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!IsValidPhoneNumber(PhoneNum.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                KHACHHANG = CustomerControl.dgcustomer.SelectedItem as KHACHHANG;
                try
                {
                    capnhat(dataprovider.Ins.DB.KHACHHANGs.FirstOrDefault(p => p.MaKH == KHACHHANG.MaKH) as KHACHHANG);
                    dataprovider.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                CustomerControl.dgcustomer.Items.Refresh();
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

        void capnhat(KHACHHANG kh)
        {
            kh.TenKH = CustomerName.Text;
            kh.Gioitinh = rbNam.IsChecked == true ? "Nam" : "Nữ";
            kh.Ngaysinh = Date.SelectedDate;
            kh.Diachi = Address.Text;
            kh.SDT = PhoneNum.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
