
namespace WebApplication1.Models
{
    using WebApplication1.validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            report_employee = new HashSet<report_employee>();
        }

        [Key]
        public int id_employee { get; set; }

        [Required]
        [StringLength(100)]
        public string name_emp { get; set; }

        [Required]
        [StringLength(200)]
        public string address_emp { get; set; }

        [Required]
        [RegularExpression(@"^[01]\d{10}$", ErrorMessage = "Invalid phone, the phone number should contain 10 digits")]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string gender { get; set; }

        [Required]
        [StringLength(50)]
        public string nationality { get; set; }


        [customDate]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        //[Range(typeof(DateTime), "1/1/1923", "1/1/2003",ErrorMessage = "you must the employee age is more than 20 year")]
        public DateTime DOB { get; set; }

        [Required]

        [RegularExpression(@"^\d{14}$", ErrorMessage = "Invalid ID number, the ID number should contain 14 digits")]
        public long national_id { get; set; }

        public int salary { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateRange]
        public DateTime date_of_conference { get; set; }
        [Required]
        public TimeSpan attend_time { get; set; }
        [Required]
        public TimeSpan leave_time { get; set; }
        [NotMapped]
        public double total_hour_bouns { get; set; }
        [NotMapped]
        public double total_hour_discount { get; set; }
        [NotMapped]
        public double total_hour_bouns_salary { get; set; }
        [NotMapped]
        public double total_hour_discount_salary { get; set; }
        public int total_attend { get; set; } = 0;

        public int total_absent { get; set; } = 0;

        [NotMapped]
        public double salary_real { get; set; }

        public int id_HR { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report_employee> report_employee { get; set; }
    }
}