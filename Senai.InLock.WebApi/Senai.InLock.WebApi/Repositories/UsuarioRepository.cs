using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Enums;
using Senai.InLock.WebApi.Interfaces;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV14\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void Atualizar(int id, UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "update Usuarios set Email = @Email, Senha = @Senha  where IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    string verificar = "select  Usuarios.Email, Usuarios.Senha from Usuarios where IdUsuario = @Id";

                    using (SqlCommand verificarUser = new SqlCommand(verificar, con))
                    {
                        verificarUser.Parameters.AddWithValue("@Id", id);

                        con.Open();

                        SqlDataReader rdrVerificar = verificarUser.ExecuteReader();

                        if (rdrVerificar.Read())
                        {
                            UsuarioDomain userBackup = new UsuarioDomain();
                            userBackup.Email = rdrVerificar["Email"].ToString();
                            userBackup.Senha = rdrVerificar["Senha"].ToString();

                            if (String.IsNullOrEmpty(usuario.Email))
                            {
                                cmd.Parameters.AddWithValue("@Email", userBackup.Email);
                                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                            }
                            else if (String.IsNullOrEmpty(usuario.Senha))
                            {
                                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                                cmd.Parameters.AddWithValue("@Senha", userBackup.Senha);
                            }

                            rdrVerificar.Close();

                            cmd.ExecuteNonQuery();
                        }

                    }

                }
            }
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "select Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, Usuarios.IdTipoUsuario from Usuarios where Usuarios.Email = @Email and Usuarios.Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain();
                        usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Email = reader["Email"].ToString();
                        usuario.Senha = reader["Senha"].ToString();
                        usuario.IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);

                        if (usuario.IdTipoUsuario == 1)
                        {
                            usuario.IdTipoUsuario = (int)TipoUsuario.Administrador;
                        }
                        else if (usuario.IdTipoUsuario == 2)
                        {
                            usuario.IdTipoUsuario = (int)TipoUsuario.Cliente;
                        }

                        return usuario;
                    }
                }
                return null;
            }
        }

        public void Cadastar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuarios VALUES (@Email,@Senha , @TipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    usuario.IdTipoUsuario = (int)TipoUsuario.Cliente;
                    cmd.Parameters.AddWithValue("@TipoUsuario", usuario.IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "delete from Usuarios where IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodosJogos()
        {
            throw new System.NotImplementedException();
        }

        public List<UsuarioDomain> ListarUsuarios()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "select IdUsuario,Email , Senha, IdTipoUsuario from Usuarios";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain();
                        usuario.IdUsuario = Convert.ToInt32(reader[0]);
                        usuario.Email = reader["Email"].ToString();
                        usuario.Senha = reader["Senha"].ToString();
                        usuario.IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }
    }
}