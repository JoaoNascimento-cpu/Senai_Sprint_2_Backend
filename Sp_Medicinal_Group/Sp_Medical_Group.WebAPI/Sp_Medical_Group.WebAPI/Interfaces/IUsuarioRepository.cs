using Sp_Medical_Group.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        /// <summary>
        /// método utilizado para a listagem de usuários
        /// </summary>
        /// <returns>lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// método utilizado para buscr um usuário existente
        /// </summary>
        /// <param name="id">id do usuário que irá passar pela url da requisição</param>
        /// <returns>usuário buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// método utilizado para cadastrar um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">objeto que irá armazenar as informações do novo usuário cadastrado</param>
        void Cadastro(Usuario NovoUsuario);

        void Deletar(int id);

        /// <summary>
        /// método utilizado para atualizar determinado usuário
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <param name="usuario">objeto que irá armazenar as novas informações do usuário</param>
        void AtualizarUsuario(int id, Usuario usuario);

    }
}
