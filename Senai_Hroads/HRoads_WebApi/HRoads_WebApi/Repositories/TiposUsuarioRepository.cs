using HRoads_WebApi.Contexts;
using HRoads_WebApi.Domains;
using HRoads_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        HRoadsContext context = new HRoadsContext();
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tipoBuscado = context.TiposUsuarios.Find(id);


            if (tipoUsuarioAtualizado.Titulo != null)
            {

                tipoBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            }


            context.TiposUsuarios.Update(tipoBuscado);


            context.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return context.TiposUsuarios.FirstOrDefault(tp => tp.IdTiposusuarios == id);
        }

        public void Cadastrar(TiposUsuario cadastrarTipoUsario)
        {
            context.TiposUsuarios.Add(cadastrarTipoUsario);


            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = context.TiposUsuarios.Find(id);


            context.TiposUsuarios.Remove(tipoBuscado);


            context.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return context.TiposUsuarios.ToList();
        }
    }
}
