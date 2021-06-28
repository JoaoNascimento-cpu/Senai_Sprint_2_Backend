using SP_Medical_Group_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_WebAPI.Interface
{
    interface IPaciente_Repository
    {
        List<Paciente> Listar();
        List<Paciente> ListarTudo();
        Paciente BuscarId(int id);
        void Cadastrar(Paciente novoPaciente);
        void Deletar(int id);
        void Atualizar(int id, Paciente novoPaciente);
    }
}
