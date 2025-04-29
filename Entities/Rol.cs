using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con Usuarios
        public ICollection<Usuario> Usuarios { get; set; }

        // Relación con Permisos
        public ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}
