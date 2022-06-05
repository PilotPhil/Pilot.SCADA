using System;
using System.Globalization;
using System.Windows.Data;

namespace pilot.SCADA.Converter
{
    /// <summary>
    /// 用于创建modbus master时 选择Rtu 还是 ASCii 的bool 互斥 converter
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolean ? !boolean : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolean ? !boolean : value;
        }
    }
}
