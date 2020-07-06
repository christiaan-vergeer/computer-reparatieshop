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

namespace computer_reparatieshop.Controllers
{
    public class ReparatieopdrachtensController : Controller
    {
        private ComputerReparatieshopContext db = new ComputerReparatieshopContext();

        // GET: Reparatieopdrachtens
        public ActionResult Index()
        {
            return View(db.Reparaties.ToList());
        }

        // GET: Reparatieopdrachtens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.Reparaties.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachtens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reparatieopdrachtens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,startdate,enddate,status")] Reparatieopdrachten reparatieopdrachten)
        {
            if (ModelState.IsValid)
            {
                db.Reparaties.Add(reparatieopdrachten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachtens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.Reparaties.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
        }

        public ActionResult Countstate(int value)
        {
            if (value == 1)
            {
              var count = db.
            }
        }

        // POST: Reparatieopdrachtens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,startdate,enddate,status")] Reparatieopdrachten reparatieopdrachten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparatieopdrachten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reparatieopdrachten);
        }

        // GET: Reparatieopdrachtens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparatieopdrachten reparatieopdrachten = db.Reparaties.Find(id);
            if (reparatieopdrachten == null)
            {
                return HttpNotFound();
            }
            return View(reparatieopdrachten);
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
