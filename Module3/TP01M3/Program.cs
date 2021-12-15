// See https://aka.ms/new-console-template for more information
using System.Linq;
using TP01M3;
Console.WriteLine("Réalisation de différentes statistiques sur un jeu de donnée au moyen de requêtes Linq.");
Console.WriteLine();
Datas.InitialiserDatas();

var listeAuteurs = Datas.ListeAuteurs;
var listeLivres = Datas.ListeLivres;

// Afficher la liste des prénoms des auteurs dont le nom commence par "G"
Console.WriteLine("1 - Liste des prénoms des auteurs dont le nom commence par G: ");
var commencentParG = listeAuteurs.Where(a => a.Nom.StartsWith('G'));
foreach(var auteur in commencentParG)
{
    Console.WriteLine(auteur.Prenom);
}
Console.WriteLine();

// Afficher l auteur ayant écrit le plus de livres
var auteurMax = listeLivres.GroupBy(l => l.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
Console.WriteLine($"2 - Auteur ayant écrit le plus de livres: {auteurMax.Prenom} {auteurMax.Nom}");
Console.WriteLine();

// Afficher le nombre moyen de pages par livre par auteur
Console.WriteLine("3 - Nombre moyen de pages par livres et par auteur: ");
var livresParAuteur = listeLivres.GroupBy(l => l.Auteur);
foreach (var item in livresParAuteur)
{
    Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} moyennes des pages={item.Average(l => l.NbPages)}");
}
Console.WriteLine();

// Afficher le titre du livre avec le plus de pages
var nbPagesMax = listeLivres.OrderByDescending(a=>a.NbPages).FirstOrDefault();
Console.WriteLine($"4 - Livre ayant le plus de pages: {nbPagesMax.Titre} avec {nbPagesMax.NbPages} pages.");
Console.WriteLine();

// Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
var moyenneFactures = listeAuteurs.Average(a => a.Factures.Sum(l => l.Montant));
Console.WriteLine($"5 - Moyenne des factures par auteur: {moyenneFactures}");
Console.WriteLine();

// Afficher les auteurs et la liste de leurs livres
Console.WriteLine("6 - Livres par auteurs: ");
var auteurs = listeLivres.GroupBy(l => l.Auteur);
foreach (var auteur in auteurs)
{
    Console.WriteLine($"{auteur.Key.Prenom} {auteur.Key.Prenom} a écrit :");
    var livres = auteur.Select(l => l.Titre);
    foreach (var livre in livres)
    {
        Console.WriteLine($" - {livre}.");
    }
}
Console.WriteLine();

// Afficher les titres de tous les livres triés par ordre alphabétique
// solution optimale:  ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList().ForEach(Console.WriteLine);
Console.WriteLine("7 - Livres par ordre alphabétique: ");
var livresParOrdre = listeLivres.OrderBy(l => l.Titre);
foreach (var livre in livresParOrdre)
{
    Console.WriteLine(livre.Titre);
}
Console.WriteLine();

// Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
var moyPages = listeLivres.Average(l => l.NbPages);
Console.WriteLine($"8 - Livres qui ont plus de pages que la moyenne ({moyPages}): ");
var livresSelect = listeLivres.Where(l => l.NbPages > moyPages).OrderByDescending(a=>a.NbPages);
foreach (var livre in livresSelect)
{
    Console.WriteLine($"{livre.Titre} qui a {livre.NbPages}");
}
Console.WriteLine();

// Afficher l'auteur ayant écrit le moins de livres
var auteurMin = listeAuteurs.OrderBy(a => listeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
Console.WriteLine($"9 - Auteur ayant écrit le plus de livres: {auteurMin.Prenom} {auteurMin.Nom}");
Console.WriteLine();

Console.ReadLine();