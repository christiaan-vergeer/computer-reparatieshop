using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using computer_reparatieshop.DAL;
using computer_reparatieshop.Models;
using computer_reparatieshop.ViewModels;
using Microsoft.Ajax.Utilities;

namespace computer_reparatieshop.Controllers
{
    public class ReparatieopdrachtensController : Controller
    {
        private ComputerReparatieshopContext db = new ComputerReparatieshopContext();

        // GET: Reparatieopdrachtens
        public ActionResult Index()
        {
            ViewBag.Pending = Countstate(Status.Pending);
            ViewBag.Underway = Countstate(Status.Underway);
            ViewBag.WaitingForParts = Countstate(Status.WaitingForParts);
            ViewBag.Done = Countstate(Status.Done);
            return View(db.Reparaties.ToList());
        }


        public int Countstate(Status status2)
        {
            int count = 0;
            var dbReparatiesList = db.Reparaties.ToList();



            for (int i = 0; i < dbReparatiesList.Count; i++)
            {
                if (dbReparatiesList[i].Status == status2)
                {
                    count++;
                }
            }

            return count;
        }


        // GET: Reparatieopdrachtens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrderVM repairOrderVM = new RepairOrderVM
            {
                RepairOrder = db.Reparaties.FirstOrDefault(r => r.Id == id),
                Customers = db.Customers.ToList()
            };
            if (repairOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(repairOrderVM);
        }

        // GET: Reparatieopdrachtens/Create
        public ActionResult Create()
        {
            RepairOrderVM repairOrderVM = new RepairOrderVM()
            {
                Customers = db.Customers.ToList(),
                RepairOrder = new Reparatieopdrachten()
            };
            return View(repairOrderVM);
        }

        // POST: Reparatieopdrachtens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairOrderVM RepairOrderVM, CustomerVM CustomerVM)
        {
            if (ModelState.IsValid)
            {
                db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).TotalOrderCount = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).TotalOrderCount + 1;
                db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).OpenOrderCount = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).OpenOrderCount + 1;
                RepairOrderVM.RepairOrder.Status = Status.Pending;
                RepairOrderVM.RepairOrder.CustomerName = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).FullName;
                db.Reparaties.Add(RepairOrderVM.RepairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(RepairOrderVM);
        }

        // GET: Reparatieopdrachtens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrderVM repairOrderVM = new RepairOrderVM
            {
                RepairOrder = db.Reparaties.Find(id),
                Customers = db.Customers.ToList()
            };
            if (repairOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(repairOrderVM);
        }


        // POST: Reparatieopdrachtens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,RepairOrder")] RepairOrderVM RepairOrderVM)
        {
            if (ModelState.IsValid)
            {


                RepairOrderVM.RepairOrder.CustomerName = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).FullName;

                db.Entry(RepairOrderVM.RepairOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(RepairOrderVM);
        }

        // GET: Reparatieopdrachtens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrderVM repairOrderVM = new RepairOrderVM
            {
                RepairOrder = db.Reparaties.Find(id),
                Customers = db.Customers.ToList()
            };
            if (repairOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(repairOrderVM);
        }

        // POST: Reparatieopdrachtens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparatieopdrachten reparatieopdrachten = db.Reparaties.Find(id);
            db.Reparaties.Remove(reparatieopdrachten);
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
