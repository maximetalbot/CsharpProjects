using DemoGenerique;
using System;

public class Fruit : Nourriture
{
    public DateTime DateCueillette { get; set; }
    public bool EstPerime()
    {
        // L'intervale de temps est-il supérieur à 10 ?
        return (DateTime.Now - DateCueillette).Days > 10;
    }
}
