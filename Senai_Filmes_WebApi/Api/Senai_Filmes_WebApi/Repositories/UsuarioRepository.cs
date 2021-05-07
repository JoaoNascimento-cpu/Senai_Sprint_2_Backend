using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //string de conexão
        private string stringConexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = Filmes; user id = sa; pwd = Senai@132";

        /// <summary>
        /// Esse método irá receber o email e senha do usuário pelo corpo
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>um objeto do tipo domain que foi buscado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            //declaramos a SqlConnection passando a stingConexão
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //define a query a ser executada
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha;";

                using (SqlCommand command = new SqlCommand(querySelect, connection))
                {
                    //Define ops valores dos parametros
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);

                    //abre a conexão com o BD
                    connection.Open();

                    //Executa o comando e armazena os dados no objeto reader
                    SqlDataReader reader = command.ExecuteReader();

                    //se os dados forem obtidos
                    if (reader.Read())
                    {
                        //cria um objeto usarioBuscado
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            email = reader["email"].ToString(),
                            senha = reader["senha"].ToString(),
                            permissao = reader["permissao"].ToString()

                        };
                        //retorna objeto usuarioBuscado
                        return usuarioBuscado;
                    }
                    //senão retorna null
                    return null;
                }
            }
        }
    }
}
