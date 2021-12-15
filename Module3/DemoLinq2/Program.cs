// See https://aka.ms/new-console-template for more information
Console.WriteLine("Requètes Linq WHERE & DISTINCT.");
Console.WriteLine();

var personnes = new List<Personne>
{
    new Personne { Age = 99, Nom = "Gerald de Riv"},
    new Personne { Age = 87, Nom = "Aragorn"},
    new Personne { Age = 210, Nom = "Drizzt Do'Urden"},
    new Personne { Age = 38, Nom = "Eddard Stark"},
    new Personne { Age = 42, Nom = "Ulfric Sombrage"},
    new Personne { Age = 38, Nom = "Markus Kruber"},
};

// Affichage des personnes
foreach(var personne in personnes)
{
    Console.WriteLine($"Nom = {personne.Nom}, Age = {personne.Age}");
}
Console.WriteLine(); // Ligne vide

// On affiche la liste des personnes de moins de 50 ans
Console.WriteLine("Les personnes ayant moins de 50 ans: ");
var moinsDeCinquante = personnes.Where(p => p.Age < 50);
foreach (var personne in moinsDeCinquante)
{
    Console.WriteLine($"Nom = {personne.Nom}, Age = {personne.Age}");
}

// On veut la liste des ages uniques, donc on exclue les doublons
var agesUniques = personnes.Select(p => p.Age).Distinct();
Console.WriteLine();
Console.WriteLine("Ages uniques: ");
foreach (var age in agesUniques)
{
    Console.WriteLine(age);
}

// Affichage des trois premiers
var troisPremiers = personnes.Take(3).ToList();
Console.WriteLine();
Console.WriteLine("Les trois premiers: ");
foreach(var personne in troisPremiers)
{
    Console.WriteLine($"Nom = {personne.Nom}, Age = {personne.Age}");
}
Console.ReadKey();

// Soit une classe PERSONNES
public class Personne
{
    public int Age { get; set; }
    public string Nom { get; set; }
}