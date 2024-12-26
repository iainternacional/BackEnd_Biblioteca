using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Biblioteca.BackEnd.Infrastructure.Data.EntityFramework
{
    public class BibliotecaDBContext : DbContext
    {
        public BibliotecaDBContext() { }

        public BibliotecaDBContext(DbContextOptions<BibliotecaDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //var serviceProvider = ((IInfrastructure<IServiceProvider>)this).Instance;
                //var config = this.GetService<IConfigurationRoot>();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                var servidorbd = Environment.GetEnvironmentVariable("servidorbd");
                var usuariobd = Environment.GetEnvironmentVariable("usuariobd");
                var clavebd = Environment.GetEnvironmentVariable("clavebd");

                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .Build();


                // define the database to use
                optionsBuilder.UseSqlServer(string.Format(config["DefaultConnection"], servidorbd, usuariobd, clavebd));
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}