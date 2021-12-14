// See https://aka.ms/new-console-template for more information
public class Rectangle : Forme
{
    public int Largeur { get; set; }
    public int Longueur { get; set; }

    public override double Aire => (Largeur * Longueur);

    public override double Perimetre => ((2 * Longueur) + (2 * Largeur));

    public override string ToString()
    {
        return $"Rectangle de largeur {Largeur} et longueur {Longueur}" + Environment.NewLine + base.ToString();
    }
}