﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Permiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación con Roles
        public ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}
