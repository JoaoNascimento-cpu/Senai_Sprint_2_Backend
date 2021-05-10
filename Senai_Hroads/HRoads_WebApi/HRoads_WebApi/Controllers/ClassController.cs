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
    public class ClassController : ControllerBase
    {
        private IClassRepository _classRepository { get; set; }

        public ClassController()
        {
            _classRepository = new ClassRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _classRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Class cadastrarClasse)
        {
            // Faz a chamada para o método
            _classRepository.Cadastrar(cadastrarClasse);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada o método
            return Ok(_classRepository.BuscarPorId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Class classeAtualizado)
        {
            // Faz a chamada para o método
            _classRepository.Atualizar(id, classeAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}
