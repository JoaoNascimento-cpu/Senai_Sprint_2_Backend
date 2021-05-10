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
    public class Habilidaderepository : IHabilidadeRepository
    {
        HRoadsContext context = new HRoadsContext();
        public void Atualizar(int id, Habilidade habilidadeAtualizado)
        {
            Habilidade habilidadeBuscado = context.Habilidades.Find(id);

            // Verifica se o nome do estúdio foi informado
            if (habilidadeBuscado.NomeHabilidade != null)
            {
                // Atribui os novos valores aos campos existentes
                habilidadeBuscado.NomeHabilidade = habilidadeAtualizado.NomeHabilidade;
            }

            // Atualiza o estúdio que foi buscado
            context.Habilidades.Update(habilidadeBuscado);

            // Salva as informações para serem gravadas no banco de dados
            context.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            return context.Habilidades.FirstOrDefault(c => c.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade cadastrarHabilidade)
        {
            context.Habilidades.Add(cadastrarHabilidade);

            // Salva as informações para serem gravadas no banco de dados
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade deletarHabilidade = context.Habilidades.Find(id);

            // Remove a classe que foi buscado
            context.Habilidades.Remove(deletarHabilidade);

            // Salva as alterações
            context.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return context.Habilidades.ToList();
        }

        public List<Habilidade> ListarTodos()
        {
            return context.Habilidades.Include(h => h.IdTiposHabilidadesNavigation).ToList();
        }
    }
}
