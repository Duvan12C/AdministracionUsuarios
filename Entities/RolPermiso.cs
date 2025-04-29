using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        // Navegación
        public Rol Rol { get; set; }
        public Permiso Permiso { get; set; }
    }
}
