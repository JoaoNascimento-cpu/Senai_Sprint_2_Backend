using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peoples_WebApi.Domains;
using Peoples_WebApi.Interfaces;
using Peoples_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private IFuncuinarioRepository _funcionarioRepository;
        public FuncionarioController() 
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Lista todos os funcionários cadastrados
        /// </summary>
        /// <returns>Lista de Funcionarios</returns>
        /// http://LocalHost:5000/api/Funcionario
        [HttpGet]
        public IActionResult Get() 
        {
            List<FuncionarioDomain> funcionarios = _funcionarioRepository.ListarTodos();
            return Ok(_funcionarioRepository.ListarTodos());   
        }

        /// <summary>
        /// Cadastra um novo funcionário na lista
        /// </summary>
        /// <param name="novoFuncionario">Objeto que irá receber as informações do novo usuário</param>
        /// <returns></returns>
        /// http://LocalHost:5000/api/funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario) 
        {
            //
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta o funcionario passando o id pela Url
        /// </summary>
        /// <param name="id">objeto que irá receber o id</param>
        /// <returns></returns>
        /// http://LocalHost:5000/api/funcionarios/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _funcionarioRepository.Delete(id);

            return StatusCode(204);
        }


    }
}
