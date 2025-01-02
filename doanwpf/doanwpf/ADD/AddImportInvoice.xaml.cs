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
    /// Interaction logic for AddImportInvoice.xaml
    /// </summary>
    /// 
    public partial class AddImportInvoice : Window
    {
        //public List<CTHOADON> listcthd = new List<CTHOADON>();
        public List<CTNHAP> listctnhap = new List<CTNHAP>();
        public WarehouseControl WarehouseControl {  get; set; }
        public NHAPHANG nhaphangmoi { get; set; }

        public AddImportInvoice()
        {

            InitializeComponent();
            loadthongtinhoadon();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPrdInInvoice addPrdInInvoice = new AddPrdInInvoice();
            addPrdInInvoice.AddImportInvoice = this;
            addPrdInInvoice.ShowDialog();
            dgproductininvoice.ItemsSource = listctnhap;
            dgproductininvoice.Items.Refresh();
        }
        void loadthongtinhoadon()
        {
            var manvlist = new ObservableCollection<string>(
                 dataprovider.Ins.DB.NHANVIENs.Select(nv => nv.MaNV).Distinct().ToList());
            manvcbb.Items.Clear();
            manvcbb.ItemsSource = manvlist;
            var mancclist = new ObservableCollection<string>(
               dataprovider.Ins.DB.NHACUNGCAPs.Select(kh => kh.MaNCC).Distinct().ToList());
            mancccbb.Items.Clear();
            mancccbb.ItemsSource = mancclist;
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

                if (string.IsNullOrWhiteSpace(mancccbb.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã nhà cung cấp.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!date.SelectedDate.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn ngày hóa đơn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (listctnhap == null || listctnhap.Count == 0)
                {
                    MessageBox.Show("Danh sách sản phẩm nhập không được để trống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                double trigiahoadon = 0;

                foreach (var item in listctnhap)
                {
                    trigiahoadon = trigiahoadon + item.Thanhtien ?? 0 - item.Giamgia ?? 0;
                }
                nhaphangmoi = new NHAPHANG
                {
                    MaHD = listctnhap[0].MaHD,
                    MaNV=manvcbb.Text,
                    NgayHD=date.SelectedDate,
                    MaNCC= mancccbb.Text,
                    Trigia = trigiahoadon,
                };


                try
                {
                    foreach (var item in listctnhap)
                    {
                        dataprovider.Ins.DB.CTNHAPs.Add(item);
                    }
                    dataprovider.Ins.DB.NHAPHANGs.Add(nhaphangmoi);
                    dataprovider.Ins.DB.SaveChanges();
                    WarehouseControl.dgwarehouse.Items.Refresh();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }


                WarehouseControl.nhaphanglist.Add(nhaphangmoi);
                WarehouseControl.dgimportinvoice.ItemsSource=WarehouseControl.nhaphanglist;
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
