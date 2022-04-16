namespace SimpleMove.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class listado_ayudantes
    {
        [Key]
        public int codigo { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [StringLength(50)]
        public string costo { get; set; }

        [StringLength(50)]
        public string medioInfo { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
