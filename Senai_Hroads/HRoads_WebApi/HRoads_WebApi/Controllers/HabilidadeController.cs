using HRoads_WebApi.Domains;
using HRoads_WebApi.Interfaces;
using HRoads_WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRoads_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new Habilidaderepository();
        }


        [HttpGet("Listar")]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Habilidade cadastrarHabilidade)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Cadastrar(cadastrarHabilidade);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizado)
        {
            // Faz a chamada para o método
            _habilidadeRepository.Atualizar(id, habilidadeAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpGet("TiposHabilidades")]
        public IActionResult GetGames()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarTodos());
        }

    }
}
