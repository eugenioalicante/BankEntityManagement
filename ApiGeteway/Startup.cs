using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackEntityManagement.Infrastructure.Startup;
using AutoMapper;
using BankEntityManagement.Service.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BackEntityManagement.Infrastructure.Exceptions;

namespace ApiGeteway
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      RequireExpirationTime = false,
                      ValidateAudience = false,
                      ValidateIssuer = false,
                      IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes("b8d42785-8875-40fd-b8d6-6906c749d0bb")
                       )
                  };
              });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(typeof(DtoMappingProfile));

            services.AddDependencyInjection();

            services.AddSwagger();

            services.AddDbContext(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();
        }        
    }
}
