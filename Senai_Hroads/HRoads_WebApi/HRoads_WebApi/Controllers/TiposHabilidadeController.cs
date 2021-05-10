using HRoads_WebApi.Domains;
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
    public class TiposHabilidadeController : ControllerBase
    {
        private TiposHabilidadeRepository _tipoHabilidadeRepository { get; set; }


        public TiposHabilidadeController()
        {
            _tipoHabilidadeRepository = new TiposHabilidadeRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(TiposHabilidade cadastrarTipoHabilidade)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.Criar(cadastrarTipoHabilidade);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposHabilidade tipoHabilidadeAtualizado)
        {
            // Faz a chamada para o método
            _tipoHabilidadeRepository.AtualizarIdUrl(id, tipoHabilidadeAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpGet("{Habilidade}")]
        public IActionResult GetHabilidades()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoHabilidadeRepository.ListarHabilidades());
        }
    }
}
