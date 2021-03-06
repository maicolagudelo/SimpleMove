namespace SimpleMove.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class listado_conductores
    {
        [Key]
        public int codigo { get; set; }

        [MaxLength(500)]
        public byte[] descripcion { get; set; }

        [StringLength(50)]
        public string costo { get; set; }

        [StringLength(100)]
        public string medioInfo { get; set; }

        [StringLength(200)]
        public string capacidad { get; set; }

        public long telefono { get; set; }

        public bool estado { get; set; }

        public byte[] img { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
