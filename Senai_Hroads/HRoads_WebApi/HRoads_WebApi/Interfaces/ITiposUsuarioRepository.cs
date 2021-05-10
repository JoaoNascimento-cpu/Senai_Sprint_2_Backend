using HRoads_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(int id);


        void Cadastrar(TiposUsuario cadastrarTipoUsario);


        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);


        void Deletar(int id);
    }
}
