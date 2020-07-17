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
            var rep = db.Reparaties.Include(r => r.Customer).ToList();
            return View(rep);
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
            return View(db.Reparaties.Include(r => r.Customer).FirstOrDefault(r => r.Id == id));
        }

        // GET: Reparatieopdrachtens/Create
        public ActionResult Create()
        {
            RepairOrderVM repairOrderVM = new RepairOrderVM()
            {
                Customers = db.Customers.ToList(),
                RepairOrder = new Reparatieopdrachten()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            };
            return View(repairOrderVM);
        }

        // POST: Reparatieopdrachtens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairOrderVM RepairOrderVM)
        {
            if (ModelState.IsValid)
            {
               // db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).TotalOrderCount = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).TotalOrderCount + 1;
               // db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).OpenOrderCount = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId).OpenOrderCount + 1;
               RepairOrderVM.RepairOrder.Status = Status.Pending;
                //// RepairOrderVM.RepairOrder.custemerId = RepairOrderVM.CustomerId;
                // if (RepairOrderVM.RepairOrder.StartDate.Ticks == 0)
                //     RepairOrderVM.RepairOrder.StartDate = DateTime.Now.Date;
                // if (RepairOrderVM.RepairOrder.EndDate.Ticks == 0)
                //     RepairOrderVM.RepairOrder.EndDate = DateTime.Now.Date;
                RepairOrderVM.RepairOrder.Customer = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId);
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
                RepairOrder = db.Reparaties.Include(r => r.Customer).FirstOrDefault(r => r.Id == id),
                Customers = db.Customers.ToList()
            };

            //if (repairOrderVM.RepairOrder.StartDate.Ticks == 0)
            //    repairOrderVM.RepairOrder.StartDate = DateTime.Now.Date;
            //if (repairOrderVM.RepairOrder.EndDate.Ticks == 0)
            //    repairOrderVM.RepairOrder.EndDate = DateTime.Now.Date;

           
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
                Reparatieopdrachten rep = db.Reparaties.Include(r => r.Customer).FirstOrDefault(r => r.Id == RepairOrderVM.RepairOrder.Id);
                rep.Customer = db.Customers.FirstOrDefault(c => c.Id == RepairOrderVM.CustomerId);
                db.Entry(rep).State = EntityState.Modified;
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
            return View(db.Reparaties.Find(id));
        }

        // POST: Reparatieopdrachtens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparatieopdrachten reparatieopdrachten = db.Reparaties.Find(id);

           // int userid = db.Reparaties.Find(id).custemerId;


            //db.Customers.Find(userid).TotalOrderCount = db.Customers.Find(userid).TotalOrderCount - 1;
            //if (db.Reparaties.Find(id).Status.ToString() != "Done")
            //{
            //    db.Customers.Find(userid).OpenOrderCount = db.Customers.Find(userid).OpenOrderCount - 1;
            //}


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
