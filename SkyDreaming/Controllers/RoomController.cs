using SkyDreaming.Mycontext;
using SkyDreaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyDreaming.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private RoomRepository RoomRepo;

        public RoomController()
        {
            RoomRepo = new RoomRepository(db);
        }
        // GET: Room
        public ActionResult Index()
        {
            var rooms = RoomRepo.GetAll();
            return View(rooms);
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