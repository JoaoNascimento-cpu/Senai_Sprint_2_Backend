using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Medical_Group.WebAPI.Domains;
using Sp_Medical_Group.WebAPI.Interfaces;
using Sp_Medical_Group.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository paciente { get; set; }

        public PacienteController()
        {
            paciente = new PacienteRepository();
        }

        //http://5000/api/paciente
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(paciente.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("todos")]
        public IActionResult ListarTudo()
        {
            try
            {
                return Ok(paciente.ListarTudo());
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        public IActionResult Cadastro(Paciente novoPaciente)
        {
            try
            {
                paciente.Cadastrar(novoPaciente);
                return StatusCode(201);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                paciente.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Paciente novoPaciente)
        {
            try
            {
                paciente.Atualizar(id, novoPaciente);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
