using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CrearRol(Rol rol)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string checkQuery = "SELECT COUNT(1) FROM Roles WHERE Nombre = @Nombre";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            throw new Exception("Ya existe un rol con el mismo nombre.");
                        }
                    }
                    string query = "INSERT INTO Roles (Nombre) VALUES (@Nombre)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el rol.", ex);
            }
        }

        public async Task ActualizarRol(Rol rol)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = @"
                        SELECT COUNT(1)
                        FROM Roles
                        WHERE Nombre = @Nombre
                        AND Id != @Id"; 

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                        checkCmd.Parameters.AddWithValue("@Id", rol.Id);

                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            throw new Exception("Ya existe un rol con el mismo nombre.");
                        }
                    }

                    string query = "UPDATE Roles SET Nombre = @Nombre WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", rol.Nombre);
                        cmd.Parameters.AddWithValue("@Id", rol.Id);

                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        if (affectedRows == 0)
                        {
                            throw new Exception("No se encontró el rol para actualizar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el rol.", ex);
            }
        }

        public async Task EliminarRol(int idRol)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "DELETE FROM Roles WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idRol);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol.", ex);
            }
        }

        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            var roles = new List<Rol>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT Id, Nombre FROM Roles";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var rol = new Rol
                                {
                                    Id = (int)reader["Id"],
                                    Nombre = reader["Nombre"].ToString()
                                };
                                roles.Add(rol);
                            }
                        }
                    }
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de roles.", ex);
            }
        }

    }
}
