using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDbContext2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            foreach (var personne in context.Personnes)
            {
                Console.WriteLine($"Nom: {personne.Nom}, Prenom: {personne.Prenom}");
            }
            if (!context.Personnes.Any())
            {
                context.Personnes.Add(new Personne { Nom = "TRUMP", Prenom = "Donald" });
                context.SaveChanges();
                Console.WriteLine("Une personne ajoutée.");
            }
            Console.ReadKey();
        }
    }
}
