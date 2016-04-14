using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEntities.Common
{
    public class DateRangeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime dt = (DateTime)value;
                if (dt >= DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Make sure your date is greater than today's date");
            }

        }
    
}
