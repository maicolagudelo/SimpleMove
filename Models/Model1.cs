using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SimpleMove.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ejmplo> ejmplo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ejmplo>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<ejmplo>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ejmplo>()
                .Property(e => e.contactos)
                .IsUnicode(false);
        }
    }
}
