using doanwpf.ADD;
using doanwpf.controls;
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
    /// Interaction logic for InvoiceControl.xaml
    /// </summary>
    public partial class InvoiceControl : UserControl
    {
        private ObservableCollection<DONHANG> _donhanglist;
        public ObservableCollection<DONHANG> donhanglist { get => _donhanglist; set { _donhanglist = value; } }
        

        public InvoiceControl()
        {
            InitializeComponent();
            loaddonhangdata();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddInvoice addInvoice = new AddInvoice();
            addInvoice.InvoiceControl = this;
            addInvoice.ShowDialog();

        }
        private void opendetail_Click(object sender, RoutedEventArgs e)
        {
            CTHDwindow cTHDwindow = new CTHDwindow();
            //var selectedinvoice = dginvoice.SelectedItem as DONHANG;
            cTHDwindow.InvoiceControl = this; // Gán form cha cho form con
            //if (selectedinvoice != null)
            //{
            //    cthdlist = new ObservableCollection<CTHOADON>(dataprovider.Ins.DB.CTHOADONs.ToList());
            //    cTHDwindow.DataContext = cthdlist;
            //}
            cTHDwindow.ShowDialog();

        }
        void loaddonhangdata()
        {
            donhanglist = new ObservableCollection<DONHANG>(dataprovider.Ins.DB.DONHANGs.ToList());

        }

        private void hdtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (donhanglist == null)
            {
                return; // Tránh lỗi nếu danh sách là null
            }

            string searchText = RemoveDiacritics(hdtxt.Text.ToLower());

            if (string.IsNullOrEmpty(searchText))
            {
                dginvoice.ItemsSource = donhanglist;  // Hiển thị toàn bộ danh sách nếu không có văn bản tìm kiếm
            }
            else
            {
                // Lọc sản phẩm theo tên
                var filteredProducts = donhanglist.Where(p => RemoveDiacritics(p.NgayHD.Value.ToString().ToLower()).Contains(searchText)).ToList();
                dginvoice.ItemsSource = filteredProducts;  // Hiển thị danh sách đã lọc
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
