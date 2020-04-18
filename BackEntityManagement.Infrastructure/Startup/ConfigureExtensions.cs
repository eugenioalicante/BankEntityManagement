using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEntityManagement.Infrastructure.Startup
{
    public static class ConfigureExtensions
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void UseSwagger (this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
