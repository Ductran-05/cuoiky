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
    /// Interaction logic for RepairProvider.xaml
    /// </summary>
    public partial class RepairProvider : Window
    {
        public NHACUNGCAP NHACUNGCAP { get; set; }
        public ProviderControl ProviderControl { get; set; }
        public RepairProvider()
        {
            InitializeComponent();
        }

        private void repair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region
                if (string.IsNullOrWhiteSpace(txttenncc.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(phonenumber.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!IsValidPhoneNumber(phonenumber.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                #endregion
                NHACUNGCAP = ProviderControl.dgprovider.SelectedItem as NHACUNGCAP;
                try
                {
                    capnhat(dataprovider.Ins.DB.NHACUNGCAPs.FirstOrDefault(p => p.MaNCC == NHACUNGCAP.MaNCC) as NHACUNGCAP);
                    dataprovider.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

        void capnhat(NHACUNGCAP ncc)
        {
            ncc.TenNCC = txttenncc.Text;
            ncc.SDT = phonenumber.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
