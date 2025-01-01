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
    /// Interaction logic for ProviderControl.xaml
    /// </summary>
    public partial class ProviderControl : UserControl
    {
        private ObservableCollection<NHACUNGCAP> _nhacungcaplist;
        public ObservableCollection<NHACUNGCAP> nhacungcaplist { get => _nhacungcaplist; set { _nhacungcaplist = value; } }
        public ProviderControl()
        {
            InitializeComponent();
            loadnhacungcapdata();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           AddProvider addProvider = new AddProvider(); 
           addProvider.ProviderControl = this;
           addProvider.Show();
        }
        void loadnhacungcapdata()
        {
            nhacungcaplist = new ObservableCollection<NHACUNGCAP>(dataprovider.Ins.DB.NHACUNGCAPs.ToList());
        }

        private void ncctxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nhacungcaplist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(ncctxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dgprovider.ItemsSource = nhacungcaplist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = nhacungcaplist.Where(p => RemoveDiacritics(p.TenNCC.ToLower()).Contains(searchText)).ToList();
                dgprovider.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
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
