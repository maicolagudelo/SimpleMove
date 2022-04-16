namespace SimpleMove.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ejmplo")]
    public partial class ejmplo
    {
        [Key]
        [StringLength(50)]
        public string correo { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        public int? costo { get; set; }

        [StringLength(50)]
        public string contactos { get; set; }
    }
}
