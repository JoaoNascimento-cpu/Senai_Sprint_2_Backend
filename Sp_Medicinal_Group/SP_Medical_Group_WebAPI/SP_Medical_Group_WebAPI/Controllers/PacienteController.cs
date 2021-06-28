using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Group_WebAPI.Domains;
using SP_Medical_Group_WebAPI.Interface;
using SP_Medical_Group_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPaciente_Repository paciente { get; set; }

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
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
