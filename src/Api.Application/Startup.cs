using System;
using CrossCutting.DependencyInjection;
using Domain.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;



namespace Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
       
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);                 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Info
                {
                    Title = "Service - Validate Password",
                    Version = "v1",
                    Description = "Api criada para validação de senha.",
                    Contact = new Contact
                    {
                        Name = "Candidato a Vaga - Thiago Rocco",
                        Url = "thiagomt.rocco@gmail.com"
                    }
                });
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "Projeto em AspNetCore 2.2");
            });
            // Redireciona o Link para o Swagger, quando acessar a rota principal
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);



            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
