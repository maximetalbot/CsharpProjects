using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierSite.Models;

namespace PremierSite.Controllers
{
    public class PersonneController : Controller
    {
        // Mauvaise pratique, juste pour les besoins de la démonstration
        // on simule la persistance d'une bdd
        static List<Personne> personnes;

        public PersonneController()
        {
            if (personnes == null)
            {
                personnes = new List<Personne>
                {
                    new Personne {Id = 1, Age = 20, Nom = "LUPINE", Prenom = "Arthur"},
                    new Personne {Id = 2, Age = 25, Nom = "ROGNE", Prenom = "Yves"},
                    new Personne {Id = 3, Age = 30, Nom = "PACCIO", Prenom = "Oscar"},
                    new Personne {Id = 3, Age = 35, Nom = "NICOUETTE", Prenom = "Sandra"}
                };
            }
            
        }

        // GET: PersonneController
        public ActionResult Index()
        {
            return View(personnes);
        }

        // GET: PersonneController/Details/5
        public ActionResult Details(int id)
        {
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                // Si la personne don l'ID est trouvé, on affiche son détail
                return View(personne);
            }
            // Si la vue est nulle, retour à l'index
            return RedirectToAction("Index");
        }

        // GET: PersonneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonneController/Create
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

        // GET: PersonneController/Edit/5
        public ActionResult Edit(int id)
        {
            // Action qui va nous renvoyer le formulaire
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                // Si la personne don l'ID est trouvé, on affiche son détail
                return View(personne);
            }
            // Si la vue est nulle, retour à l'index
            return RedirectToAction("Index");
        }

        // POST: PersonneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personne personne)
        {
            // Au click sur SAVE, l'objet personne est reconstitué à partir du formulaire, les valeurs sont les mêmes mais ce n'est pas le même objet. Copie temporaire.
            try
            {
                if (ModelState.IsValid)
                {
                    // Existe-t-il deja une personne ayant le même nom et prénom mais ID différent
                    if(personnes.Any(p => p.Nom.ToUpper() == personne.Nom.ToUpper() &&
                    p.Prenom.ToUpper() == personne.Prenom.ToUpper() && personne.Id != p.Id))
                    {
                        ModelState.AddModelError("", "Il éxiste deja une personne portant ce nom et ce prénom.");
                        return View();
                    }
                    var personneDb = personnes.FirstOrDefault(p => p.Id == personne.Id);
                    // On met à jour les valeures
                    personneDb.Nom = personne.Nom;
                    personneDb.Prenom = personne.Prenom;
                    personneDb.Age = personne.Age;

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonneController/Delete/5
        public ActionResult Delete(int id)
        {
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                // Si la personne don l'ID est trouvé, on affiche son détail
                return View(personne);
            }
            // Si la vue est nulle, retour à l'index
            return RedirectToAction("Index");
        }

        // POST: PersonneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var personne = personnes.FirstOrDefault(p => p.Id == id);
                personnes.Remove(personne);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
