namespace SimpleMove.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("calificacion")]
    public partial class calificacion
    {
        [Key]
        public int codigo { get; set; }

        public long telefono { get; set; }

        [Column("calificacion")]
        [StringLength(200)]
        public string calificacion1 { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
