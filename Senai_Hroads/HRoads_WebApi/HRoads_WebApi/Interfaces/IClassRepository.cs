using HRoads_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Interfaces
{
    interface IClassRepository
    {
        List<Class> Listar();

        Class BuscarPorId(int id);


        void Cadastrar(Class cadastrarClasse);


        void Atualizar(int id, Class classeAtualizado);


        void Deletar(int id);
    }
}
