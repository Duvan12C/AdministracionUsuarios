using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly string _connectionString;

        public PermisoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Permiso>> ObtenerPermisos()
        {
            var permisos = new List<Permiso>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT Id, Nombre FROM Permisos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var permiso = new Permiso
                                {
                                    Id = (int)reader["Id"],
                                    Nombre = reader["Nombre"].ToString()
                                };
                                permisos.Add(permiso);
                            }
                        }
                    }
                }

                return permisos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de permisos.", ex);
            }
        }
    }
}
