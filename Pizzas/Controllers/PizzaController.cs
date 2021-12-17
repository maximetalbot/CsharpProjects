using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BO;

namespace Pizzas.Controllers
{
    public class PizzaController : Controller
    {
        #region Simulation Persistance Données
        static List<Pizza> pizzas;
        static List<Pate> pates = Pizza.PatesDisponibles;
        static List<Ingredient> ingredients = Pizza.IngredientsDisponibles;
        
        #endregion

        public PizzaController()
        {
            var i = 1;
            Random random = new Random();
            if (pizzas == null)
            {
                pizzas = new List<Pizza> 
                {
                    new Pizza {Id = i++, Nom = "Margherita", Pate = pates[random.Next(1, 4)]},
                    new Pizza {Id = i++, Nom = "Reine", Pate = pates[random.Next(1, 4)]},
                    new Pizza {Id = i++, Nom = "Napolitaine", Pate = pates[random.Next(1, 4)]},
                    new Pizza {Id = i++, Nom = "Calzone", Pate = pates[random.Next(1, 4)]},
                    new Pizza {Id = i++, Nom = "Royale", Pate = pates[random.Next(1, 4)]},
                    new Pizza {Id = i++, Nom = "Veggie", Pate = pates[random.Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Paysanne", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Forestière", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Alsacienne", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Savoyarde", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "L’Angevine", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Di Roma", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Capri", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Ankara", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Oslo", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Hawaï", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Nador", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Cagliari", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Bolzano", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Loguivy", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Ogre", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "London", Pate = pates[new Random().Next(1, 4)]},
                    //new Pizza {Id = i++, Nom = "Liverpool", Pate = pates[new Random().Next(1, 4)]}
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
            var pizza = pizzas[id];
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
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
            if (pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pizza pizza)
        {
            try
            {
                var pizzaDb = pizzas.FirstOrDefault(p => p.Id == pizza.Id);
                // On met à jour les valeures
                pizzaDb.Nom = pizza.Nom;
                pizzaDb.Pate = pizza.Pate;
                pizzaDb.Ingredients = pizza.Ingredients;
                return RedirectToAction(nameof(Index));
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
