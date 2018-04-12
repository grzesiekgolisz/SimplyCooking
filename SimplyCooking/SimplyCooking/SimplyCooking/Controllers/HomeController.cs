using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using SimplyCooking.Models;


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

        public ActionResult sniadania()
        {
            ViewBag.Message = "Mniam";

            return View();
        }

        public ActionResult obiady()
        {
            ViewBag.Message = "Mniam";

            return View();
        }

        public ActionResult kolacje()
        {
            ViewBag.Message = "Mniam";

            return View();
        }


        [HttpPost]
        public ActionResult Akcja(string imie)
        {
            return View();
        }


    }
}