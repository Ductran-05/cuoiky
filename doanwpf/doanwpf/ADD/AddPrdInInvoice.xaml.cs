using doanwpf.MODEL;
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

namespace doanwpf.ADD
{
    /// <summary>
    /// Interaction logic for AddPrdInInvoice.xaml
    /// </summary>
    public partial class AddPrdInInvoice : Window
    {
        public AddInvoice AddInvoice { get; set; }
        public AddImportInvoice AddImportInvoice { get; set; }
        public AddPrdInInvoice()
        {
            InitializeComponent();
            loadsanphamdata();

        }
        void loadsanphamdata()
        {
            var masplist = new ObservableCollection<string>(
                 dataprovider.Ins.DB.SANPHAMs.Select(nv => nv.MaSP).Distinct().ToList());
            maspcbb.Items.Clear();
            maspcbb.ItemsSource = masplist;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if(AddInvoice != null )
            {
                CTHOADON cTHOADON = new CTHOADON
                {
                    MaHD = AutoGenerateMaHD(),
                    MaSP = maspcbb.Text,
                    Soluong = soluong.Value,
                    Dongia = double.Parse(dongiatxt.Text),
                    Giamgia = double.Parse(giamgiatxt.Text),
                    Thanhtien = double.Parse(dongiatxt.Text) * soluong.Value - double.Parse(giamgiatxt.Text),
                };
                AddInvoice.listcthd.Add(cTHOADON);
            }
            if (AddImportInvoice != null) 
            {
                CTNHAP cTNHAP = new CTNHAP
                {
                    MaHD = AutoGenerateMaNH(),
                    MaSP = maspcbb.Text,
                    Soluong = soluong.Value,
                    Dongia = double.Parse(dongiatxt.Text),
                    Giamgia = double.Parse(giamgiatxt.Text),
                    Thanhtien = double.Parse(dongiatxt.Text) * soluong.Value - double.Parse(giamgiatxt.Text),
                };
                AddImportInvoice.listctnhap.Add(cTNHAP); 
            }
            this.Close();
        }
        private string AutoGenerateMaNH()
        {
            var lastInvoice = dataprovider.Ins.DB.NHAPHANGs.OrderByDescending(sp => sp.MaHD).FirstOrDefault();
            if (lastInvoice != null && int.TryParse(lastInvoice.MaHD.Replace("NH", ""), out int lastNumber))
            {
                return $"NH{lastNumber + 1:D3}";
            }
            else
            {
                return "NH001";
            }
        }
        private string AutoGenerateMaHD()
        {
            var lastInvoice = dataprovider.Ins.DB.DONHANGs.OrderByDescending(sp => sp.MaHD).FirstOrDefault();
            if (lastInvoice != null && int.TryParse(lastInvoice.MaHD.Replace("HD", ""), out int lastNumber))
            {
                return $"HD{lastNumber + 1:D3}";
            }
            else
            {
                return "HD001";
            }
        }
    }
}
