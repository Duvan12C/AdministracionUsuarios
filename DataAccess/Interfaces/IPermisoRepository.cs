﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Interfaces
{
    public interface IPermisoRepository
    {
        Task<IEnumerable<Permiso>> ObtenerPermisos();

    }
}
