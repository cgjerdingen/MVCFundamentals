using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFundamentals.Models;

namespace MVCFundamentals.Controllers
{
    public class TrailsController : Controller
    {
        private RateMyTrail db = new RateMyTrail();

        // GET: Trails
        public ActionResult Index()
        {
            return View(db.Trails.ToList());
        }

        // GET: Trails/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trail trail = db.Trails.Find(id);
            if (trail == null)
            {

                // May be replace with a more interesting response that gives visitors options.
                return HttpNotFound();
            }
            return View(trail);
        }

        // GET: Trails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,State")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                db.Trails.Add(trail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trail);
        }

        // GET: Trails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trail trail = db.Trails.Find(id);
            if (trail == null)
            {
                return HttpNotFound();
            }
            return View(trail);
        }

        // POST: Trails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,State")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trail);
        }

        // GET: Trails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trail trail = db.Trails.Find(id);
            if (trail == null)
            {
                return HttpNotFound();
            }
            return View(trail);
        }

        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trail trail = db.Trails.Find(id);
            db.Trails.Remove(trail);
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
