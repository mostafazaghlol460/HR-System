
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.validation
{
    public class custom_reportAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public custom_reportAttribute()
        {
            _minDate = new DateTime(2008,1,1);
            _maxDate = DateTime.Now.Date;


        }

        public override bool IsValid(object value)
        {
            DateTime dateValue = (DateTime)value;
            return dateValue >= _minDate && dateValue <= _maxDate;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"{name} you must the employee date is after than date of conference";
        }
    }

}