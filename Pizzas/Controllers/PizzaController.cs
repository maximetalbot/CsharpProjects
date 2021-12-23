using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BO;
using Pizzas.Models;
using System.Linq;

namespace Pizzas.Controllers
{
    public class PizzaController : Controller
    {
        #region Simulation Persistance Données
        static List<Pizza> pizzas;
        static List<Pate> pates = Pizza.PatesDisponibles;
        static List<Ingredient> ingredients = Pizza.IngredientsDisponibles;
        #endregion

        // Génération de la liste d'ingrédients aléatoires
        private List<Ingredient> Aleatoire()
        {
            Random random = new Random();
            List<Ingredient> ingredientAleatoire = new List<Ingredient>();
            for (int j = 0; j < random.Next(3, 6); j++)
            {
                ingredientAleatoire.Add(Pizza.IngredientsDisponibles.Find(a => a.Id == random.Next(1, Pizza.IngredientsDisponibles.Count)));
            }
            return ingredientAleatoire;
        }

        public PizzaController()
        {
            var i = 1;
            Random random = new Random();
            if (pizzas == null)
            {
                pizzas = new List<Pizza> 
                {
                    new Pizza {Id = i++, Nom = "Margherita", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Reine", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Napolitaine", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Calzone", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Royale", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Veggie", Pate = pates[random.Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Paysanne", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Forestière", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Alsacienne", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Savoyarde", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "L’Angevine", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Di Roma", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Capri", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Ankara", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Oslo", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Hawaï", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Nador", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Cagliari", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Bolzano", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Loguivy", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Ogre", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "London", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() },
                    new Pizza {Id = i++, Nom = "Liverpool", Pate = pates[new Random().Next(1, 4)], Ingredients = Aleatoire() }
                };
            }
        }


        // GET: PizzaController
        public ActionResult Index()
        {
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            var pizza = pizzas[id-1];
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            // On alimente le VM avec ce que l'on veut afficher dans la vue
            var pizzaVM = new PizzaVM();
            pizzaVM.Pates = pates;
            pizzaVM.Ingredients = ingredients;
            return View(pizzaVM);
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaVM pizzaVM)
        {
            try
            {
                if (pizzaVM != null && ModelState.IsValid)
                {
                    // On créer une pizza vide qu'on va remplir avec les données issues de la VM, identifiés par index
                    var pizzaDb = new Pizza();
                    var listeIngredientsVM = pizzaVM.SelectionIngredients;
                    var pateVM = pates[pizzaVM.SelectionPate];

                    // On remplis une liste d'ingrédients pour chaque valeur d'index retournées par la vue
                    List<Ingredient> listeIngredients = new();
                    foreach (var i in listeIngredientsVM)
                    {
                        listeIngredients.Add(ingredients[i]);
                    }

                    // On remplis la nouvelle pizza vierge
                    pizzaDb.Id = pizzas.Count + 1;
                    pizzaDb.Nom = pizzaVM.Nom;
                    pizzaDb.Pate = pateVM;
                    pizzaDb.Ingredients = listeIngredients;

                    // Et on ajoute la nouvelle pizza à la liste
                    pizzas.Add(pizzaDb);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            List<Ingredient> ListeIngredients = pizza.Ingredients;
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PizzaVM pizzaVM)
        {
            try
            {
                if (pizzaVM != null && ModelState.IsValid)
                {

                    // ***************************************************************
                    var pizzaVM = new PizzaVM();

                    var pizzaDb = pizzas.FirstOrDefault(p => p.Id == pizza.Id);

                    List<Ingredient> ListeIngredients = pizzaVM.Ingredients;

                    pizzaDb.Nom = pizza.Nom;
                    pizzaDb.Pate = pizza.Pate;
                    pizzaDb.Ingredients = pizza.Ingredients;
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            // Si la vue est nulle, retour à l'index
            return RedirectToAction("Index");
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var pizza = pizzas.FirstOrDefault(p => p.Id == id);
                pizzas.Remove(pizza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
