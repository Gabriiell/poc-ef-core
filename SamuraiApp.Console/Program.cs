using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurai();
            //InsertMultipleObjects();
            SimpleQuerySamurais();

            System.Console.ReadKey();
        }

        private static void SimpleQuerySamurais()
        {
            using (var context = new SamuraiContext())
            {
                context.Samurais
                    .ToList()
                    .ForEach(s => System.Console.WriteLine(s.Name));
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai
            {
                Name = "Pepe"
            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurai()
        {
            var samurais = new List<Samurai>()
            {
                new Samurai
                {
                    Name = "batch pepe 1"
                },
                new Samurai
                {
                    Name = "batch pepe 2"
                }
            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurais);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleObjects()
        {
            var samurai = new Samurai
            {
                Name = "Pepe de la batalla"
            };

            var battle = new Battle
            {
                Name = "Super battle de pepe",
                StartDate = new DateTime(1575, 1, 1),
                EndDate = new DateTime(1575, 2, 2)
            };

            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }
    }
}
