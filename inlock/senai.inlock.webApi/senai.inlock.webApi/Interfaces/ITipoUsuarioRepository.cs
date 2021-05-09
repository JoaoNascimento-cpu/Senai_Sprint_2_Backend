using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        TipoUsuarioDomain BuscarPorId(int id);
        /// <summary>
        /// Método para listar todos os tipos de usuários
        /// </summary>
        /// <returns>Lista de ´tipos de usuário</returns>
        List<TipoUsuarioDomain> ListarTodos();
    }
}
