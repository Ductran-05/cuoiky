using doanwpf.MODEL;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Window
    {
        public ProductsControl ProductsControl { get; set; }
        public CHATLIEU chatlieumoi { get; set; }
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chatlieumoi = new CHATLIEU
                {
                    MaCL = AutoGenerateMaCL(),
                    Tenchatlieu = txtchatlieu.Text
                };

                try
                {
                    if (string.IsNullOrWhiteSpace(txtchatlieu.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên chất liệu.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    dataprovider.Ins.DB.CHATLIEUx.Add(chatlieumoi);
                    dataprovider.Ins.DB.SaveChanges();
                    MessageBox.Show("Chất liệu đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ProductsControl.chatlieulist.Add(chatlieumoi);
                ProductsControl.dgmateial.ItemsSource = ProductsControl.chatlieulist;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private string AutoGenerateMaCL()
        {
            var lastmaterial = dataprovider.Ins.DB.CHATLIEUx.OrderByDescending(sp => sp.MaCL).FirstOrDefault();
            if (lastmaterial != null && int.TryParse(lastmaterial.MaCL.Replace("CL", ""), out int lastNumber))
            {
                return $"CL{lastNumber + 1:D3}";
            }
            else
            {
                return "CL001";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
