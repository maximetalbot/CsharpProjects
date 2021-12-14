using static MethodeExtension.Extension;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Méthodes d'extensions.");

int a = 10;
Console.WriteLine($"Est-ceque {a} est pair ? Réponse: {a.EstPair()}");
Console.ReadKey();

var chaine = "iL fAit BeAu AujOurd'HuI.";
Console.WriteLine(chaine.PremiereLettreMaj());
Console.ReadKey();