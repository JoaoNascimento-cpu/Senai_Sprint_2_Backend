using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using Senai_Filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpGet]
        public IActionResult Get() 
        {
            //cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.listarTodos();
            //retorna status code 200(OK) com a lista no formato json
            return Ok(listaGeneros);
        }
    }
}
