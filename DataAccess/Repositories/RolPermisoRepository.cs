using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class RolPermisoRepository : IRolPermisoRepository
    {
        private readonly string _connectionString;

        public RolPermisoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Permiso>> ObtenerPermisosPorRol(int rolId)
        {
            var permisos = new List<Permiso>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    // Query para obtener los permisos asociados a un rol
                    string query = @"
                        SELECT p.Id, p.Nombre
                        FROM Permisos p
                        INNER JOIN Roles_Permisos rp ON p.Id = rp.PermisoId
                        WHERE rp.RolId = @RolId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RolId", rolId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var permiso = new Permiso
                                {
                                    Id = (int)reader["Id"],
                                    Nombre = reader["Nombre"].ToString(),
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
                throw new Exception("Error al obtener los permisos del rol.", ex);
            }
        }

        public async Task ActualizarPermisos(int rolId, List<int> permisosSeleccionados)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    // Lógica para actualizar los permisos de un rol
                    // Elimina permisos antiguos
                    string deleteQuery = @"
                        DELETE FROM Roles_Permisos
                        WHERE RolId = @RolId";

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@RolId", rolId);
                        await deleteCmd.ExecuteNonQueryAsync();
                    }

                    // Inserta los nuevos permisos
                    foreach (var permisoId in permisosSeleccionados)
                    {
                        string insertQuery = @"
                            INSERT INTO Roles_Permisos (RolId, PermisoId)
                            VALUES (@RolId, @PermisoId)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@RolId", rolId);
                            insertCmd.Parameters.AddWithValue("@PermisoId", permisoId);
                            await insertCmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los permisos del rol.", ex);
            }
        }
    }
}
