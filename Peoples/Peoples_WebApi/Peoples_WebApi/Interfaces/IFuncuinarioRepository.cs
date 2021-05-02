using Peoples_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples_WebApi.Interfaces
{
    interface IFuncuinarioRepository
    {
        List<FuncionarioDomain>  ListarTodos();

        FuncionarioDomain BuscarPorId(int id);

        void Cadastrar(FuncionarioDomain novoFuncionario);

        void Atualizar(int id, FuncionarioDomain funcionarioAtualizado);

        void Delete(int id);
    }
}
