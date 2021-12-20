using BO;

namespace Pizzas.Models
{
    public class PizzaVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        //public List<SelectListItem> ListItems { get; set; } = new List<SelectListItem>();

        //public void Generate_SelectListItem(List<Pizza> pList) => pList.ForEach(p => ListItems.Add(new SelectListItem { Text = p.Ingredients., Value = p.Id.ToString() }));
    }
}
