using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringconexao = "Data Source = LAPTOP-II7UP0KL; initial catalog = inlock_games_tarde; user id = sa; pwd = Senai@132";
        public void AtualizarIdCorpo(UsuarioDomain usuario)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string queryUpdate = "UPDATE Usuario SET email, senha = @email, @senha WHERE idUsuario = @ID";

                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@ID", usuario.idUsuario);
                    command.Parameters.AddWithValue("@email", usuario.email);
                    command.Parameters.AddWithValue("@senha", usuario.senha);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            //declaramos a SqlConnection passando a stingConexão
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                //define a query a ser executada
                string querySelect = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuarios WHERE email = @email AND senha =@senha";

                using (SqlCommand command = new SqlCommand(querySelect, connection))
                {
                    //Define ops valores dos parametros
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);

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
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"])
                        };
                        //retorna objeto usuarioBuscado
                        return usuarioBuscado;
                    }
                    //senão retorna null
                    return null;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string querySelectById = "SELECT idUsuario FROM Usuarios WHERE idUsuario = @ID";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectById, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string queryInsert = "INSERT INTO Usuarios(email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario) ";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("@email", novoUsuario.email);
                    command.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    command.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                //Declara a query a ser execurtada passando o parâmetro @id
                string queryDelete = "DELETE FROM Usuarios WHERE idUsuario = @id";

                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    //define o valor do id recebido no metodo como valor do parâmetro @id
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarUsuarios()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringconexao))
            {
                string querySelectAll = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader[0]),
                            email = reader[1].ToString(),
                            senha = reader[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(reader[3])
                        };
                        listaUsuarios.Add(usuario);
                    }
                }
                return listaUsuarios;
            }
        }
    }
}
