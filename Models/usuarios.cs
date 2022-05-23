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
            calificacion = new HashSet<calificacion>();
            listado_ayudantes = new HashSet<listado_ayudantes>();
            listado_conductores = new HashSet<listado_conductores>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long telefono { get; set; }

        [StringLength(200)]
        public string contraseña { get; set; }

        public int tipo_usuario { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellido { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        public byte[] foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificacion> calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listado_ayudantes> listado_ayudantes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listado_conductores> listado_conductores { get; set; }

        public virtual tipo_usuarios tipo_usuarios { get; set; }
    }
}
