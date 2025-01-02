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

namespace doanwpf.ADD
{
    /// <summary>
    /// Interaction logic for AddPrdInInvoice.xaml
    /// </summary>
    public partial class AddPrdInInvoice : Window
    {
        public AddInvoice AddInvoice { get; set; }
        public AddImportInvoice AddImportInvoice { get; set; }
        public AddPrdInInvoice()
        {
            InitializeComponent();
            loadsanphamdata();

        }
        void loadsanphamdata()
        {
            var masplist = new ObservableCollection<string>(
                 dataprovider.Ins.DB.SANPHAMs.Select(nv => nv.MaSP).Distinct().ToList());
            maspcbb.Items.Clear();
            maspcbb.ItemsSource = masplist;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                #region
                // Kiểm tra đầu vào
                if (maspcbb.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (soluong.Value <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(dongiatxt.Text, out double dongia) || dongia <= 0)
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(giamgiatxt.Text, out double giamgia) || giamgia < 0)
                {
                    MessageBox.Show("Giảm giá không hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                // Tính thành tiền
                double thanhtien = dongia * soluong.Value - giamgia;

                // Tạo hóa đơn bán
                if (AddInvoice != null)
                {
                    var cTHOADON = new CTHOADON
                    {
                        MaHD = AutoGenerateMaHD(),
                        MaSP = maspcbb.Text,
                        Soluong = soluong.Value,
                        Dongia = dongia,
                        Giamgia = giamgia,
                        Thanhtien = thanhtien
                    };
                    AddInvoice.listcthd.Add(cTHOADON);
                }

                // Tạo hóa đơn nhập
                if (AddImportInvoice != null)
                {
                    var cTNHAP = new CTNHAP
                    {
                        MaHD = AutoGenerateMaNH(),
                        MaSP = maspcbb.Text,
                        Soluong = soluong.Value,
                        Dongia = dongia,
                        Giamgia = giamgia,
                        Thanhtien = thanhtien
                    };
                    AddImportInvoice.listctnhap.Add(cTNHAP);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string AutoGenerateMaNH()
        {
            var lastInvoice = dataprovider.Ins.DB.NHAPHANGs.OrderByDescending(sp => sp.MaHD).FirstOrDefault();
            if (lastInvoice != null && int.TryParse(lastInvoice.MaHD.Replace("NH", ""), out int lastNumber))
            {
                return $"NH{lastNumber + 1:D3}";
            }
            else
            {
                return "NH001";
            }
        }
        private string AutoGenerateMaHD()
        {
            var lastInvoice = dataprovider.Ins.DB.DONHANGs.OrderByDescending(sp => sp.MaHD).FirstOrDefault();
            if (lastInvoice != null && int.TryParse(lastInvoice.MaHD.Replace("HD", ""), out int lastNumber))
            {
                return $"HD{lastNumber + 1:D3}";
            }
            else
            {
                return "HD001";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
