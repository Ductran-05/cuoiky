using doanwpf.ADD;
using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        private ObservableCollection<SANPHAM> _sanphamlist;
        public ObservableCollection<SANPHAM> sanphamlist { get => _sanphamlist; set { _sanphamlist = value; } }
        private ObservableCollection<LOAISANPHAM> _loaisanphamlist;
        public ObservableCollection<LOAISANPHAM> loaisanphamlist { get => _loaisanphamlist;set { _loaisanphamlist= value; } }
        private ObservableCollection<CHATLIEU> _chatlieulist;
        public ObservableCollection<CHATLIEU> chatlieulist { get => _chatlieulist; set { _chatlieulist = value; } }

        public ProductsControl()
        {
            InitializeComponent();
            loadsanphamdata();
            loadloaisanphamdata();
            loadchatlieudata();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();          
            addProduct.ProductsControl=this;
            addProduct.ShowDialog();
            dgproduct.Items.Refresh();
        }
        private void Addmaterial_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            addMaterial.ProductsControl=this;
            addMaterial.ShowDialog();
            dgmateial.Items.Refresh();
        }
        private void Addcatalog_Click(object sender, RoutedEventArgs e)
        {
            AddCatalog addCatalog = new AddCatalog();
            addCatalog.ProductsControl = this;
            addCatalog.ShowDialog();
            dgcatalog.Items.Refresh();
        }
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            RepairProduct repairProduct = new RepairProduct();
            var selectedProduct = dgproduct.SelectedItem as SANPHAM;
            if (selectedProduct != null)
            {
                repairProduct.DataContext = selectedProduct;
            }
            repairProduct.ProductsControl = this;
            repairProduct.ShowDialog();
        }
        void loadsanphamdata()
        {
            sanphamlist = new ObservableCollection<SANPHAM>(dataprovider.Ins.DB.SANPHAMs.ToList());
        }
        void loadloaisanphamdata()
        {
            loaisanphamlist = new ObservableCollection<LOAISANPHAM>(dataprovider.Ins.DB.LOAISANPHAMs.ToList());
        }
        void loadchatlieudata()
        {
            chatlieulist = new ObservableCollection<CHATLIEU>(dataprovider.Ins.DB.CHATLIEUx.ToList());
        }


        private void sptxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sanphamlist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }
            
            string searchText = RemoveDiacritics(sptxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgproduct.ItemsSource = sanphamlist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = sanphamlist.Where(p => RemoveDiacritics(p.TenSP.ToLower()).Contains(searchText)).ToList();
                dgproduct.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
            }
        }
        // Phương thức để loại bỏ dấu
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                // Thêm ký tự không có dấu vào string builder nếu không phải là ký tự dấu
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            var result= MessageBox.Show("Mọi thứ liên quan tới sản phẩm này sẽ bị xóa!","Cảnh báo",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                SANPHAM sanpham = dgproduct.SelectedItem as SANPHAM;

                var cthdlist = dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                foreach (var cthd in cthdlist)
                {
                    dataprovider.Ins.DB.CTHOADONs.Remove(cthd);
                }

                var ctnhaplist = dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                foreach (var ctnhap in ctnhaplist)
                {
                    dataprovider.Ins.DB.CTNHAPs.Remove(ctnhap);
                }

                dataprovider.Ins.DB.SANPHAMs.Remove(sanpham);

                dataprovider.Ins.DB.SaveChanges();
                dgproduct.ItemsSource = dataprovider.Ins.DB.SANPHAMs.ToList();
                dgproduct.Items.Refresh();
            }
        }

        private void xoadanhmuc_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Mọi thứ liên quan tới loại sản phẩm này sẽ bị xóa!", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                LOAISANPHAM loaisanpham = dgcatalog.SelectedItem as LOAISANPHAM;
                var sanphamlist = dataprovider.Ins.DB.SANPHAMs.Where(p => p.MaLoai == loaisanpham.Maloai);
                foreach( var sanpham in sanphamlist)
                {
                    var cthdlist = dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                    foreach (var cthd in cthdlist)
                    {
                        dataprovider.Ins.DB.CTHOADONs.Remove(cthd);
                    }

                    var ctnhaplist = dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                    foreach (var ctnhap in ctnhaplist)
                    {
                        dataprovider.Ins.DB.CTNHAPs.Remove(ctnhap);
                    }

                    dataprovider.Ins.DB.SANPHAMs.Remove(sanpham);
                }
                if(loaisanpham != null)
                {
                    dataprovider.Ins.DB.LOAISANPHAMs.Remove(loaisanpham);
                }

                dataprovider.Ins.DB.SaveChanges();
                dgcatalog.ItemsSource = dataprovider.Ins.DB.LOAISANPHAMs.ToList();
            }
        }

        private void xoachatlieu_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Mọi thứ liên quan tới chất liệu này sẽ bị xóa!", "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                CHATLIEU chatlieu = dgmateial.SelectedItem as CHATLIEU;
                var sanphamlist = dataprovider.Ins.DB.SANPHAMs.Where(p => p.MaCL == chatlieu.MaCL);
                foreach (var sanpham in sanphamlist)
                {
                    var cthdlist = dataprovider.Ins.DB.CTHOADONs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                    foreach (var cthd in cthdlist)
                    {
                        dataprovider.Ins.DB.CTHOADONs.Remove(cthd);
                    }

                    var ctnhaplist = dataprovider.Ins.DB.CTNHAPs.Where(p => p.MaSP == sanpham.MaSP).ToList();
                    foreach (var ctnhap in ctnhaplist)
                    {
                        dataprovider.Ins.DB.CTNHAPs.Remove(ctnhap);
                    }

                    dataprovider.Ins.DB.SANPHAMs.Remove(sanpham);
                }
                dataprovider.Ins.DB.CHATLIEUx.Remove(chatlieu);

                dataprovider.Ins.DB.SaveChanges();
                dgmateial.ItemsSource = dataprovider.Ins.DB.CHATLIEUx.ToList();
            }
        }
    }
}
