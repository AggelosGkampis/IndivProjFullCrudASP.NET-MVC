using SkyDreaming.Mycontext;
using SkyDreaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyDreaming.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext(); // αυτό το αντικέιμενο πρέπει να καταστραφεί γιατί έχουμε ένωσε με την βάση

        private AngelRepository angelRepo;

        public HomeController()
        {
            angelRepo = new AngelRepository(db);
        }
        public ActionResult Index()                         // HomeController home = new HomeController();
        {                                                   // home.index();  Αυτή η λειτουργία γίνεται εσωτερικά αυτόματα
            var angels = angelRepo.GetAll();
            return View(angels);
        }

        protected override void Dispose(bool disposing)    // Αφού κατασταφέι ο controller (δηλαδή μόλις ανοίξει η σελίδα)
        {
            if (disposing)
            {
                db.Dispose();                // με αυτή την μέθοδο καταστρέφω το application context
            }
            base.Dispose(disposing);
        }
    }
}