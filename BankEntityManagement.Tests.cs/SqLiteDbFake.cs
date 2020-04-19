using BankEntityManagement.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankEntityManagement.Tests.cs
{
    public class SqLiteDbFake
    {
        private DbContextOptions<BankEntityManagementContext> options;

        public SqLiteDbFake()
        {
            options = GetDbContextOptions;
        }

        public BankEntityManagementContext GetDbContext()
        {
            var context = new BankEntityManagementContext(options);
            // Crea y abre el 'schema' en la base de datos
            context.Database.EnsureCreated();
            return context;
        }

        private DbContextOptions<BankEntityManagementContext> GetDbContextOptions
        {
            get
            {
                // La BD in-memory solo existe cuando la conexión está abierta
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                var options = new DbContextOptionsBuilder<BankEntityManagementContext>()
                        .UseSqlite(connection)
                        .Options;

                return options;
            }
        }
    }
}
