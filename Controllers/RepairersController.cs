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
    public class RepairersController : Controller
    {
        private ComputerReparatieshopContext db = new ComputerReparatieshopContext();

        // GET: RepairerModels
        public ActionResult Index()
        {
            List<Repairer> repairer = db.Repairers.ToList();
            return View(db.Repairers.ToList());
        }

        // GET: RepairerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairerVM repairerVM = new RepairerVM
            {
                Repairer = db.Repairers.FirstOrDefault(r => r.Id == id),
            };
            if (repairerVM == null)
            {
                return HttpNotFound();
            }
            return View(repairerVM);
        }

        // GET: RepairerModels/Create
        public ActionResult Create()
        {
            RepairerVM repairerVM = new RepairerVM
            {
                Repairer = new Repairer()
            };
            return View(repairerVM);
        }

        // POST: RepairerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairerVM RepairerVM)
        {
            if (ModelState.IsValid)
            {
                if (RepairerVM.Repairer.BirthDate.Ticks == 0)
                    RepairerVM.Repairer.BirthDate = DateTime.Now.Date;
                db.Repairers.Add(RepairerVM.Repairer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(RepairerVM.Repairer);
        }

        // GET: RepairerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairerVM repairerVM = new RepairerVM
            {
                Repairer = db.Repairers.FirstOrDefault(r => r.Id == id),
            };
            if (repairerVM == null)
            {
                return HttpNotFound();
            }
            return View(repairerVM);
        }

        // POST: RepairerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,BirthDate")] Repairer repairer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairer);
        }

        // GET: RepairerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairerVM repairerVM = new RepairerVM
            {
                Repairer = db.Repairers.Find(id),
            };
            if (repairerVM == null)
            {
                return HttpNotFound();
            }
            return View(repairerVM);
        }

        // POST: RepairerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repairer repairer = db.Repairers.Find(id);
            db.Repairers.Remove(repairer);
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
