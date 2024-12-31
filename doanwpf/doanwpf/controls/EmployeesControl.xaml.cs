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
    /// Interaction logic for EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl
    {
        private ObservableCollection<NHANVIEN> _nhanvienlist;
        public ObservableCollection<NHANVIEN> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; } }
        public EmployeesControl()
        {
            InitializeComponent();
            loadnhanviendata();
            DataContext =this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.EmployeesControl = this;
            addEmployee.ShowDialog();
            dgemployee.Items.Refresh();
        }
        void loadnhanviendata()
        {
            nhanvienlist = new ObservableCollection<NHANVIEN>(dataprovider.Ins.DB.NHANVIENs.ToList());
        }
    }
}
