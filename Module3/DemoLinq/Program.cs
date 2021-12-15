// See https://aka.ms/new-console-template for more information
Console.WriteLine("Démonstration syntaxique avec LINQ.");

try
{
    var nombres = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };
    var listeVide = new List<int>();

    #region FIRST
    //var premier = nombres.First();
    //Console.WriteLine($"First sur un int: {premier}");

    //premier = listeVide.First();
    //Console.WriteLine($"First sur listeVide: {premier}");
    #endregion

    #region FIRST OR DEFAULT
    var premierFirstOrDefault = nombres.FirstOrDefault();
    Console.WriteLine($"FirstOrDefault sur un int: {premierFirstOrDefault}");

    premierFirstOrDefault = listeVide.FirstOrDefault();
    Console.WriteLine($"FirstOrDefault sur listeVide: {premierFirstOrDefault}");
    #endregion

    #region SINGLE
    //var cinq = nombres.Single(n => n == 5);
    //Console.WriteLine(cinq);

    var trois = nombres.Single(n => n == 3);
    Console.WriteLine(trois);

    var zero = listeVide.SingleOrDefault();
    Console.WriteLine(zero);
    #endregion
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();