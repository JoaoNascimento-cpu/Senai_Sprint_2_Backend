using Sp_Medical_Group.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();
        List<Paciente> ListarTudo();
        Paciente BuscarId(int id);
        void Cadastrar(Paciente novoPaciente);
        void Deletar(int id);
        void Atualizar(int id, Paciente novoPaciente);
    }
}
