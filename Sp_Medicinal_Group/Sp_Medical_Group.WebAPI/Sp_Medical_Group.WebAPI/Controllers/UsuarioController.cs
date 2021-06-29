using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sp_Medical_Group.WebAPI.Domains;
using Sp_Medical_Group.WebAPI.Interfaces;
using Sp_Medical_Group.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sp_Medical_Group.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository usuario { get; set; }

        public UsuarioController()
        {
            usuario = new UsuarioRepository();
        }

        [HttpGet]
        //http://5000/api/usuario
        public IActionResult Listar()
        {
            try
            {
                return Ok(usuario.Listar());
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
                return Ok(usuario.BuscarPorId(id));
            }
            catch (Exception excepition)
            {
                return BadRequest(excepition);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            try
            {
                usuario.Cadastro(novoUsuario);
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
                usuario.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario novoUsuario)
        {
            try
            {
                usuario.AtualizarUsuario(id, novoUsuario);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            //Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = usuario.Login(login.Email, login.Senha);

            //caso não encontre nenhum usuário  irá retornar um status code Not Found
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha invalidos");
            }

            //caso encontre prossegue a criação do token
            //Define os dados que serão fornecidos no Token - Payload
            var claims = new[]
            {
                //TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Senha.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.Email),
                new Claim("Claim Personalizada", "Valor Teste")
            };

            //chave de acesso ao Token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SPMG-Usuario-autenticação"));

            //Define as credenciais do token- Header
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //gera token
            var token = new JwtSecurityToken
                (
                    issuer: "Sp_Medical_Group.WebAPI",      //definindo o emissor do token
                    audience: "Sp_Medical_Group.WebAPI",      //destinatário do token
                    claims: claims,               //dados definidos na linha 47
                    expires: DateTime.Now.AddMinutes(30), //tempo de expiração
                    signingCredentials: cred           //credenciais do token    
                );

            //retorna um Status code - 200(OK)

            return Ok
                (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
        }
    }
}
