using HRoads_WebApi.Contexts;
using HRoads_WebApi.Domains;
using HRoads_WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HRoadsContext context = new HRoadsContext();
        
        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado = context.Usuarios.Find(id);


            if (UsuarioAtualizado.Email != null)
            {

                usuarioBuscado.Email = UsuarioAtualizado.Email;
            }
            context.Usuarios.Update(usuarioBuscado);


            context.SaveChanges();
        }

        public Usuario Logar(string email, string senha)
        {
            return context.Usuarios.Include(h => h.IdTiposUsuariosNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha);


        }
        public Usuario BuscarPorId(int id)
        {
            return context.Usuarios.Include(h => h.IdTiposUsuariosNavigation).FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario cadastrarUsario)
        {
            context.Usuarios.Add(cadastrarUsario);


            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = context.Usuarios.Find(id);


            context.Usuarios.Remove(usuarioBuscado);


            context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return context.Usuarios.Include(p => p.IdTiposUsuariosNavigation).ToList();
        }
    }
}
