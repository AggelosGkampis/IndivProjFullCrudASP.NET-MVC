using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkyDreaming.Models;
using SkyDreaming.Mycontext;
using SkyDreaming.Repositories;

namespace SkyDreaming.Controllers
{
    public class productController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private productRepository productRepository;
        public productController()
        {
            productRepository = new productRepository(db);
        }
        // GET: product
        public ActionResult Index()
        {
            var products = productRepository.GetAllWithIGmodels();
            return View(products.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = productRepository.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cost,UrlImage")] product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);               
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = productRepository.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Cost,UrlImage")] product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Edit(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = productRepository.GetByIdWithIGmodels(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = productRepository.GetById(id);
            productRepository.Delete(product);
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
