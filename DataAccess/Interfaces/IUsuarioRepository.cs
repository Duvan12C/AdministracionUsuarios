﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerUsuarios();
        Task CrearUsuario(Usuario usuario);
        Task ActualizarUsuario(Usuario usuario);
        Task EliminarUsuario(int id);
    }
}
