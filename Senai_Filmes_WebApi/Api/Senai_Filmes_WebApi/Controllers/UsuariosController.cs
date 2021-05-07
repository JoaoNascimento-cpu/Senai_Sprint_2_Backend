using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using Senai_Filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController() 
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// método que irá procurar os dados fornecidos
        /// </summary>
        /// <param name="login"> objeto que irá receber o e-mail e senha do usuário</param>
        /// <returns>Um Status Code e, em caso de sucesso, os dados do usuário buscado</returns>
        
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

            //caso encontre prossegue a criação do token
            //Define os dados que serão fornecidos no Token - Payload
            var claims = new[]
            {
                //TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                new Claim("Claim Personalizada", "Valor Teste")              
            };

            //chave de acesso ao Token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticação"));

            //Define as credenciais do token- Header
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //gera token
            var token = new JwtSecurityToken
                (
                    issuer      : "Filmes.WebApi",      //definindo o emissor do token
                    audience    : "Filmes.WebApi",      //destinatário do token
                    claims      : claims,               //dados definidos na linha 47
                    expires     : DateTime.Now.AddMinutes(30), //tempo de expiração
                    signingCredentials : cred           //credenciais do token    
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
