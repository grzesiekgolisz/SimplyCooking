using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using SimplyCooking.Models;
using System.Web;

namespace SimplyCooking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var recipes = db.Recipe.Include(r => r.User);
            return View(recipes.ToList());
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult sniadania(int id)
        //{
        //    var dishesList = db.Recipe.Where(x => x.TypeofdishesID == id).ToList();
        //    return View(dishesList);
        //}

        //public ActionResult obiady(int id)
        //{
        //    var dishesList = db.Recipe.Where(x => x.TypeofdishesID == id).ToList();
        //    return View(dishesList);
        //}

        //public ActionResult kolacje(int id)
        //{
        //    var dishesList = db.Recipe.Where(x => x.TypeofdishesID == id).ToList();
        //    return View(dishesList);
        //}

        public ActionResult TypeOfDishesIndex(int id)
        {
            var dishesList = db.Recipe.Where(x => x.TypeofdishesID == id).ToList();
            return View(dishesList);
        }

        public ActionResult TypeOfMealsIndex(int id)
        {
            var mealsList = db.Recipe.Where(x => x.TypeofmealsID == id).ToList();
            return View(mealsList);
        }


        [HttpPost]
        public ActionResult Akcja(string imie)
        {
            return View();
        }


    }
}