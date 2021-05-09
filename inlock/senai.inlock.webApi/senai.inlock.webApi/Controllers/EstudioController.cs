using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
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
    public class EstudioController : ControllerBase
    {
        private EstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// esse método irá listar os estudios que serão armazenados no objeto
        /// </summary>
        /// <returns>Lista de estudios</returns>
        /// http://Locallhost:5000/api/Estudio
        [HttpGet]
        public IActionResult Listar() 
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.Listar();

            return Ok(listaEstudios);
        }
        /// <summary>
        /// esse método busca o estudio a partir do id pela url
        /// </summary>
        /// <param name="id">id do estudio</param>
        /// <returns>estudio buscado no id</returns>
        ///http://Locallhost:5000/api/Estudio/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estudio foi encontrado");

            }
            return Ok(estudioBuscado);
        }
    }
}
