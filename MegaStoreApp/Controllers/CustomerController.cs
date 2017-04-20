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
using MegaStoreApp.ViewModels;

namespace MegaStoreApp.Controllers
{
    public class CustomerController : Controller
    {
        private StoreContext db = new StoreContext();




        // GET: Customer
        public ActionResult Index()
        {


            return View(db.Customers.ToList());
        }

        // GET: Customer/Details/5
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

        // GET: Customer/Create
        public ActionResult Create()
        {
            var customer = new Customer();
            customer.Purchases = new List<Purchases>();
            PopulateAssignedCourseData(customer);

            return View();
        }

        


        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,LastName,FirstMidName,CreationDate")] Customer customer, string[] purchasedAlbums)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            if (purchasedAlbums != null)
            {
                //customer.Purchases = new List<Purchases>();
                
                foreach (var purchase in purchasedAlbums)
                {

                    customer.AlbumID = Int32.Parse(purchase);                                        
                    db.SaveChanges();
                }
            }


            if (ModelState.IsValid)
            {

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedCourseData(customer);
            return View(customer);
        }



        private void PopulateAssignedCourseData(Customer customer)
        {
            var allCourses = db.Purchases;
            var instructorCourses = new HashSet<int>(customer.Purchases.Select(c => c.AlbumID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    AlbumID = course.AlbumID,
                    Title = course.Album.Title,
                    Assigned = instructorCourses.Contains(course.AlbumID)
                });
            }
            ViewBag.Albums = viewModel;
        }

        private void UpdateInstructorCourses(string[] purchasedAlbums, Customer instructorToUpdate)
        {
            if (purchasedAlbums == null)
            {
                instructorToUpdate.Purchases = new List<Purchases>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(purchasedAlbums);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.Purchases.Select(c => c.AlbumID));
            foreach (var course in db.Purchases)
            {
                if (selectedCoursesHS.Contains(course.AlbumID.ToString()))
                {
                    if (!instructorCourses.Contains(course.AlbumID))
                    {
                        instructorToUpdate.Purchases.Add(course);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.AlbumID))
                    {
                        instructorToUpdate.Purchases.Remove(course);
                    }
                }
            }
        }

        // GET: Customer/Edit/5
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

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Customer/Delete/5
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

        // POST: Customer/Delete/5
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
