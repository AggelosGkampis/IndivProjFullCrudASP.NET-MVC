using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using SkyDreaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyDreaming.Controllers
{
    public class IGmodelController : Controller
    {
        private ApplicationContext db = new ApplicationContext(); // αυτό το αντικέιμενο πρέπει να καταστραφεί γιατί έχουμε ένωση με την βάση

        private IGmodelRepository IGmodelRepo;
        private productRepository productRepository;

        public IGmodelController()
        {
            IGmodelRepo = new IGmodelRepository(db);
            productRepository = new productRepository(db);

        }
        public ActionResult Index(string searchName,string searchHairColor,int? searchMin, int?searchMax)        // HomeController home = new HomeController();
        {                                                   // home.index();  Αυτή η λειτουργία γίνεται εσωτερικά αυτόματα           
            var IGmodels = IGmodelRepo.GetAllWithproducts();

            // Current State
            ViewBag.currentName = searchName;
            ViewBag.currentHairColor = searchHairColor;
            ViewBag.currentMin = searchMin;
            ViewBag.currentMax = searchMax;
            

            ViewBag.MinAge = IGmodels.Min(x => x.Age);
            ViewBag.MaxAge = IGmodels.Max(x => x.Age);

            // Filtering . . .
            if (!string.IsNullOrWhiteSpace(searchName))     // null or "" or "   "
            {
                //IGmodels = IGmodels.Where(x => x.Name.ToUpper() == searchName.ToUpper()).ToList();
                IGmodels = IGmodels.Where(x => x.Name.ToUpper().Contains(searchName.ToUpper())).ToList();
            }


            if (searchHairColor != "All" && !string.IsNullOrWhiteSpace(searchHairColor))
            {
                IGmodels = IGmodels.Where(x => x.HairColor.ToString() == searchHairColor).ToList();
            }

            if (!(searchMin is null))
            {
                IGmodels = IGmodels.Where(x => x.Age >= searchMin).ToList();
            }

            if (!(searchMax is null))
            {
                IGmodels = IGmodels.Where(x => x.Age <= searchMax).ToList();
            }

            return View(IGmodels);
        }

        public ActionResult Details(int? id)
        {
            var IGmodel = IGmodelRepo.GetById(id);
            if (IGmodel == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(IGmodel);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            GetProjects();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IGmodel IGmodel)
        {
            if (ModelState.IsValid)       // Εργαλείο του entityframework . Μας ρωτάει είναι σωστό το μοντέλο IGmodel που μας έρχεται με βάση τα restrictions που έχουμε στα properties του montelou
            {
                IGmodelRepo.Add(IGmodel);
                ShowAlert("You have succesfully created an IGmodel");
                return RedirectToAction("Index");
            }
            GetProjects();

            return View(IGmodel);
           
        }

        [HttpGet]
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var ang = IGmodelRepo.GetById(id);

            if (ang == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            GetProjects();
            return View(ang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IGmodel IGmodel)
        {
            if (ModelState.IsValid)
            {
                IGmodelRepo.Edit(IGmodel);
                ShowAlert($"IGmodel with id {IGmodel.Id} succesfully updated !");
                return RedirectToAction("Index");
            }
            GetProjects();

            return View(IGmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var IGmodel = IGmodelRepo.GetById(id);
            if (IGmodel == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            IGmodelRepo.Delete(IGmodel);          
            ShowAlert($"You have been successfully deleted the chick with name = {IGmodel.Name}");
            return RedirectToAction("Index");                                           // Αφού διαγράψεις πήγαινέ με στην Index

        }
     
        protected override void Dispose(bool disposing)    // Αφού κατασταφέι ο controller (δηλαδή μόλις ανοίξει η σελίδα)
        {
            if (disposing)
            {
                db.Dispose();                // με αυτή την μέθοδο καταστρέφω το application context
            }
            base.Dispose(disposing);
        }

        [NonAction]
        public void GetProjects()
        {
            var products = productRepository.GetAll();
            ViewBag.products = products;
        }
          
        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}