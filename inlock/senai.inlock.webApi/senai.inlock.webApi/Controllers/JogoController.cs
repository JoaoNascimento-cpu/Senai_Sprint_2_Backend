using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> ListaJogos = _jogoRepository.Listar();

            return Ok(ListaJogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            JogoDomain JogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (JogoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum jogo encontrado!");
            }

            // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(JogoBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
        {
            // Cria um objeto usuarioBuscado que irá receber o usuario buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (jogoBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Jogo não encontrado!",
                            erro = true
                        }
                    );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _jogoRepository.Atualizar(id, jogoAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _jogoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
