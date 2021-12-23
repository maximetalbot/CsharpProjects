using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using LeDojo.Data;
using LeDojo.Models;

namespace LeDojo.Controllers
{
    public class SamouraisController : Controller
    {
        private Context db = new Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var samouraiVM = new SamouraiVM();
            samouraiVM.ListeArmes = db.Armes.ToList();
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                // on vérifie qu'une arme ai été choisie
                if (samouraiVM.SelectionArme.HasValue)
                {
                    // on assigne l'arme dont l'Id à été choisi au samouraï
                    samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.SelectionArme.Value);
                }
                db.Samourais.Add(samouraiVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samouraiVM.ListeArmes = db.Armes.ToList();
            return View(samouraiVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            var samouraiVM = new SamouraiVM();
            samouraiVM.Samourai = db.Samourais.Find(id);
            samouraiVM.ListeArmes = db.Armes.ToList();
            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM samouraiVM, int id)
        {
            if (ModelState.IsValid)
            {
                if (samouraiVM.SelectionArme.HasValue)
                {
                    samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.SelectionArme.Value);
                }

                var updateSamourai = db.Samourais.Find(id);
                updateSamourai.Nom = samouraiVM.Samourai.Nom;
                updateSamourai.Force = samouraiVM.Samourai.Force;
                updateSamourai.Arme = samouraiVM.Samourai.Arme;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samouraiVM.ListeArmes = db.Armes.ToList();
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
