using Microsoft.EntityFrameworkCore;
using SP_Medical_Group_WebAPI.Contexts;
using SP_Medical_Group_WebAPI.Domains;
using SP_Medical_Group_WebAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_WebAPI.Repositories
{
    public class PacienteRepository : IPaciente_Repository
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
