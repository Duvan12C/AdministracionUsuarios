using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Interfaces
{
    public interface IRolPermisoRepository
    {
        Task<List<Permiso>> ObtenerPermisosPorRol(int rolId);
        Task ActualizarPermisos(int rolId, List<int> permisosSeleccionados);
    }
}
