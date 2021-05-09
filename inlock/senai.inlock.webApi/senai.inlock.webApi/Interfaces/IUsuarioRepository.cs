using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// método usado para cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">objeto que irá receber as novas informações</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// método utiliado para listar todos os usuários registrados
        /// </summary>
        /// <returns>lista de usuários</returns>
        List<UsuarioDomain> ListarUsuarios();

        /// <summary>
        /// Método utilizado para atualizar informações passando o id pelo corpo
        /// </summary>
        /// <param name="usuario">objeto que irá receber as novas informações</param>
        void AtualizarIdCorpo(UsuarioDomain usuario);

        /// <summary>
        /// método utilizado para buscar um usuário a partir de seu id
        /// </summary>
        /// <param name="id">id do usuario buscado</param>
        /// <returns>usuario da lista de usuarios</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// método utilizado para excluir usuário
        /// </summary>
        /// <param name="id">objeto que ira receber o valor(id) do usuário que será excluido</param>
        void Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);

    }
}
