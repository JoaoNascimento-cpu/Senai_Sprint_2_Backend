using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringconexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = inlock_games_tarde; user id = sa; pwd = Senai@132";

        public EstudioDomain BuscarPorId(int id)
        {

            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string querySelectById = "SELECT idEstudio FROM Estudios WHERE idEstudio = @ID";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectById, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),
                        };
                        return estudioBuscado;
                    }
                }
                return null;
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM Estudios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),
                            nomeEstudio = reader[0].ToString()
                        };
                        listaEstudio.Add(estudio);
                    }
                }
            }
            return listaEstudio;
        }
    }
}
