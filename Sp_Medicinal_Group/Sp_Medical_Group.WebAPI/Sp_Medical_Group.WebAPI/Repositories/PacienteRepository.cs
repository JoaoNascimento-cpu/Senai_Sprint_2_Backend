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
    public class PacienteRepository : IPacienteRepository
    {
        SPMGctx ctx = new SPMGctx();

        public void Atualizar(int id, Paciente novoPaciente)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteBuscado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = novoPaciente.NomePaciente;
                pacienteBuscado.Telefone = novoPaciente.Telefone;
            }
            ctx.Pacientes.Update(pacienteBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente PacBuscado = ctx.Pacientes.Find(id);
            ctx.Pacientes.Remove(PacBuscado);
            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }

        public List<Paciente> ListarTudo()
        {
            return ctx.Pacientes
                .Include(c => c.Consulta)
                .ToList();
        }
    }
}
