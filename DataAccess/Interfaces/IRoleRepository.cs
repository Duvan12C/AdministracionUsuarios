using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        Task  CrearRol(Rol rol);
        Task ActualizarRol(Rol rol);
        Task<IEnumerable<Rol>> ObtenerRoles();
        Task EliminarRol(int idRol);
    }
}
