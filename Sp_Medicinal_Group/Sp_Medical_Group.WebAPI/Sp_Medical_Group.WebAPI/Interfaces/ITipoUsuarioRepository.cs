using Sp_Medical_Group.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// método utilizado para a listagem de Tipos de usuários
        /// </summary>
        /// <returns>lista de tipos de usuários</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// método utilizado para buscr um tipo de usuário existente
        /// </summary>
        /// <param name="id">id do tipo de usuário que irá passar pela url da requisição</param>
        /// <returns>tipo de usuário buscado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// método utilizado para cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">objeto que irá armazenar as informações do novo tipo de usuário cadastrado</param>
        void Cadastro(TipoUsuario novoTipoUsuario);

        void Deletar(int id);

        /// <summary>
        /// método utilizado para atualizar determinado usuário
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <param name="usuario">objeto que irá armazenar as novas informações do usuário</param>
        void Atualizar(int id, TipoUsuario novoTipoUsuario);
    }
}
