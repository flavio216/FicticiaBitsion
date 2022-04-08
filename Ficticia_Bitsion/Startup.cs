using Ficticia_Bitsion.Models.Common;
using Ficticia_Bitsion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficticia_Bitsion
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                    builder =>
                    {
                        builder.WithOrigins("*");
                        builder.WithHeaders("*");
                        builder.WithMethods("*");
                    });
            });

            services.AddControllers();

            services.AddScoped<IUserService, UserService>(); // Injectamos

             var appSetingsSection = Configuration.GetSection("AppSettings");
             services.Configure<AppSettings>(appSetingsSection);


             //Creamos el JWT Json Web Token
             var appSettings = appSetingsSection.Get<AppSettings>();
             var token = Encoding.ASCII.GetBytes(appSettings.Secret);
             services.AddAuthentication(d =>
             {
                 d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
                 .AddJwtBearer(d =>
                 {
                     d.RequireHttpsMetadata = false;
                     d.SaveToken = true;
                     d.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(token),
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                 });//Damos de alta en el servicio al jwt


            /* services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "WsVentas", Version = "v1" });
             });*/
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

            app.UseCors(MiCors);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
