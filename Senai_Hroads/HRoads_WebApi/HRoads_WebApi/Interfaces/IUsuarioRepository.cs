using HRoads_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);


        void Cadastrar(Usuario cadastrarUsario);


        void Atualizar(int id, Usuario UsuarioAtualizado);


        void Deletar(int id);
    }
}
