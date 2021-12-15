using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierSite.Models;

namespace PremierSite.Controllers
{
    public class PersonneController : Controller
    {
        // GET: PersonneController
        public ActionResult Index()
        {
            var personnes = new List<Personne>
            {
                new Personne {Id = 1, Age = 20, Nom = "LUPINE", Prenom = "Arthur"},
                new Personne {Id = 2, Age = 25, Nom = "ROGNE", Prenom = "Yves"},
                new Personne {Id = 3, Age = 30, Nom = "PACCIO", Prenom = "Oscar"},
                new Personne {Id = 3, Age = 35, Nom = "NICOUETTE", Prenom = "Sandra"}
            };
            return View(personnes);
        }

        // GET: PersonneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: PersonneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PersonneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
