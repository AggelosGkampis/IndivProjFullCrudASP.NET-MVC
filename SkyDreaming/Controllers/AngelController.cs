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
    public class AngelController : Controller
    {
        private ApplicationContext db = new ApplicationContext(); // αυτό το αντικέιμενο πρέπει να καταστραφεί γιατί έχουμε ένωση με την βάση

        private AngelRepository angelRepo;
        private RoomRepository roomRepository;

        public AngelController()
        {
            angelRepo = new AngelRepository(db);
            roomRepository = new RoomRepository(db);

        }
        public ActionResult Index()                         // HomeController home = new HomeController();
        {                                                   // home.index();  Αυτή η λειτουργία γίνεται εσωτερικά αυτόματα           
            var angels = angelRepo.GetAllWithRooms();
            return View(angels);
        }

        public ActionResult Details(int? id)
        {
            var angel = angelRepo.GetById(id);
            if (angel == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(angel);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            GetProjects();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Angel angel)
        {
            if (ModelState.IsValid)       // Εργαλείο του entityframework . Μας ρωτάει είναι σωστό το μοντέλο angel που μας έρχεται με βάση τα restrictions που έχουμε στα properties του montelou
            {
                angelRepo.Add(angel);
                ShowAlert("You have succesfully created an Angel");
                return RedirectToAction("Index");
            }
            GetProjects();

            return View(angel);
           
        }

        [HttpGet]
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var ang = angelRepo.GetById(id);

            if (ang == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            GetProjects();
            return View(ang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Angel angel)
        {
            if (ModelState.IsValid)
            {
                angelRepo.Edit(angel);
                ShowAlert($"Angel with id {angel.Id} succesfully updated !");
                return RedirectToAction("Index");
            }
            GetProjects();

            return View(angel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var angel = angelRepo.GetById(id);
            if (angel == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            angelRepo.Delete(angel);          
            ShowAlert($"You have been successfully deleted the chick with name = {angel.Name}");
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
            var rooms = roomRepository.GetAll();
            ViewBag.Rooms = rooms;
        }
          
        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}