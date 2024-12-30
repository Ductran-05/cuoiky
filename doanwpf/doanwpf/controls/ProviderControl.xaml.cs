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
           addProvider.Show();
        }
        void loadnhacungcapdata()
        {
            nhacungcaplist = new ObservableCollection<NHACUNGCAP>(dataprovider.Ins.DB.NHACUNGCAPs.ToList());
        }
    }
}
