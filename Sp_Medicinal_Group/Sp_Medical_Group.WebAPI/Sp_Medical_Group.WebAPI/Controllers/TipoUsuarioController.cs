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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository tipoUsuario { get; set; }

        public TipoUsuarioController()
        {
            tipoUsuario = new TipoUsuarioRepository();
        }

        [HttpGet]
        //http://5000/api/TipoUsuario
        public IActionResult Listar()
        {
            try
            {
                return Ok(tipoUsuario.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpGet("{id}")]
        //http://5000/api/usuario
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(tipoUsuario.BuscarPorId(id));
            }
            catch (Exception excepition)
            {
                return BadRequest(excepition);
            }
        }

        [HttpPost]
        public IActionResult Cadastro(TipoUsuario novoTipoUsuario)
        {
            try
            {
                tipoUsuario.Cadastro(novoTipoUsuario);
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
                tipoUsuario.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario novoUsuario)
        {
            try
            {
                tipoUsuario.Atualizar(id, novoUsuario);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
