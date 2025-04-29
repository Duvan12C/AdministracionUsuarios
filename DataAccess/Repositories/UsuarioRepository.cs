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
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = @"
                        SELECT COUNT(1)
                        FROM Usuarios
                        WHERE (Nombre = @Nombre OR CorreoElectronico = @CorreoElectronico)
                        AND Id != @Id"; 

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        checkCmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                        checkCmd.Parameters.AddWithValue("@Id", usuario.Id);

                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            throw new Exception("Ya existe un usuario con el mismo nombre o correo electrónico.");
                        }
                    }

                    string query = @"
                UPDATE Usuarios
                SET Nombre = @Nombre,
                    CorreoElectronico = @CorreoElectronico,
                    Estado = @Estado,
                    RolId = @RolId
                WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                        cmd.Parameters.AddWithValue("@RolId", usuario.RolId);
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);

                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        if (affectedRows == 0)
                        {
                            throw new Exception("No se encontró el usuario para actualizar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario.", ex);
            }
        }


        public async Task CrearUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = @"
                SELECT COUNT(1) 
                FROM Usuarios 
                WHERE Nombre = @Nombre OR CorreoElectronico = @CorreoElectronico";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        checkCmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);

                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            throw new Exception("Ya existe un usuario con el mismo nombre o correo electrónico.");
                        }
                    }

                    string query = @"
                INSERT INTO Usuarios (Nombre, CorreoElectronico, Estado, RolId, FechaRegistro) 
                VALUES (@Nombre, @CorreoElectronico, @Estado, @RolId, @FechaRegistro)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                        cmd.Parameters.AddWithValue("@RolId", usuario.RolId);
                        cmd.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario.", ex);
            }
        }



        public Task EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            var usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                SELECT u.Id, u.Nombre, u.CorreoElectronico, u.Estado, u.RolId, u.FechaRegistro,
                       r.Id AS RolId, r.Nombre AS RolNombre
                FROM Usuarios u
                INNER JOIN Roles r ON u.RolId = r.Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var usuario = new Usuario
                                {
                                    Id = (int)reader["Id"],
                                    Nombre = reader["Nombre"].ToString(),
                                    CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                    Estado = (bool)reader["Estado"],
                                    RolId = (int)reader["RolId"],
                                    FechaRegistro = (DateTime)reader["FechaRegistro"],
                                    Rol = new Rol
                                    {
                                        Id = (int)reader["RolId"],
                                        Nombre = reader["RolNombre"].ToString()
                                    }
                                };

                                usuarios.Add(usuario);
                            }
                        }
                    }
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios.", ex);
            }
        }

    }
}
