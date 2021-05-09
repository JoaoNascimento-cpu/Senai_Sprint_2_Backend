using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost()]
        public IActionResult Cadastro(UsuarioDomain novoUsuario) 
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return Ok(201);
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            //Busca o usuário pelo e-mail e senha
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            //caso não encontre nenhum usuário  irá retornar um status code Not Found
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha invalidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                new Claim("Claim Personalizada", "Valor teste")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "senai.inlock.webApi",
                    audience: "senai.inlock.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials : creds
                );

            return Ok
                (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
        }

        [HttpPut]
        public IActionResult AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            //Cria um objeto generoBuscado que ira receber  o gênero buscado no BD
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(usuarioAtualizado.idTipoUsuario);

            if (usuarioBuscado != null)
            {
                try
                {
                    //faz a chamada para o método AtualizarIdCorpo
                    _usuarioRepository.AtualizarIdCorpo(usuarioAtualizado);

                    //Retorna statusCode NoContent- 204
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    //retorna statusCode BadRequest com o código de erro
                    return BadRequest(codErro);
                }
            }
            //caso não seja encontrado, retorna um statusCode NotFound com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Usuário não encontrado"
                    }
                );
        }

        [HttpGet("Lista_Usuario")]

        public IActionResult Get()
        {
            List<UsuarioDomain> ListaUsuarios = _usuarioRepository.ListarUsuarios();

            return Ok(ListaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("nenhum usuário foi encontrado");
            }
            else
            {
                return Ok(usuarioBuscado);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) 
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }

        
    }
}
