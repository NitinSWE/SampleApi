using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using sampleapi.Data;
using Newtonsoft.Json.Serialization;

namespace sampleapi
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
            //DB Config
            services.AddDbContext<TestContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                //Config For Patch Operation
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            //services.AddScoped<IfcTestRepo, MockTestRepo>();
            services.AddScoped<IfcTestRepo, SqlTestRepo>();
            services.AddScoped<IQuestionBankRepo, SqlQuestionBankRepo>();
            //Automapper for Dto
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>{
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
