// See https://aka.ms/new-console-template for more information
public class Cercle : Forme
{
    public int Rayon { get; set; }

    public override double Aire => (Rayon * Rayon * Math.PI);

    public override double Perimetre => (Rayon * 2 * Math.PI);
    public override string ToString()
    {
        return $"Cercle de rayon {Rayon}" + Environment.NewLine + base.ToString();
    }
}