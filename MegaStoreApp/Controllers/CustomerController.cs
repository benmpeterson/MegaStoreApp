using MegaStoreApp.DAL;
using MegaStoreApp.Models;
using MegaStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MegaStoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        public ActionResult Create()
        {
            var customer = new Customer();
            customer.Purchases = new List<Purchases>();
            PopulatePurchasedAlbums(customer);

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,LastName,FirstMidName,CreationDate")] Customer customer, string[] purchasedAlbums)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            if (purchasedAlbums != null)
            {
                                
                foreach (var purchase in purchasedAlbums)
                {                    
                    customer.AlbumID = Int32.Parse(purchase);
                    
                    Purchases p = new Purchases
                    {
                        CustomerID = customer.CustomerID,
                        AlbumID = customer.AlbumID,
                        
                    };                   
                    db.Purchases.Add(p);                    
                }
            }


            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.SaveChanges();            
            return View(customer);
        }



        private void PopulatePurchasedAlbums(Customer customer)
        {
            var albums = db.Albums;
            var customerPurchases = new HashSet<int>(customer.Purchases.Select(c => c.AlbumID));
            var viewModel = new List<AlbumViewModel>();
            foreach (var album in albums)
            {
                viewModel.Add(new AlbumViewModel
                {
                    AlbumID = album.AlbumID,
                    Title = album.Title,
                    Artist = album.Artist,
                    Assigned = customerPurchases.Contains(album.AlbumID)
                });
            }
            ViewBag.Albums = viewModel;
        }


        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,LastName,FirstMidName,CreationDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
