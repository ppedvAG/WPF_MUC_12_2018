using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UnsereUserControls
{
    public class BoolToBrushConverter : IValueConverter
    {

        public Brush TrueColor { get; set; } = Brushes.Red;
        public Brush FalseColor { get; set; } = Brushes.Green;


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool bvalue)
            {
                return bvalue ? TrueColor : FalseColor;
            }
            return TrueColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
