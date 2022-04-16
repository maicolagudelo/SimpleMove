using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SimpleMove.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Conexion")
        {
        }

        public virtual DbSet<listado_ayudante> listado_ayudante { get; set; }
        public virtual DbSet<listado_vehiculos> listado_vehiculos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<listado_ayudante>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<listado_ayudante>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_ayudante>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_ayudante>()
                .Property(e => e.informacion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_vehiculos>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<listado_vehiculos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_vehiculos>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_vehiculos>()
                .Property(e => e.informacion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_vehiculos>()
                .Property(e => e.capacidad)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.tipo_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.direccion)
                .IsUnicode(false);
        }
    }
}
