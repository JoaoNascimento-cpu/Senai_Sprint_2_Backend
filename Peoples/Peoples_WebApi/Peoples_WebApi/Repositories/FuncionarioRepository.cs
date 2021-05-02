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

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
