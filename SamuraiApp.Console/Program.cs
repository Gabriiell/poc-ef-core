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
        private readonly static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurai();
            //InsertMultipleObjects();
            UpdateSamurais();
            SimpleQuerySamurais();

            System.Console.ReadKey();
        }

        private static void UpdateSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += " San");
            _context.SaveChanges();
        }

        private static void SimpleQuerySamurais()
        {
            _context.Samurais
                .ToList()
                .ForEach(s => System.Console.WriteLine(s.Name));
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai
            {
                Name = "Pepe"
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
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

            _context.Samurais.AddRange(samurais);
            _context.SaveChanges();
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

            _context.AddRange(samurai, battle);
            _context.SaveChanges();
        }
    }
}
