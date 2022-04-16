namespace SimpleMove.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            listado_ayudante = new HashSet<listado_ayudante>();
            listado_vehiculos = new HashSet<listado_vehiculos>();
        }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_usuario { get; set; }

        [Key]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listado_ayudante> listado_ayudante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listado_vehiculos> listado_vehiculos { get; set; }
    }
}
