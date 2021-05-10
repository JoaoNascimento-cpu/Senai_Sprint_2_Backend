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
    public class TiposHabilidadeRepository : ITiposHabiladeRepository
    {
        HRoadsContext context = new HRoadsContext();

        public void AtualizarIdUrl(int id, TiposHabilidade tipoHabilidadeAtualizado)
        {
            TiposHabilidade tiposHabilidadeBuscado = context.TiposHabilidades.Find(id);

            if (tipoHabilidadeAtualizado.Tipo != null)
            {
                tiposHabilidadeBuscado.Tipo = tiposHabilidadeBuscado.Tipo;
            }

            context.TiposHabilidades.Update(tiposHabilidadeBuscado);

            context.SaveChanges();
        }

        public TiposHabilidade BuscarPorId(int id)
        {
            return context.TiposHabilidades.FirstOrDefault(tp => tp.IdTiposHabilidades == id);
        }

        public void Criar(TiposHabilidade novoTipoHabilidade)
        {
            context.TiposHabilidades.Add(novoTipoHabilidade);

            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposHabilidade deletarTipoHabilidade = context.TiposHabilidades.Find(id);

            context.TiposHabilidades.Remove(deletarTipoHabilidade);

            context.SaveChanges();
        }

        public List<TiposHabilidade> ListarTodos()
        {
            return context.TiposHabilidades.ToList();
        }
        public List<TiposHabilidade> ListarHabilidades()
        {
            // Retorna uma lista de estúdios com seus jogos
            return context.TiposHabilidades.Include(tp => tp.Habilidades).ToList();
        }
    }
}
