namespace WebApplication1.Models
{
    using WebApplication1.validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class report_employee
    {
        [Key]
        public int id_report { get; set; }
        [custom_report]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]

        public DateTime date_of_today { get; set; }

        public bool? attend_days { get; set; }

        public bool? absent_days { get; set; }
        [Required]

        public TimeSpan time_attendance { get; set; }
        [Required]

        public TimeSpan time_leave { get; set; }

        public double extra { get; set; } = 0;

        public double discount { get; set; } = 0;
        public bool active { get; set; } = false ;
        public int id_emp { get; set; }

        public int id_general { get; set; }



        public int? id_vacation { get; set; }

        public virtual employee employee { get; set; }

        public virtual general_setting general_setting { get; set; }

        public virtual vacation vacation { get; set; }
    }
}
