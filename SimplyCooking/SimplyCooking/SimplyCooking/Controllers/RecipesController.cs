using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyCooking.Models;
using System.IO;

namespace SimplyCooking.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private readonly DbContext db = new DBContext();

        public int UploadImageInDataBase(HttpPostedFileBase file, Photo photo)
        {
            photo.Image = ConvertToBytes(file);

            db.Photo.Add(photo);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        // GET: Recipes
        public ActionResult Index(string searchString)
        {
            
            var recipes = from m in db.Recipe
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.Contains(searchString));
            }

            return View(recipes.ToList());

        }

        public ActionResult Search(string searchString)
        {
            var recipes = from m in db.Recipe
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.Contains(searchString));
            }

            return View(recipes);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeDetailsViewModel recipeVM = new RecipeDetailsViewModel
            {
                Recipe = db.Recipe.Find(id)
            };
            if (recipeVM.Recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipeVM);
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photo model, int recipeId)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            //int recipeId = Convert.ToInt32(Request.Files["RecipeId"]);
            model.RecipeId = recipeId;

            int i = UploadImageInDataBase(file, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,UserID,Name,Description,TypeofdishesID,TypeofmealsID")] Recipe recipe, Photo photo)
        {
           
            if (ModelState.IsValid)
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", recipe.UserID);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", recipe.UserID);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,UserID,Name,Description,TypeofdishesID,TypeofmealsID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", recipe.UserID);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] image = GetImageFromDataBase(id);
            if(image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int id)
        {
            var q = from temp in db.Photo where temp.PhotoId == id select temp.Image;
            byte[] image = q.First();
            return image;
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


        


