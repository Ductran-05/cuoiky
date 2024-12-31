using doanwpf.ADD;
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
            addInvoice.Show();

        }
        void loaddonhangdata()
        {
            donhanglist = new ObservableCollection<DONHANG>(dataprovider.Ins.DB.DONHANGs.ToList());

        }
    }
}
