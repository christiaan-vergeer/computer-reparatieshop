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
    public class VirtualModelsController : Controller
    {
        private ComputerReparatieshopContext db = new ComputerReparatieshopContext();

        // GET: VirtualModels
        public ActionResult Index()
        {
            return View(db.virtamodel.ToList());
        }

        // GET: VirtualModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualModel virtualModel = db.virtamodel.Find(id);
            if (virtualModel == null)
            {
                return HttpNotFound();
            }
            return View(virtualModel);
        }

        // GET: VirtualModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirtualModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] VirtualModel virtualModel)
        {
            if (ModelState.IsValid)
            {
                db.virtamodel.Add(virtualModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(virtualModel);
        }

        // GET: VirtualModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualModel virtualModel = db.virtamodel.Find(id);
            if (virtualModel == null)
            {
                return HttpNotFound();
            }
            return View(virtualModel);
        }

        // POST: VirtualModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] VirtualModel virtualModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(virtualModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(virtualModel);
        }

        // GET: VirtualModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualModel virtualModel = db.virtamodel.Find(id);
            if (virtualModel == null)
            {
                return HttpNotFound();
            }
            return View(virtualModel);
        }

        // POST: VirtualModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VirtualModel virtualModel = db.virtamodel.Find(id);
            db.virtamodel.Remove(virtualModel);
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
