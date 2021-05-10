using HRoads_WebApi.Contexts;
using HRoads_WebApi.Domains;
using HRoads_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Repositories
{
    public class ClassRepository : IClassRepository
    {

        HRoadsContext context = new HRoadsContext();

        public void Atualizar(int id, Class classeAtualizado)
        {
            Class classeBuscado = context.Classes.Find(id);

            // Verifica se o nome do estúdio foi informado
            if (classeAtualizado.NomeClasse != null)
            {
                // Atribui os novos valores aos campos existentes
                classeBuscado.NomeClasse = classeAtualizado.NomeClasse;
            }

            // Atualiza o estúdio que foi buscado
            context.Classes.Update(classeBuscado);

            // Salva as informações para serem gravadas no banco de dados
            context.SaveChanges();
        }

        public Class BuscarPorId(int id)
        {
            return context.Classes.FirstOrDefault(c => c.IdClasses == id);
        }

        public void Cadastrar(Class cadastrarClasse)
        {
            context.Classes.Add(cadastrarClasse);

            // Salva as informações para serem gravadas no banco de dados
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Class deletarClasse = context.Classes.Find(id);

            // Remove a classe que foi buscado
            context.Classes.Remove(deletarClasse);

            // Salva as alterações
            context.SaveChanges();
        }

        public List<Class> Listar()
        {
            return context.Classes.ToList();
        }
    }
}
