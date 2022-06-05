using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace pilot.SCADA.Converter
{
    class ListArray2StrListConverter : IValueConverter
    {
        int useNum = 5;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<List<ushort>>)
            {
                var raw = (List<List<ushort>>)value;
                List<string> res = new List<string>();

                int row = raw.Count;
                int col = raw[0].Count;

                if (row <= 0 || col <= useNum)
                    return null;

                for (int i = 0; i < row; i++)
                {
                    string tem = "";
                    for (int j = col-useNum; j < col; j++)
                    {
                        tem += raw[i][j].ToString() + "  ";
                    }
                    res.Add(tem);
                }

                return res;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
