using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SimpleMove.Models
{
    public partial class simplemove : DbContext
    {
        public simplemove()
            : base("name=simplemove")
        {
        }

        public virtual DbSet<listado_ayudantes> listado_ayudantes { get; set; }
        public virtual DbSet<listado_conductores> listado_conductores { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipo_usuarios> tipo_usuarios { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<listado_ayudantes>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_ayudantes>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_ayudantes>()
                .Property(e => e.medioInfo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_conductores>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<listado_conductores>()
                .Property(e => e.costo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_conductores>()
                .Property(e => e.medioInfo)
                .IsUnicode(false);

            modelBuilder.Entity<listado_conductores>()
                .Property(e => e.capacidad)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_usuarios>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_usuarios>()
                .HasMany(e => e.usuarios)
                .WithRequired(e => e.tipo_usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.listado_ayudantes)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.listado_conductores)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
