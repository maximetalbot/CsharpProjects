// See https://aka.ms/new-console-template for more information
Console.WriteLine("Functions.");

var JoursAvantNoel = new Func<DateTime, int>(date =>
{
    var noel = new DateTime(date.Year, 12, 25);
    if (noel < date)
    {
        // Si noel n'est aps inferieur à la date, alors noel est après la date
        noel = noel.AddYears(1);
    }
    return (noel - date).Days;
});

var days = JoursAvantNoel(DateTime.Now);
var dateFinAnnee = new DateTime(DateTime.Now.Year, 12, 31);
Console.WriteLine($"Lenombre de jours avant Noël à partir d'aujourd'hui est de: {days}");
Console.WriteLine($"Lenombre de jours avant Noël à partir du 31 décembre prochain: {JoursAvantNoel(dateFinAnnee)}");

// Action, plus dynamique
var actionJoursAvantNoel = new Action<DateTime>(date =>
{
    var noel = new DateTime(date.Year, 12, 25);
    if (noel < date)
    {
        // Si noel n'est aps inferieur à la date, alors noel est après la date
        noel = noel.AddYears(1);
    }
    Console.WriteLine($"Lenombre de jours avant Noël à partir du {date.ToShortDateString()} est de: {days} jours.");
});
actionJoursAvantNoel(DateTime.Now);

Console.ReadKey();