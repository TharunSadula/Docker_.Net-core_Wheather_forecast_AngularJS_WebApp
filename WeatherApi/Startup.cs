using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using WeatherApi.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace WeatherApi
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
            services.AddMvc().AddSessionStateTempDataProvider()
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDbContext<WeatherApiContext>(opt =>
                  opt.UseSqlServer(Configuration.GetConnectionString("WeatherApiContext")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My Weather API",
                    Description = "Api's for historical weather and 7days forecast",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Tharun Sadula", Email = "sadulatn@mail.uc.edu", Url = "https://github.uc.edu/sadulatn/WeatherApi" }
                });
            });

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Weather API V1");
            });
        }
    }
}
