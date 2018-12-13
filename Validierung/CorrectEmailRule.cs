using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validierung
{
    public class CorrectEmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString().Contains("@"))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Es muss ein @ enthalten sein!");
        }
    }
}
