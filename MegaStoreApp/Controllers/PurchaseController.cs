using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MegaStoreApp.DAL;
using MegaStoreApp.Models;

namespace MegaStoreApp.Controllers
{
    public class PurchaseController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Purchase
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Album).Include(p => p.Customer);
            return View(purchases.ToList());
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            return View(purchases);
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "LastName");
            return View();
        }

        // POST: Purchase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchasesID,AlbumID,CustomerID,Rating")] Purchases purchases)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", purchases.AlbumID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "LastName", purchases.CustomerID);
            return View(purchases);
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", purchases.AlbumID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "LastName", purchases.CustomerID);
            return View(purchases);
        }

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchasesID,AlbumID,CustomerID,Rating")] Purchases purchases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "Artist", purchases.AlbumID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "LastName", purchases.CustomerID);
            return View(purchases);
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchases purchases = db.Purchases.Find(id);
            if (purchases == null)
            {
                return HttpNotFound();
            }
            return View(purchases);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchases purchases = db.Purchases.Find(id);
            db.Purchases.Remove(purchases);
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
