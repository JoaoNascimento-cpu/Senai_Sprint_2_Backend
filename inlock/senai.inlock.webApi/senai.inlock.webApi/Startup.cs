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

namespace senai.inlock.webApi_
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
            .AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = "JwtBearer";
                 options.DefaultChallengeScheme = "JwtBearer";
             })

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
                     IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao")),

                     //tempo de expira��o do token
                     ClockSkew = TimeSpan.FromMinutes(10),

                     //nome do issuer, de onde est� vindo
                     ValidIssuer = "senai.inlock.webApi",

                     //nome do audience, para onde est� indo
                     ValidAudience = "senai.inlock.webApi"
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

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
