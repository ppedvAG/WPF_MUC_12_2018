using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ElementBinding
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility DefaultValue { get; set; } = Visibility.Visible;

        //Source -> Target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Sprache berücksichtigen
            //if(culture.Name == "de")
            //{

            //}
            //else if(culture.Name == "en")
            //{

            //}

            if(value is bool boolvalue)
            {
                if(boolvalue)
                {
                    return Visibility.Visible;
                }
                else
                {
                    if(parameter != null && parameter.ToString().ToLower().Trim() == "hidden")
                    {
                        return Visibility.Hidden;
                    }
                    return Visibility.Collapsed;
                }
            }
            return DefaultValue;
        }

        //Target -> Source (wird selten benutzt)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Visibility visibility)
            {
                if(visibility == Visibility.Collapsed || visibility == Visibility.Hidden)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
