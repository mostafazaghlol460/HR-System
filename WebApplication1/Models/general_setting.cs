namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class general_setting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public general_setting()
        {
            report_employee = new HashSet<report_employee>();
        }

        [Key]
        public int id_genral_setting { get; set; }
        [Required]
        public double extra { get; set; }
        [Required]
        public double discount { get; set; }

        [Required]
        public string hoilday_day { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report_employee> report_employee { get; set; }
    }
}
