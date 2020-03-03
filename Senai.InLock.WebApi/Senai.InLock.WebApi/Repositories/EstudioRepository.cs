using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //para reconhecer o banco de dados (COMPUTADOR TAKEDI)
        // private string stringConexao = "Data Source=LAPTOP-S9Q9QIJS\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=holoko09";
        //(banco leonel)
        private string stringConexao = "Data Source=DEV14\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        //Repository para atualizar estudio por Id
        public void AtualizarEstudioIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Estudios SET NomeEstudio = @NomeEstudio WHERE IdEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public EstudioDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "SELECT IdEstudio, NomeEstudio FROM Estudios where IdEstudio = @Id";

                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@Id",id);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain();
                        estudio.IdEstudio = Convert.ToInt32(reader[0]);
                        estudio.NomeEstudio = reader["NomeEstudio"].ToString();

                        return estudio;
                    }
                    return null;
                }
            }
        }

        //Repository para cadastrar um novo estudio
        public void Cadastrar(EstudioDomain estudio)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@NomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", estudio.NomeEstudio);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Deletar um estudio 
            public void Deletar(int id)
        {

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                string queryDelete = "DELETE FROM Estudios WHERE IdEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Listar todos os estudios
        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            NomeEstudio = rdr["NomeEstudio"].ToString()
                            };
                            estudios.Add(estudio);
                        }
                    }
                }
                return estudios;
            }
        }
    }
