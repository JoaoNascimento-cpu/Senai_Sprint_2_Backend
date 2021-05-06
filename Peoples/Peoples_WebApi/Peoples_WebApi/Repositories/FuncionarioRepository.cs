using Peoples_WebApi.Domains;
using Peoples_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples_WebApi.Repositories
{
    public class FuncionarioRepository : IFuncuinarioRepository
    {
        private string stringConexao = "Data Source= LAPTOP-II7UP0KL; initial catalog= Peoples; user id= sa; pwd= Senai@132";
        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método usado para cadastrar o novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Objeto que ira receber as informações dadas</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            //Abrimos conexão com o bd declarando o SqlConnection passando a string de conexão 
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                string queryCadastrar = "INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento)" + 
                                        "VALUES(@Nome, @Sobrenome, @DataNascimento)";

                using (SqlCommand command = new SqlCommand(queryCadastrar, connection))
                {
                    command.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    command.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);
                    command.Parameters.AddWithValue("@DataNascimento", novoFuncionario.dataNascimento);

                    //Abrimos a conexão com o BD
                    connection.Open();

                    //Executamos a Query(queryCadastrar)
                    command.ExecuteNonQuery();
                    
                }
                

            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionario = @id";

                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    command.ExecuteNonQuery();

                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao)) 
            {
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios";
                con.Open();

                SqlDataReader reader;

                using(SqlCommand command = new SqlCommand(querySelectAll, con)) 
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"])
                            ,nome         = reader["nome"].ToString()
                            ,sobrenome    = reader["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;
                }
            }
            
            
        }
    }
}
