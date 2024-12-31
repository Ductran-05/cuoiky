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
        public List<CTHOADON> listcthd = new List<CTHOADON>();
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
            dgproductininvoice.ItemsSource = listcthd;
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
                double trigiahoadon = 0;

                foreach (var item in listcthd)
                {
                    trigiahoadon = trigiahoadon + item.Thanhtien ?? 0 - item.Giamgia ?? 0;
                }
                nhaphangmoi = new NHAPHANG
                {
                    MaHD = listcthd[0].MaHD.Trim(),
                    MaNV = manvcbb.Text.Trim(),
                    NgayHD = date.SelectedDate,
                    MaNCC = mancccbb.Text.Trim(),
                    Trigia = trigiahoadon
                };


                //try
                //{
                //    foreach (var item in listcthd)
                //    {
                //        dataprovider.Ins.DB.CTHOADONs.Add(item);
                //    }
                //    dataprovider.Ins.DB.NHAPHANGs.Add(nhaphangmoi);
                //    dataprovider.Ins.DB.SaveChanges();
                //    MessageBox.Show("Đơn nhập hàng đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
                //catch (Exception ex)
                //{
                //    // Hiển thị thông báo lỗi chi tiết
                //    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                //}

                if (nhaphangmoi != null)
                {
                    WarehouseControl.nhaphanglist.Add(nhaphangmoi);
                }
                WarehouseControl.dgimportinvoice.ItemsSource = listcthd;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
