using Microsoft.EntityFrameworkCore;
using Sp_Medical_Group.WebAPI.Contexts;
using Sp_Medical_Group.WebAPI.Domains;
using Sp_Medical_Group.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMGctx ctx = new SPMGctx();
        public void Atualizar(int id, Consultum novaConsulta)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (novaConsulta.Descricao != null)
            {
                consultaBuscada.Descricao = novaConsulta.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consultum BuscarId(int id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consultum NovaConsulta)
        {
            ctx.Consulta.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        public List<Consultum> ConsultasMedico(int id)
        {
            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(i => i.IdUsuario == id);

            return ctx.Consulta
               .Include(p => p.IdPacienteNavigation)
               .Include(s => s.IdSituacaoNavigation)
               .Where(m => m.IdMedico == medicoBuscado.IdMedico)
               .ToList();
        }

        public List<Consultum> ConsultasPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(consultaBuscada);
            ctx.SaveChanges();
        }

        public List<Consultum> ListarConsulta()
        {
            return ctx.Consulta.ToList();
        }

        public List<Consultum> ListarTudo()
        {
            return ctx.Consulta
                .Include(i => i.IdPacienteNavigation)
                .Include(m => m.IdMedicoNavigation)
                .Include(s => s.IdSituacaoNavigation)
                .ToList();
        }

        public void Situacao(int id, string status)
        {
            Consultum consulta = ctx.Consulta
                .FirstOrDefault(i => i.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consulta.IdSituacao = 1;
                    break;

                case "2":
                    consulta.IdSituacao = 2;
                    break;

                case "3":
                    consulta.IdSituacao = 3;
                    break;

                default:
                    consulta.IdSituacao = consulta.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consulta);
            ctx.SaveChanges();
        }
    }
    
}
