using HRoads_WebApi.Contexts;
using HRoads_WebApi.Domains;
using HRoads_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HRoads_WebApi.Repositories
{
    public class TiposHabilidadeRepository : ITiposHabiladeRepository
    {
        HRoadsContext context = new HRoadsContext();
        public void AtualizarIdCorpo(TiposHabilidade tipo)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, TiposHabilidade tipo)
        {
            throw new NotImplementedException();
        }

        public TiposHabilidade BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Criar(TiposHabilidade novoTipoHabilidade)
        {
          
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TiposHabilidade> ListarTodos()
        {
            return context.TiposHabilidades.ToList();
        }
    }
}
