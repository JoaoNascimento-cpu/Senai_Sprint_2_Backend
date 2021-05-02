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

        [HttpGet]
        public IActionResult Get() 
        {
            List<FuncionarioDomain> funcionarios = _funcionarioRepository.ListarTodos();
            return Ok(_funcionarioRepository.ListarTodos());   
        }
    }
}
