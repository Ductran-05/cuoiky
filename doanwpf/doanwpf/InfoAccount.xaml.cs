using doanwpf.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for InfoAccount.xaml
    /// </summary>
    public partial class InfoAccount : Window
    {
        
        private THONGTINTAIKHOAN _selectedAccount;
        public THONGTINTAIKHOAN SelectedAccount
        {
            get => _selectedAccount;
            set { _selectedAccount = value; }
        }
        public GenderConverter genderConverter { get; set; }
        
        public InfoAccount()
        {
            InitializeComponent();
            loadthongtintaikhoandata();
            this.Resources["GenderConverter"] = new GenderConverter();
            DataContext = this;
        }
        void loadthongtintaikhoandata()
        {

            SelectedAccount = dataprovider.Ins.DB.THONGTINTAIKHOANs
            .FirstOrDefault(taikhoan => taikhoan.TenDangNhap == App.username && taikhoan.Matkhau == App.password);
        }
       
    }
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;

            string genderValue = value.ToString().Trim();
            string genderParam = parameter.ToString().Trim();
            // So sánh giá trị của Gioitinh với parameter (Nam hoặc Nữ)
            return (genderParam == genderValue);
            //return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked)
            {
                // Trả về giá trị từ parameter (Nam hoặc Nữ)
                return parameter?.ToString();
            }

            return Binding.DoNothing;
        }
    }

}
