// See https://aka.ms/new-console-template for more information
public class Triangle : Forme
{
    private int p;

    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }

    public override double Aire => Math.Sqrt(p * (p - A) * (p - B) * (p - C));

    public override double Perimetre => A + B + C;

    public override string ToString()
    {
        return $"Triangle de coté A={A}, B={B}, C={C}" + Environment.NewLine + base.ToString();
    }
}