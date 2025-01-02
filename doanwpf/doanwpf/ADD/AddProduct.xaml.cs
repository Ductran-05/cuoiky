using doanwpf.MODEL;
using Microsoft.Win32;
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
using System.IO;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private string filePath {  get; set; }
        public SANPHAM sanphammoi {  get; set; }
        public ProductsControl ProductsControl { get; set; }
        public AddProduct()
        {
            InitializeComponent();
            loadsanphamdata();
            
            DataContext = this;
        }
        private void OnSelectImageClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Định dạng tệp hỗ trợ

                if (openFileDialog.ShowDialog() == true)
                {
                    // Tải ảnh và hiển thị trong Image control
                    filePath = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(filePath));
                    SelectedImage.Source = bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi chọn hình ảnh: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        void loadsanphamdata()
        {
            var maloaiList = new ObservableCollection<string>(
                 dataprovider.Ins.DB.LOAISANPHAMs.Select(sp => sp.Maloai).Distinct().ToList());
            maloaicbb.ItemsSource = maloaiList;
            var mancclist = new ObservableCollection<string>(
               dataprovider.Ins.DB.NHACUNGCAPs.Select(sp => sp.MaNCC).Distinct().ToList());
            mancccbb.ItemsSource = mancclist;
            var sizelist = new ObservableCollection<string>(
                dataprovider.Ins.DB.SANPHAMs.Select(sp => sp.Size).Distinct().ToList());
            sizecbb.ItemsSource = sizelist;
            var macllist = new ObservableCollection<string>(
                dataprovider.Ins.DB.CHATLIEUx.Select(sp => sp.MaCL).Distinct().ToList());
            maclcbb.ItemsSource = macllist;
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Please select an image for the product.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txttensp.Text) ||
                    string.IsNullOrWhiteSpace(txtgiaban.Text) ||
                    string.IsNullOrWhiteSpace(txtgiagoc.Text))
                {
                    MessageBox.Show("Please fill all required fields (Product Name, Sale Price, Cost Price).", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                #endregion
                sanphammoi = new SANPHAM
                {
                    MaSP = AutoGenerateMaSP(),
                    TenSP = txttensp.Text.Trim(),
                    MaLoai = maloaicbb.Text.Trim(),
                    MaNCC = mancccbb.Text.Trim(),
                    Giaban = double.Parse(txtgiaban.Text),
                    Giagoc = double.Parse(txtgiagoc.Text),
                    Size = sizecbb.Text.Trim(),
                    MaCL = maclcbb.Text.Trim(),
                    Tonkho = 0,
                    FilePath = SelectedImage.Source.ToString()
                };
              

                string filename = Path.GetFileName(sanphammoi.FilePath.Trim());
                string projectDirectory =Directory.GetCurrentDirectory();
                string destinationDirectory = Path.Combine(projectDirectory, "imagesource");
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }
                string destinationpath = Path.Combine(destinationDirectory, filename);
                File.Copy(filePath, destinationpath, true);

                try
                {   
                    dataprovider.Ins.DB.SANPHAMs.Add(sanphammoi);
                    dataprovider.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }


                ProductsControl.sanphamlist.Add(sanphammoi);
                ProductsControl.dgproduct.ItemsSource= ProductsControl.sanphamlist;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private string AutoGenerateMaSP()
        {
            var lastProduct = dataprovider.Ins.DB.SANPHAMs.OrderByDescending(sp => sp.MaSP).FirstOrDefault();
            if (lastProduct != null && int.TryParse(lastProduct.MaSP.Replace("SP", ""), out int lastNumber))
            {
                return $"SP{lastNumber + 1:D3}";
            }
            else
            {
                return "SP001";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
