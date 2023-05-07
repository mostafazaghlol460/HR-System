using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.validation
{
    public class customDateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public customDateAttribute()
        {
            _minDate = new DateTime(1950, 1, 1);
            _maxDate = new DateTime(2003, 1, 1);

            
        }

        public override bool IsValid(object value)
        {
            DateTime dateValue = (DateTime)value;
            return dateValue >= _minDate && dateValue <= _maxDate;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"{name} you must the employee age is more than 20 year";
        }
    }
    
}