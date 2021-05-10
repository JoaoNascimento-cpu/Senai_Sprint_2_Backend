using HRoads_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();

        Habilidade BuscarPorId(int id);


        void Cadastrar(Habilidade cadastrarHabilidade);


        void Atualizar(int id, Habilidade habilidadeAtualizado);


        void Deletar(int id);

        List<Habilidade> ListarTodos();
    }
}
