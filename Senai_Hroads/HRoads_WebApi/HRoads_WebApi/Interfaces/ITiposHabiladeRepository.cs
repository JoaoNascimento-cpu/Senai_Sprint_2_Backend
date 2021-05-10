using HRoads_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Interfaces
{
    interface ITiposHabiladeRepository
    {
        /// <summary>
        /// método usado para criar um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade"> Novo tipo de habilidade que será gerado</param>
        void Criar(TiposHabilidade novoTipoHabilidade);
        
        /// <summary>
        /// método usado para listar todos os tipos de habilidades
        /// </summary>
        /// <returns>Retorna lista de tipos de habilidade</returns>
        List<TiposHabilidade> ListarTodos();

        /// <summary>
        /// Método usado para buscar o tipo de habilidade de acordo com seu id
        /// </summary>
        /// <param name="id">id do tipo habilidade</param>
        /// <returns>o id do tipo de habilidade que foi buscado</returns>
        TiposHabilidade BuscarPorId(int id);  

        /// <summary>
        /// esse método atualiza um tipo de habilidade existente passando o id pelo url da requisição
        /// </summary>
        /// <param name="id">id do tipo da habilidade que será passado</param>
        /// <param name="tipo">o tipo de habilidade com novas informações</param>
        void AtualizarIdUrl(int id, TiposHabilidade tipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta o tipo de habilidade que for buscado
        /// </summary>
        /// <param name="id">id do objeto(tipo de habilidade) que será deletado</param>
        void Deletar(int id);

    }
}
