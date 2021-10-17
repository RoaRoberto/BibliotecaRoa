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
        public DbSet<LibroEntity> libros { get; set; }

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
            //if (!optionsBuilder.IsConfigured)
            //{

            //    optionsBuilder
            //        .UseLoggerFactory(ConsoleLoggerFactory)
            //        .UseOracle("connection string to test db.");
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
