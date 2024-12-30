using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace doanwpf
{

    //public class GenderConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        // Kiểm tra value và parameter không phải null và là kiểu string
    //        if (value is string genderValue && parameter is string targetGender)
    //        {
    //            // Kiểm tra giá trị của genderValue và targetGender
    //            return string.Equals(genderValue, targetGender, StringComparison.OrdinalIgnoreCase);
    //        }

    //        // Nếu không khớp kiểu hoặc không phải string, trả về false
    //        return false;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        // Kiểm tra giá trị bool (IsChecked của RadioButton)
    //        if (value is bool genderBool)
    //        {
    //            // Trả về "Nam" nếu true, "Nữ" nếu false
    //            return genderBool ? "Nam" : "Nữ";
    //        }

    //        // Nếu giá trị không phải bool, ném ngoại lệ
    //        throw new ArgumentException("Giá trị không hợp lệ hoặc không phải bool.");
    //    }
    //}
}
