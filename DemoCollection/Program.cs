// See https://aka.ms/new-console-template for more information
Console.WriteLine("Démonstration d'utilisation des collections.");

var liste = new List<int>(100);
// Affiche le nommbre d'éléments de la liste 
Console.WriteLine("Nombre d'éléments avant ajout: "+liste.Count);
liste.Add(10);
liste.Add(-200);
liste.Add(42);
Console.WriteLine("Nombre d'éléments après ajouts: "+liste.Count);
Console.WriteLine("Capacité maximale: "+liste.Capacity);

var result1 = liste.Contains(3);
var result2 = liste.Contains(42);
Console.WriteLine($"La liste contient le chiffre 3 ? {result1}, le chiffre 42 ? {result2}");

// Enlever un élément
liste.Remove(-200);
// Afficher tous les éléments de la liste
foreach ( var item in liste)
{
    Console.WriteLine(item);
}

Console.ReadKey();