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
            InsertSamurai();
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //System.Console.WriteLine("Hello World!");
            //System.Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
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
    }
}
