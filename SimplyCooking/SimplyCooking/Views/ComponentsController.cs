using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyCooking.Models;

namespace SimplyCooking.Views
{
    public class ComponentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Components
        public ActionResult Index()
        {
            var component = db.Component.Include(c => c.Recipe);
            return View(component.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                throw new HttpException(404, "Not found");
            }
            return View(component);
        }

        // GET: Components/Create
        public ActionResult Create()
        {
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "UserID");
            return View();
        }

        // POST: Components/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComponentID,RecipeID")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Component.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "UserID", component.RecipeID);
            return View(component);
        }

        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                throw new HttpException(404, "Not found");
            }
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "UserID", component.RecipeID);
            return View(component);
        }

        // POST: Components/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComponentID,RecipeID")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "UserID", component.RecipeID);
            return View(component);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                throw new HttpException(404, "Not found");
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Component.Find(id);
            db.Component.Remove(component);
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
