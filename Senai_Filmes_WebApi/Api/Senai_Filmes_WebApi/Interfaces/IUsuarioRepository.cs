using Senai_Filmes_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Esse método irá receber o email e senha do usuário pelo corpo
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>um objeto do tipo domain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);


    }
}
