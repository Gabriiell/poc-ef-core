using Microsoft.EntityFrameworkCore;
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
            //CreateSamuraiWithQuotes();
            //AddQuoteToSamurai();
            //SimpleQuerySamurais();
            //UpdateQuoteDisconnected();
            QueryQuotes();

            System.Console.ReadKey();
        }

        private static void UpdateQuoteDisconnected()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).First();
            var quote = samurai.Quotes.First();

            using (var otherContext = new SamuraiContext())
            {
                quote.Text += " updated disconnected";
                otherContext.Entry(quote).State = EntityState.Modified;
                otherContext.SaveChanges();
            }
        }

        private static void AddQuoteToSamurai()
        {
            var samurai = _context.Samurais.First();
            samurai.Quotes.Add(new Quote
            {
                Text = "quote 3"
            });
            _context.SaveChanges();
        }

        private static void CreateSamuraiWithQuotes()
        {
            var samurai = new Samurai
            {
                Name = "Samurai con frases",
                Quotes = new List<Quote>
                {
                    new Quote
                    {
                        Text = "quote 1"
                    },
                    new Quote
                    {
                        Text = "quote 2"
                    }
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void DeleteSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }

        private static void QueryAndUpdateBattleDisconnected()
        {
            var battle = _context.Battles.First();
            battle.EndDate = battle.EndDate.AddDays(10);

            using (var anotherContext = new SamuraiContext())
            {
                anotherContext.Battles.Update(battle);
                anotherContext.SaveChanges();
            }
        }

        private static void UpdateSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += " San");
            _context.SaveChanges();
        }

        private static void SimpleQuerySamurais()
        {
            _context.Samurais.Include(s => s.Quotes)
                .ToList()
                .ForEach(s =>
                {
                    System.Console.WriteLine(s.Name);
                    s.Quotes.ForEach(q => System.Console.WriteLine("\t" + q.Text));
                });
        }

        private static void QueryQuotes()
        {
            _context.Quotes.Include(q => q.Samurai)
                .ToList()
                .ForEach(q =>
                {
                    System.Console.WriteLine(q.Text);
                });
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
