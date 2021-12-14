// See https://aka.ms/new-console-template for more information
using DemoGenerique;

Fourmi fourmi = new Fourmi();
//Date du jour - 5 jours
Fruit fruit = new Fruit { DateCueillette = DateTime.Now.AddDays(-5) };
Zoo.NourrirAnimal(fourmi, fruit);

Chat chat = new Chat();
Pate pate = new Pate { DatePeremption = DateTime.Now.AddYears(1) };
Zoo.NourrirAnimal(chat, pate);

Console.ReadKey();