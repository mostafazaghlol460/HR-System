namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class page
    {
        [Key]
        public int id_page { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public bool? insert { get; set; }

        public bool? update { get; set; }

        public bool? show { get; set; }

        public bool? delete { get; set; }

        public int? id_group { get; set; }

        public virtual Group Group { get; set; }
    }
}
