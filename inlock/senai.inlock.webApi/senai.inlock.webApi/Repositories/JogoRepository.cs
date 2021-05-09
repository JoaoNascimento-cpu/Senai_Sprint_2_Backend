using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringconexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = inlock_games_tarde; user id = sa; pwd = Senai@132";

        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                string queryUpdateId = "UPDATE  Jogos SET idJogo, nomeJogo, descricao, dataDeLancamento, valor, idEstudio = @idJogo, @nomeJogo, @descricao, @dataDeLancamento, @valor, @idEstudio WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataDeLancamento", jogoAtualizado.dataDeLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                //declara a query que será executada
                string querySelectById = "SELECT idJogo, nomeJogo FROM Jogos WHERE idJogo = @Id";

                //abrimos a conexão
                connection.Open();

                //declara o sqlDataReader para receber os valores do bd
                SqlDataReader reader;

                // Declara o sql command command passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(querySelectById, connection))
                {
                    //passando o valor para o parâmetro @Id
                    command.Parameters.AddWithValue("@Id", id);

                    //Executa a query e armazena os dados o reader
                    reader = command.ExecuteReader();

                    // Verifiva se o resultado da query retornou algum registro
                    if (reader.Read())
                    {
                        //se sim, irá instanciar um novo objeto generoBuscado do tipo GeneroDomain

                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            //Atribui à propriedade idGenero o valor da coluna idGenero da tabela do bd
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            nomeJogo = reader["nomeJogo"].ToString()
                        };
                        //Retorna o genero buscado com os generos obtidos
                        return jogoBuscado;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {

                string queryInsert = "INSERT INTO Jogos(nomeJogo, descricao, dataDeLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataDeLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataDeLancamento", novoJogo.dataDeLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);


                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @ID";

                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    command.ExecuteNonQuery();

                };
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();
            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataDeLancamento, valor, idEstudio FROM jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogoDomain Jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            nomeJogo = rdr[1].ToString(),
                            descricao = rdr[2].ToString(),
                            dataDeLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDecimal(rdr[4]),
                            idEstudio = Convert.ToInt32(rdr[5])

                        };

                        ListaJogos.Add(Jogo);
                    }

                };

            };
                return ListaJogos;
        }
    }
}
