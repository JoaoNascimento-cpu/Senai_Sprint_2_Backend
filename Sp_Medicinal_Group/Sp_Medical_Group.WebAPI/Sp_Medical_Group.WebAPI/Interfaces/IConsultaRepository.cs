using Sp_Medical_Group.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarConsulta();
        List<Consultum> ListarTudo();
        List<Consultum> ConsultasPaciente(int id);
        List<Consultum> ConsultasMedico(int id);
        Consultum BuscarId(int id);
        void Cadastrar(Consultum novaConsulta);
        void Deletar(int id);
        void Atualizar(int id, Consultum novaConsulta);
        void Situacao(int id, string status);
    }
}
