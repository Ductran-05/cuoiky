using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doanwpf.MODEL
{
    public class DoanhThu
    {
        public decimal NhapHang { get; set; }

        public decimal DonHang { get; set; }
        public decimal LoiNhuan
        {
            get
            {
                return DonHang - NhapHang;
            }
        }
    }

}
