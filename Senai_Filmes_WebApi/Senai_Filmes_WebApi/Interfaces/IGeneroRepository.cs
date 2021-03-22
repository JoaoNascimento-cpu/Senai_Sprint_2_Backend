using Senai_Filmes_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipodoParametro nomeParametro)
        /// <summary>
        /// Esse método lista todos os generos
        /// </summary>
        /// <returns>Retorna lista de generos</returns>
        List<GeneroDomain> listarTodos();
        
        /// <summary>
        /// Busca um genero pelo id
        /// </summary>
        /// <param name="id">o id do genero que sera buscado</param>
        /// <returns>retorna o objeto (genero) que foi buscado pelo id</returns>
        GeneroDomain BuscarId(int id);
        
        /// <summary>
        /// este metodo cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">informacao que sera cadastrada</param>
        void Cadastrar(GeneroDomain novoGenero);
        
        /// <summary>
        /// Esse metodo atualiza um genero existente  passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">genero que sera atualizado com novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);
        
        /// <summary>
        /// Atualiza o genero existente passando o id pelo URL da requisicao
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="">obejto genero com as novas informacoes</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        void Deletar(int id);

    }
}
