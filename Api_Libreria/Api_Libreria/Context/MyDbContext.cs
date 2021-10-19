using Api_Libreria.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Libreria.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        // relacion de entidades
        public DbSet<LibroEntity> Libros { get; set; }
        public DbSet<CiudadEntity> Ciudades { get; set; }
        public DbSet<AutorEntity> Autores { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory
           = LoggerFactory.Create(builder =>
           {
               builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Debug)
               .AddConsole();
           });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
               .UseLoggerFactory(ConsoleLoggerFactory);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");

            //modelBuilder.Entity<LibroEntity>().ToTable("LIBRO")
            //    .HasKey(r => r.Id).HasName("ID");




            base.OnModelCreating(modelBuilder);
        }
    }
}
