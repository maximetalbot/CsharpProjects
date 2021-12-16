namespace PremierSite.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string MoyenDeLocomotion { get; set; }
        public List<string> Sports { get; set; }
    }
}
