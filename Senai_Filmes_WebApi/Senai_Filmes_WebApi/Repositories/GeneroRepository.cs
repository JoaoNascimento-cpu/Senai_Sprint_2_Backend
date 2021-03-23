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
        private string stringConexao = "Data Source = LAPTOP-II7UP0KL; intial catalog = Filmes; user id = sa; pwd = Senai@132";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
