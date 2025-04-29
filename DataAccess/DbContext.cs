using System;
using System.Data.Entity;
using Entities; // Asegúrate de que el espacio de nombres sea correcto

namespace DataAccess
{
    public class MiDbContext : DbContext
    {
        public MiDbContext()
            : base("name=MiConexionSQL") // Aquí le indicamos a Entity Framework la cadena de conexión
        {
        }

        // DbSet para cada entidad
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }

        // Configuración de relaciones, si es necesario
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos a muchos entre Roles y Permisos
            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            modelBuilder.Entity<RolPermiso>()
                .HasRequired(rp => rp.Rol)
                .WithMany(r => r.RolesPermisos)
                .HasForeignKey(rp => rp.RolId);

            modelBuilder.Entity<RolPermiso>()
                .HasRequired(rp => rp.Permiso)
                .WithMany(p => p.RolesPermisos)
                .HasForeignKey(rp => rp.PermisoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
