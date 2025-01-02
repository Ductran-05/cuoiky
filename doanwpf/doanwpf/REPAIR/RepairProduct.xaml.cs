using doanwpf.MODEL;
using Microsoft.Win32;
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

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for RepairProduct.xaml
    /// </summary>
    public partial class RepairProduct : Window
    {
        public SANPHAM SANPHAM { get; set; }
        public ProductsControl ProductsControl { get; set; }
        public RepairProduct()
        {
            InitializeComponent();
            loadsanphamdata();
            DataContext = this;
        }
        private void OnSelectImageClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Định dạng tệp hỗ trợ
            if (openFileDialog.ShowDialog() == true)
            {
                // Tải ảnh và hiển thị trong Image control
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath));
                SelectedImage.Source = bitmap;
            }

        }
        void loadsanphamdata()
        {
            
            var maloaiList = new ObservableCollection<string>(
                 dataprovider.Ins.DB.SANPHAMs.Select(sp => sp.MaLoai).Distinct().ToList());
            maloaicbb.ItemsSource = maloaiList;
            var mancclist = new ObservableCollection<string>(
               dataprovider.Ins.DB.SANPHAMs.Select(sp => sp.MaNCC).Distinct().ToList());
            mancccbb.ItemsSource = mancclist;
            var sizelist = new ObservableCollection<string>(
                dataprovider.Ins.DB.SANPHAMs.Select(sp => sp.Size).Distinct().ToList());
            sizecbb.ItemsSource = sizelist;
            var macllist = new ObservableCollection<string>(
                dataprovider.Ins.DB.SANPHAMs.Select(sp => sp.MaCL).Distinct().ToList());
            maclcbb.ItemsSource = macllist;
        }
        private void repair_click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ProductsControl != null)
                { MessageBox.Show("hello"); }
                else
                { MessageBox.Show("null"); }
                #region
                if (string.IsNullOrWhiteSpace(tensptxt.Text))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(maloaicbb.Text))
                {
                    MessageBox.Show("Mã loại không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(mancccbb.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!double.TryParse(giabantxt.Text, out double giaban) || giaban < 0)
                {
                    MessageBox.Show("Giá bán phải là số dương.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!double.TryParse(giagoctxt.Text, out double giagoc) || giagoc < 0)
                {
                    MessageBox.Show("Giá gốc phải là số dương.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(maclcbb.Text))
                {
                    MessageBox.Show("Mã chất liệu không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (SelectedImage.Source == null)
                {
                    MessageBox.Show("Bạn phải chọn một hình ảnh.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                SANPHAM = ProductsControl.dgproduct.SelectedItem as SANPHAM;
                try
                {
                    capnhat(dataprovider.Ins.DB.SANPHAMs.FirstOrDefault(p => p.MaSP == SANPHAM.MaSP) as SANPHAM);
                    dataprovider.Ins.DB.SaveChanges();

                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ProductsControl.dgproduct.Items.Refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        void capnhat(SANPHAM sp)
        {
            sp.TenSP = tensptxt.Text;
            sp.MaLoai = maloaicbb.Text;
            sp.MaNCC = mancccbb.Text;
            sp.Giaban = double.Parse(giabantxt.Text);
            sp.Giagoc = double.Parse(giagoctxt.Text);
            sp.MaCL = maclcbb.Text;
            sp.FilePath = SelectedImage.Source.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
