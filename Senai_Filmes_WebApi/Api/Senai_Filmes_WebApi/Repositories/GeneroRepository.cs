using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// Essa variavel é uma string de conexão com o banco de dados que recebe os parametros Data Source = Nome do servidor, 
        /// Initial Catalog = BD
        /// User id = sa; pwd=Senai@132 = faz uma autenticacao com o usuario do SQL server, passando logon e a senha
        /// </summary>
        private string stringConexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = Filmes; user id = sa; pwd = Senai@132";

        /// <summary>
        /// Atualiza um gênero passando as novas informações pelo corpo
        /// </summary>
        /// <param name="genero">obejto genero que irá receber as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
             //Declara a SqlConnection connection passando a string de conexão
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //Declara a query que será execudata
                string queryUpadateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //Declara o sqlcommand command passando a query que será executada
                using (SqlCommand command = new SqlCommand(queryUpadateIdUrl, connection)) 
                {
                    //Passa os valores para os parametros
                    command.Parameters.AddWithValue("@ID", genero.idGenero);
                    command.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abre conexão com o bd
                    connection.Open();

                    //Executa  a query
                    command.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Atualiza um genero passando o id pelo recurso(URL)
        /// </summary>
        /// <param name="id">id do genero que será atualizado</param>
        /// <param name="genero">objeto genero com novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            //Declara a SqlConnection connection passando a string de conexão
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //Declara a query que será execudata
                string queryUpadateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //Declara o sqlcommand command passando a query que será executada
                using (SqlCommand command = new SqlCommand(queryUpadateIdUrl, connection)) 
                {
                    //Passa os valores para os parametros
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abre conexão com o bd
                    connection.Open();

                    //Executa  a query
                    command.ExecuteNonQuery();
                }

            }
        }

        public GeneroDomain BuscarId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //declara a query que será executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @Id";

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

                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            //Atribui à propriedade idGenero o valor da coluna idGenero da tabela do bd
                            idGenero = Convert.ToInt32(reader["idGenero"]),

                            nome = reader["Nome"].ToString()
                        };
                        //Retorna o genero buscado com os generos obtidos
                        return generoBuscado;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Busca um gênero pelo seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um genero buscado do GeneroDomain ou Null caso não seja encontrado</returns>



        /// <summary>
        /// Cadastra um novo gênero de filmes
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero que irá armazenar as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                //INSERT INTO Generos(Nome) VALUES('Ficção Científica')";
                //string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + novoGenero.nome + "')";
                //não escrever dessa forma, pois dará problema 'Joana D' Arc, que permitirá a inserção de
                //códigos SQL a partir do próprio Postman, que em mãos erradas, poderiam derrubar o próprio database 
                //conhecido como SQL Injection
                //nome: ('')DROP TABLE FILMES
                //O código acima iria fazer uma tabela ser excluida, coisa que não seria uma boa ideia

                //Declara a Query que está sendo executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";


                //Declara o sqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //essa linha passa o valor para o parâmetro '@Nome'
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta o Gênero atrvés de seu id
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            //Declara o SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser execurtada passando o parâmetro @id
                string queryDelete = "DELETE FROM Generos WHERE idgenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //define o valor do id recebido no metodo como valor do parâmetro @id
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>Lista de generos</returns>
        public List<GeneroDomain> listarTodos()
        {
            //cria uma lista  listaGeneros onde serao armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //declarando a SqlConnection con passando a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //abre a conexão com o BD
                con.Open();

                //Declara o SqlDataReader reader para percorrer a tabela do BD
                SqlDataReader reader;

                //Declara o SqlCommand command passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena os dados n o reader
                    reader = command.ExecuteReader();

                    //enquanto houver registros para serem lidps no reader, o laço irá se repetir
                    while (reader.Read())
                    {
                        //instancia um objeto do GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a  propriedade idGenero o valor da primeira coluna da tabela do BD
                            idGenero = Convert.ToInt32(reader[0]),

                            //Atribui a propriedade nome o valor da segunda coluna da tabela do BD
                            nome = reader[1].ToString()
                        };
                        //adiciona o objeto genero criado á lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }
            //retorna o objeto listaGeneros
            return listaGeneros;
        }


    }
}
