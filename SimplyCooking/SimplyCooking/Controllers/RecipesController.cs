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

        public bool UploadImageInDataBase(HttpPostedFileBase file, Photo photo)
        {
            photo.Image = ConvertToBytes(file);

            db.Photo.Add(photo);
            int i = db.SaveChanges();

            return true;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        // GET: Recipes
        //[HandleError]
        public ActionResult Index(string searchString, int? id)
        {
            var recipes = from m in db.Recipe
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.Contains(searchString));
            }
            
            if(recipes == null || recipes.Count() == 0)
            {
                throw new HttpException(404, "Not found");
            }
            
            

            return View(recipes.ToList());

        }


        public ActionResult ShowMyRecipes()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = db.Users.FirstOrDefault(x => x.UserName == currentUserName);

            if(currentUser == null)
            {
                throw new HttpException(404, "Not found");
            }

            var recipes = db.Recipe.Where(x => x.UserID == currentUser.Id);

            return View(recipes.ToList());
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
                throw new HttpException(404, "Not found");
            }
            return View(recipeVM);
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photo model, int recipeId)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
        
            model.RecipeId = recipeId;

            bool i = UploadImageInDataBase(file, model);
            if (i == true)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            var vm = new RecipesCreateViewModel
            {
                TypeOfDisches = db.Typeofdish.Select
                (x =>
                   new SelectListItem
                   {
                       Value = x.TypeofdishID.ToString(),
                       Text = x.Type
                   }
                ),

                TypeOfMeals = db.Typeofmeal.Select
                (x =>
                   new SelectListItem
                   {
                       Value = x.TypeofmealID.ToString(),
                       Text = x.Mealstype
                   }
                ),

                Equipment = db.Equipment.Select
                (x =>
                    new SelectListItem
                    {
                        Value = x.EquipmentV2ID.ToString(),
                        Text = x.Equipmentname
                    }
                )
            };
           
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            return View(vm);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,UserID,Name,Description,Components,TypeofdishesID,TypeofmealsID,Time,DifficultyLevel,EquipmentV2ID")] Recipe recipe, Photo photo)
        {
           
            if (ModelState.IsValid)
            {
                var user = db.Users.First(x => x.UserName == HttpContext.User.Identity.Name);
                recipe.UserID = user.Id;
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", recipe.UserID);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Recipe recipe = db.Recipe.Find(id);

            if (recipe == null)
            {
                throw new HttpException(404, "Not found");
            }

            var userId = HttpContext.User.Identity.Name;

            if(userId != recipe.User.UserName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vm = new RecipesEditViewModel
            {

                TypeOfDisches = db.Typeofdish.Select
                (x =>
                   new SelectListItem
                   {
                       Value = x.TypeofdishID.ToString(),
                       Text = x.Type
                   }
                ),

                TypeOfMeals = db.Typeofmeal.Select
                (x =>
                   new SelectListItem
                   {
                       Value = x.TypeofmealID.ToString(),
                       Text = x.Mealstype
                   }
                ),
                Recipe = recipe
            };

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", recipe.UserID);
            return View(vm);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,UserID,Name,Description,Components,TypeofdishesID,TypeofmealsID, EquipmentV2ID", Prefix = "Recipe")] Recipe recipe)
        {
            var userId = HttpContext.User.Identity;
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
                throw new HttpException(404, "Not found");
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


        


