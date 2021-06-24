using System;
using System.Linq;
using EFCore.UDF.Functions;

namespace EFCore.UDF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();            
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Pessoas.Add(new Pessoa {
                Nome = "João Maria José da Silva"
            });

            db.SaveChanges();

            var result = db.Pessoas.Select(x => CustomFunctions.Len(x.Nome));

            foreach(var len in result)
            {
                Console.WriteLine("Tamanho do nome:" + len);
            }
        }
    }
}
