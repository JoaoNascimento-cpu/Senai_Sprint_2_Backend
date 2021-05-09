using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Essa variavel é uma string de conexão com o banco de dados que recebe os parametros Data Source = Nome do servidor, 
        /// Initial Catalog = BD
        /// User id = sa; pwd=Senai@132 = faz uma autenticacao com o usuario do SQL server, passando logon e a senha
        /// </summary>
        private string stringConexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = inlock_games_tarde; user id = sa; pwd = Senai@132";

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idTipoUsuario FROM TipoUsuario WHERE idTipoUsuario = @ID";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectById, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TipoUsuarioDomain usuarioBuscar = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                        };
                        return usuarioBuscar;
                    }
                    return null;
                }
            }

        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            //cria uma lista de generos onde serão armazenados esses dados
            List<TipoUsuarioDomain> ListaTipoUsuario = new List<TipoUsuarioDomain>();

            //declarando a SqlConnection con passando a string de conexão como parametro
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //Declaramos a querySelectAll e como será executada
                string querySelectAll = "SELECT * FROM TipoUsuario";

                //Abrimos conexão com o BD
                connection.Open();

                //Criamos o objeto reader para ler todo o banco de dados
                SqlDataReader reader;

                //Declara o SqlCommand passando a query que será executada 
                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    //executa a query e armazena os dados no reader
                    reader = command.ExecuteReader();

                    //enquanto houver registros para serem lidos no reader, o laço irá se repetir
                    while (reader.Read())
                    {
                        //instanciamos um objeto do TipoUsuario Domain
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            //atribui o valor dessa propriedade na linha 1
                            idTipoUsuario = Convert.ToInt32(reader[0]),

                            //atribui o valor dessa propriedade na linha 2
                            titulo = Convert.ToString(reader[1])
                        };

                        ListaTipoUsuario.Add(tipoUsuario);
                    }
                }
                return ListaTipoUsuario;
            }
        }
    }
    
}
