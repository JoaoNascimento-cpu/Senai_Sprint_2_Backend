using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
            //uso de controllers
            services.AddControllers();


            services
                //Define a forma de atuentica��o 'JwtBEarer'
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //Define os parametros e valida��o do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //valida quem est� emitindo
                        ValidateIssuer = true,

                        //valida quem est� recebendo
                        ValidateAudience = true,

                        //valida o tempo de expira��o
                        ValidateLifetime = true,

                        //forma criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autentica��o")),

                        //tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //nome do issuer, de onde est� vindo
                        ValidIssuer = "Filmes.WebApi",

                        //nome do audience, para onde est� indo
                        ValidAudience = "Filmes.WebApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //habilita a autentica��o
            app.UseAuthentication();

            //habilita a autoriza��o
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //define o mapeamento dos controllers
                endpoints.MapControllers();              
            });
        }
    }
}
