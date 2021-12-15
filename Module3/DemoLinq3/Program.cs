// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var listeDeRues = new List<Rue>
{
    new Rue{Nom = "Rue du calvaire", Numero = 18},
    new Rue{Nom = "Rue du calvaire", Numero = 1},
    new Rue{Nom = "Rue Gay Lussac", Numero = 6},
    new Rue{Nom = "Rue Gay Lussac", Numero = 4},
    new Rue{Nom = "Rue Desjardins", Numero = 2},
};

// Tri par le nom
var orderedByNames = listeDeRues.OrderBy(r => r.Nom);
Console.WriteLine("Liste des rues triées sur le nom: ");
foreach (var rue in orderedByNames)
{
    Console.WriteLine($"Nom = {rue.Nom}, Numéro = {rue.Numero}");
}

// Tri par ordre décroissant sur le numéro
var orderedByNumberDescending = listeDeRues.OrderByDescending(r=>r.Numero);
Console.WriteLine();
Console.WriteLine("Liste des rues triées sur le numéro décroissant: ");
foreach (var rue in orderedByNumberDescending)
{
    Console.WriteLine($"Nom = {rue.Nom}, Numéro = {rue.Numero}");
}

// Tri les rues de même nom par ordre croissant de leur numéro
var orderedStreet = listeDeRues.OrderBy(r => r.Nom).ThenBy(r=>r.Numero);
Console.WriteLine();
Console.WriteLine("Liste des rues triées sur le nom par numéro croissant: ");
foreach (var rue in orderedStreet)
{
    Console.WriteLine($"Nom = {rue.Nom}, Numéro = {rue.Numero}");
}
Console.WriteLine();

// Tests sur les collections
// Vérifions si tous les numéros de rue sont inférieurs à 50 (ALL)
if (listeDeRues.All(r => r.Numero < 50))
{
    Console.WriteLine("Les numéros sont tous inférieurs à 50");
};
Console.WriteLine();

// Vérifions s'il y'a au moins une rue comprise entre 10 et 20 (ANY)
if (listeDeRues.Any(r => r.Numero < 20 && r.Numero >= 10))
{
    Console.WriteLine("Il y'a au moins une rue comprise entre 10 et 20");
};
Console.WriteLine();

// Retrouvons la liste des noms de rue uniques (SELECT)
var rueUnique = listeDeRues.Select(r => r.Nom).Distinct().OrderBy(s=>s);
Console.WriteLine("Les noms de rue uniques sont: ");
foreach (var nom in rueUnique)
{
    Console.WriteLine($"Nom = {nom}");
}
Console.WriteLine();

// (SELECT MANY)
var appartements = new List<Appartement>
{
    new Appartement
    {
        Numero = 1,
        Pieces = new List<Piece>
        {
            new Piece{ Surface = 5, TypePiece = "Cuisine" },
            new Piece{ Surface = 15, TypePiece = "Salon" },
            new Piece{ Surface = 10, TypePiece = "Chambre" }
        }
    },
    new Appartement
    {
        Numero = 2,
        Pieces = new List<Piece>
        {
            new Piece{ Surface = 4, TypePiece = "Cuisine" },
            new Piece{ Surface = 16, TypePiece = "Salon" },
            new Piece{ Surface = 8, TypePiece = "Chambre" }
        }
    },
    new Appartement
    {
        Numero = 3,
        Pieces = new List<Piece>
        {
            new Piece{ Surface = 6, TypePiece = "Cuisine" },
            new Piece{ Surface = 14, TypePiece = "Salon" },
            new Piece{ Surface = 12, TypePiece = "Chambre" }
        }
    },
    new Appartement
    {
        Numero = 3,
        Pieces = new List<Piece>
        {
            new Piece{ Surface = 10, TypePiece = "Cuisine" },
            new Piece{ Surface = 20, TypePiece = "Salon" },
            new Piece{ Surface = 5, TypePiece = "Chambre" }
        }
    }
};

var pieces = appartements.SelectMany(a => a.Pieces);
Console.WriteLine("Voici la liste de toutes les pieces des appartements: ");
foreach (var piece in pieces)
{
    Console.WriteLine($"Piece de type {piece.TypePiece} de surface {piece.Surface}");
}


Console.ReadKey();
// Classes
public class Rue
{
    public string Nom { get; set; }
    public int Numero { get; set; }
}

public class Appartement
{
    public int Numero { get; set; }
    public List<Piece> Pieces { get; set; }
}

public class Piece
{
    public string TypePiece { get; set; }
    public int Surface { get; set; }
}