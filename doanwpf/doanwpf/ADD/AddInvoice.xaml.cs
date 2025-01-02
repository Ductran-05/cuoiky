using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for AddInvoice.xaml
    /// </summary>
    public partial class AddInvoice : Window
    {
        public List<CTHOADON> listcthd = new List<CTHOADON>();
        public InvoiceControl InvoiceControl { get; set; }
        public DONHANG donhangmoi { get; set; }
        public AddInvoice()
        {
            InitializeComponent();
            loadthongtinhoadon();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPrdInInvoice addPrdInInvoice = new AddPrdInInvoice();
            addPrdInInvoice.AddInvoice = this;
            addPrdInInvoice.ShowDialog();
            dgproductininvoice.ItemsSource = listcthd;
            dgproductininvoice.Items.Refresh();
        }
        void loadthongtinhoadon()
        {
            
                var manvlist = new ObservableCollection<string>(
                 dataprovider.Ins.DB.NHANVIENs.Select(nv => nv.MaNV).Distinct().ToList());
            manvcbb.Items.Clear();
            manvcbb.ItemsSource = manvlist;
            var makhkist = new ObservableCollection<string>(
               dataprovider.Ins.DB.KHACHHANGs.Select(kh => kh.MaKH).Distinct().ToList());
            makhcbb.Items.Clear();
            makhcbb.ItemsSource = makhkist;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(manvcbb.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(makhcbb.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã khách hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!date.SelectedDate.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn ngày hóa đơn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (listcthd == null || listcthd.Count == 0)
                {
                    MessageBox.Show("Danh sách sản phẩm không được để trống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                double trigiahoadon = 0;

                foreach ( var item in listcthd)
                {
                    trigiahoadon = trigiahoadon + item.Thanhtien??0 - item.Giamgia??0;
                }
                donhangmoi = new DONHANG
                {
                    MaHD = listcthd[0].MaHD,
                    MaNV=manvcbb.Text,
                    NgayHD=date.SelectedDate,
                    MaKH=makhcbb.Text,
                    Trigia= trigiahoadon
                };

                try
                {
                    foreach (var item in listcthd)
                    {
                        dataprovider.Ins.DB.CTHOADONs.Add(item);
                    }
                    dataprovider.Ins.DB.DONHANGs.Add(donhangmoi);
                    dataprovider.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                InvoiceControl.donhanglist.Add(donhangmoi);
                InvoiceControl.dginvoice.ItemsSource=InvoiceControl.donhanglist;
                WarehouseControl warehouseControl = new WarehouseControl();
                warehouseControl.dgwarehouse.Items.Refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
