using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCFundamentals.Models;

namespace MVCFundamentals.Controllers
{
    public class TrailReviewsController : Controller
    {
        RateMyTrail _db = new RateMyTrail();

        public ActionResult BestReview()
        {
            var bestReview =
                from r in _db.TrailReviews
                orderby r.Rating descending
                select r;
            if (bestReview.Count() < 1)
            {
                return new EmptyResult();
            }
       
            return PartialView("_TrailReview", bestReview.FirstOrDefault());
        }

        // GET: TrailReviews
        public ActionResult Index()
        {
            var model =
                from r in _db.TrailReviews
                orderby r.Rating
                select r;
            return View(model);
        }

        // GET: TrailReviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrailReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrailReviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrailReviews/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.TrailReviews.Single(r => r.Id == id);
            return View(model);
        }

        // POST: TrailReviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var trailReview = _db.TrailReviews.Single(r => r.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrailReviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrailReviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
