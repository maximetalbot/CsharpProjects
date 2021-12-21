using BO;

namespace Pizzas.Models
{
    public class PizzaVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        // Pour récupérer le contenu des listes
        public List<Pate> Pates { get; set; } = new List<Pate>();
        public int SelectionPate { get; set; }
        public List<int> SelectionIngredients { get; set; }

    }
}
