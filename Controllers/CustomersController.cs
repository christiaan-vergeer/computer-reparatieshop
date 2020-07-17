using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using computer_reparatieshop.DAL;
using computer_reparatieshop.Models;
using computer_reparatieshop.ViewModels;

namespace computer_reparatieshop.Controllers
{
    public class CustomersController : Controller
    {
        private ComputerReparatieshopContext db = new ComputerReparatieshopContext();

        // GET: Customers
        public ActionResult Index()
        {
            VirtualVM virtualVM = new VirtualVM
            {
                
                customer = db.Customers.ToList(),
            };
            foreach (var customer in virtualVM.customer)
            {
                customer.TotalOrderCount = db.Reparaties.Where(r => r.Customer.Id == customer.Id).Count();
                customer.OpenOrderCount = db.Reparaties.Where(r => r.Customer.Id == customer.Id).Where(r => r.Status != Status.Done).Count();
            }
            return View(virtualVM);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.Customers.FirstOrDefault(r => r.Id == id));
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            CustomerVM customerVM = new CustomerVM()
            {
                Customer = new Customer()
            };
            return View(customerVM);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,RegisterDate,BirthDate,TotalOrderCount,OpenOrderCount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.RegisterDate = DateTime.Now;
                if (customer.BirthDate.Ticks == 0)
                    customer.BirthDate = DateTime.Now.Date;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.Customers.Find(id));
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,RegisterDate,BirthDate,Status,TotalOrderCount,OpenOrderCount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
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

        // POST: Customers/Delete/5
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
