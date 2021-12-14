// See https://aka.ms/new-console-template for more information
public class Carre : Forme
{
    public int Longueur { get; set; }

    public override double Aire => Longueur * Longueur;

    public override double Perimetre => Longueur * 4;
    public override string ToString()
    {
        return $"Carré de longueur {Longueur}" + Environment.NewLine + base.ToString();
    }
}