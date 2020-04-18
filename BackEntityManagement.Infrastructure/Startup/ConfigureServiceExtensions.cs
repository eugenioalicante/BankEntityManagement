using BackEntityManagement.Repository.Interface;
using BackEntityManagement.Repository.Repository;
using BankEntityManagement.Database.Context;
using BankEntityManagement.Service.Interface;
using BankEntityManagement.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BackEntityManagement.Infrastructure.Startup
{
    public static class ConfigureServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    //Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Description = "JWT Authorization header",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"

                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });                

                c.DescribeAllEnumsAsStrings();
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // Register service                     
            services.AddScoped<IEntityService, EntityService>();

            // Register repository                     
            services.AddScoped<IEntityRepository, EntityRepository>();            
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankEntityManagementContext>();
        }
    }
}
