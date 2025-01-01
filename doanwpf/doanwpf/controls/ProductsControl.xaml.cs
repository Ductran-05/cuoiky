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


    }
}
