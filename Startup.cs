using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Clinica
{
    public class Startup
    {
        readonly string MyAngular = "_myAngular";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Contexto y Conexión DB
            services.AddDbContext<HospitalDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("HospitalDB")));

            //Esto es una prueba
            services.AddCors(c => c.AddPolicy("AllowOrigin", (opt => opt.AllowAnyOrigin())));
            services.AddCors(c => c.AddPolicy("AllowMethod", (opt => opt.AllowAnyMethod())));
            services.AddCors( options=> {
                options.AddDefaultPolicy(builder => { 
                                                    builder.WithOrigins("http://localhost:4200")
                                                   .AllowAnyMethod();  
                                                   });
            });


            /*services.AddControllers();*/

            services.AddMvc().AddJsonOptions(ConfigureJson)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void ConfigureJson(MvcJsonOptions opt) {
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Esto es una prueba
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseCors(options => options.AllowAnyMethod());
            app.UseCors();
            //app.UseCors(MyAngular);

            app.UseMvc();
        }
    }
}
