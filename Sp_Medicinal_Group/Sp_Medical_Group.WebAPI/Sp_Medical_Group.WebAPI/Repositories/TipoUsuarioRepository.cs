using Sp_Medical_Group.WebAPI.Contexts;
using Sp_Medical_Group.WebAPI.Domains;
using Sp_Medical_Group.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SPMGctx ctx = new SPMGctx();

        public void Atualizar(int id, TipoUsuario novoTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioBuscado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = novoTipoUsuario.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Cadastro(TipoUsuario novoTipoUsuario)
        {
            ctx.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
