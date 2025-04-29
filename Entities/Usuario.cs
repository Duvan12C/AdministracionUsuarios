using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; } // 1 = Activo, 0 = Inactivo
        public int RolId { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Navegación
        public Rol Rol { get; set; }
    }
}
