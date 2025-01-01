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
    /// Interaction logic for AddProvider.xaml
    /// </summary>
    public partial class AddProvider : Window
    {
         public ProviderControl ProviderControl {  get; set; }
        public NHACUNGCAP nhacungcapmoi {  get; set; }
        public AddProvider()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nhacungcapmoi = new NHACUNGCAP
                {
                    MaNCC = AutoGenerateMaNCC(),
                    TenNCC = txttenncc.Text,
                    SDT = phonenumber.Text,
                };

                try
                {
                    dataprovider.Ins.DB.NHACUNGCAPs.Add(nhacungcapmoi);
                    dataprovider.Ins.DB.SaveChanges();
                    MessageBox.Show("Nhà cung cấp đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ProviderControl.nhacungcaplist.Add(nhacungcapmoi);
                ProviderControl.dgprovider.ItemsSource = ProviderControl.nhacungcaplist;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private string AutoGenerateMaNCC()
        {
            var lastprovider = dataprovider.Ins.DB.NHACUNGCAPs.OrderByDescending(sp => sp.MaNCC).FirstOrDefault();
            if (lastprovider != null && int.TryParse(lastprovider.MaNCC.Replace("NCC", ""), out int lastNumber))
            {
                return $"NCC{lastNumber + 1:D3}";
            }
            else
            {
                return "NCC001";
            }
        }
    }
}
