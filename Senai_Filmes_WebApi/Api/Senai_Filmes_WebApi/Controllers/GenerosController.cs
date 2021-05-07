using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using Senai_Filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;

/// <summary>
/// Controller responsável pelos endpoints
/// </summary>
namespace Senai_Filmes_WebApi.Controllers
{
    //define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    //define que a rota de uma requisição será no formato dominio/api/nomeController
    //ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //define que é um controlador de API
    [ApiController]

    //
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// O objeto generorepository irá receber todos os métodos definidops pela inteface GeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// instância o objeto _generoRepository para que haja as referencias aos metodos do repositorio
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Esse endpoint lista todos os generos
        /// </summary>
        /// <returns>uma lusta de generos e um status code</returns>
        /// http://localhost:5000/api/generos
        /// o usuário deverá estar logado para listar todos os gêneros
        [Authorize] //verifica se o usuário está logado
        [HttpGet]
        public IActionResult Get()
        {
            //cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.listarTodos();
            //retorna status code 200(OK) com a lista no formato json
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um genero através de seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns>Um genero buscado ou notFound caso nenhum genero senha buscado</returns>
        /// http://LocalHost:5000/api/generos
         [Authorize(Roles = "administrador")] //somente um usuario adm poderá pegar o gênero pelo id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //cria um objeto generoBuscado que irá receber o genero que foi buscado no bd
            GeneroDomain generoBuscado = _generoRepository.BuscarId(id);

            if (generoBuscado == null)
            {
                //se não for encontrado o genero, irá retornar o not found
                return NotFound("Nenhum gênero encontrado.");
            }
            else
            {
                return Ok(generoBuscado);
            }
        }

        /// <summary>
        /// Atualiza genero existente
        /// </summary>
        /// <param name="id">id que será atualizado</param>
        /// <param name="generoAtualizado">objeto generoAtualizado com as novas informações</param>
        /// <returns>Status Code </returns>
        /// http://LocalHost:500/api/generos/1
        [HttpPut("{Id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            //Cria um objeto generoBuscado que irá receber o genero buscado no bd
            GeneroDomain generoBuscado = _generoRepository.BuscarId(id);

            //caso não seja encontrado irá retornar um not found
            //e um bool pra apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound
                    (
                        new 
                        {
                            mensagem = "Gênero não encontrado",
                            erro = true
                        }
                    );
            }
            // tenta atualizar o registro
            try
            {
                //faz chamada par ao metodo AtualizarIdUrl
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                //retorna status code  204 - no content
                return NoContent();
            }
            catch (Exception codErro)
            {
                //Retorna status code 400 - Bad Request
                return BadRequest(codErro);
            }

        }

        /// <summary>
        /// Atualiza um gênero existente passando suas informações pelo corpo
        /// </summary>
        /// <param name="generoAtualizado"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado) 
        {
            //Cria um objeto generoBuscado que ira receber  o gênero buscado no BD
            GeneroDomain generoBuscado = _generoRepository.BuscarId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    //faz a chamada para o método AtualizarIdCorpo
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    //Retorna statusCode NoContent- 204
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    //retorna statusCode BadRequest com o código de erro
                    return BadRequest(codErro);
                }
            }
            //caso não seja encontrado, retorna um statusCode NotFound com uma mensagem personalizada
            return NotFound
                (
                    new 
                    {
                        mensagem = "Gênero não encontrado"
                    }
                );
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns>status code 201 - Created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //faz uma chamada para o método cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //retorna status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Status Code 204 - No Content</returns>
        //http://localhost:5000/api/generos/7
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);

            //Retorna Status Code 204 - No Content
            return StatusCode(204);
        }
    }
}
