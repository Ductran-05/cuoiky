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
using System.Windows.Shapes;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for RepairProduct.xaml
    /// </summary>
    public partial class RepairProduct : Window
    {
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
        private void add_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
