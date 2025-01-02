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
using System.Windows.Shapes;

namespace doanwpf
{
    
    public partial class AddCustomer : Window
    {
        public CustomerControl customerControl {  get; set; }
        public KHACHHANG khachhangmoi { get; set; }
        private ObservableCollection<KHACHHANG> _khachhanglist;
        public ObservableCollection<KHACHHANG> khachhanglist { get => _khachhanglist; set { _khachhanglist = value; } }
        public AddCustomer()
        {
            InitializeComponent();

            DataContext = this;
        }
        void loadkhachhangdata()
        {
            khachhanglist = new ObservableCollection<KHACHHANG>(dataprovider.Ins.DB.KHACHHANGs.ToList());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            #region 
            if (string.IsNullOrWhiteSpace(CustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Address.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(PhoneNum.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Date.SelectedDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            #endregion
            try
            {
                khachhangmoi = new KHACHHANG
                {
                    MaKH = AutoGenerateMaKH(),
                    TenKH = CustomerName.Text,
                    Gioitinh = rbNam.IsChecked == true ? "Nam" : "Nữ",
                    Diachi = Address.Text,
                    SDT = PhoneNum.Text,
                    Ngaysinh = Date.SelectedDate
                };

                dataprovider.Ins.DB.KHACHHANGs.Add(khachhangmoi);
                dataprovider.Ins.DB.SaveChanges();

                customerControl.khachhanglist.Add(khachhangmoi);
                customerControl.dgcustomer.ItemsSource = customerControl.khachhanglist;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private string AutoGenerateMaKH()
        {
            var lastCustomer = dataprovider.Ins.DB.KHACHHANGs.OrderByDescending(sp => sp.MaKH).FirstOrDefault();
            if (lastCustomer != null && int.TryParse(lastCustomer.MaKH.Replace("KH", ""), out int lastNumber))
            {
                return $"KH{lastNumber + 1:D3}";
            }
            else
            {
                return "KH001";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
