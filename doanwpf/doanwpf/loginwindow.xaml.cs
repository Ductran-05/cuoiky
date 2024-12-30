using doanwpf.MODEL;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace doanwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login())
            {
                this.Hide();
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
            }
        }
        private bool Login()
        {
             App.username = UsernameTextBox.Text;
             App.password = FloatingPasswordBox.Password;
            var acc=dataprovider.Ins.DB.THONGTINTAIKHOANs.Where(p => p.TenDangNhap== App.username && p.Matkhau==App.password).Count();
            if(acc>0)

                return true;
            else return false;
        }
    }
}
