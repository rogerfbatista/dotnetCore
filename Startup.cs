using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catagoloproduto.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace catagoloproduto
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ContratoProcedimentoDados,ContratoProcedimentoDados>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
              var listaOrigem = new List<string>();
              listaOrigem.Add("http://localhost:4200");
              listaOrigem.Add("http://192.168.0.117");

              

             app.UseCors(b=> b.WithOrigins(listaOrigem.ToArray()));
                app.UseMvc();
                
                
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
        }
    }
}
