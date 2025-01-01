using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for AddCatalog.xaml
    /// </summary>
    public partial class AddCatalog : Window
    {
        public LOAISANPHAM loaisanphammoi {  get; set; }
        public ProductsControl ProductsControl {  get; set; }
        public AddCatalog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loaisanphammoi = new LOAISANPHAM
                {
                    Maloai= AutoGenerateMaLSP(),
                    TenLSP=txtloaisp.Text
                };

                try
                {
                    dataprovider.Ins.DB.LOAISANPHAMs.Add(loaisanphammoi);
                    dataprovider.Ins.DB.SaveChanges();
                    MessageBox.Show("Loại sản phẩm đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ProductsControl.loaisanphamlist.Add(loaisanphammoi);
                ProductsControl.dgcatalog.ItemsSource = ProductsControl.loaisanphamlist;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }
        private string AutoGenerateMaLSP()
        {
            var lastcatalog = dataprovider.Ins.DB.LOAISANPHAMs.OrderByDescending(sp => sp.Maloai).FirstOrDefault();
            if (lastcatalog != null && int.TryParse(lastcatalog.Maloai.Replace("LSP", ""), out int lastNumber))
            {
                return $"LSP{lastNumber + 1:D3}";
            }
            else
            {
                return "LSP001";
            }
        }
    }
}
