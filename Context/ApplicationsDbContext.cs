using System;
using System.Linq;
using EFCore.UDF.Functions;
using Microsoft.EntityFrameworkCore;

namespace EFCore.UDF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=localhost;Database=Teste-01;Integrated Security=True;")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var functions = typeof(CustomFunctions).GetMethods()
                                .Where(x => Attribute.IsDefined(x, typeof(DbFunctionAttribute)));
                                
            foreach (var func in functions)
            {
                modelBuilder.HasDbFunction(func);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}