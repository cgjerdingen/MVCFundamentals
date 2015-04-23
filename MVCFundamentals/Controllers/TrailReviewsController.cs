using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using MVCFundamentals.Models;
using Microsoft.AspNet.Identity;

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
        //id is a trail id not trailreviewid
        public ActionResult Index([Bind(Prefix = "id")] int trailId)
        {
            
            //var model =
            //    from r in _db.TrailReviews
            //    orderby r.Rating
            //    select r;

            var trail = _db.Trails.Find(trailId);
            if (trail != null)
            {
                return View(trail);
            }
            return HttpNotFound();
            //return View(model);
        }

        // GET: TrailReviews/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TrailReviews/Create
        public ActionResult Create(int trailId, string trailName)
        {
            var trailReview = new TrailReview();
            trailReview.ReviewerName = Server.HtmlEncode(User.Identity.GetUserName()); 
            ViewData["trailName"] = trailName;
            ViewData.Model = trailReview;
            return View();
        }

        // POST: TrailReviews/Create
        [HttpPost]
        public ActionResult Create(TrailReview trailReview)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _db.TrailReviews.Add(trailReview);
                    _db.SaveChanges();
                    return RedirectToAction("Index", new { id = trailReview.TrailId });
                }
                else
                {
                    return View(trailReview);
                }

            }
            catch
            {
                return View(trailReview);
            }
        }

        // GET: TrailReviews/Edit/5
        public ActionResult Edit(int id, string trailName)
        {
            var userName = User.Identity.GetUserName();
            ViewData["trailName"] = trailName;
            //var model = _db.TrailReviews.Single(r => r.Id == id);
            try
            {
                var model = _db.TrailReviews.Where(r => r.ReviewerName == userName && r.Id == id).Single();
                return View(model);
            }
            catch (InvalidOperationException e)
            {
                return new HttpNotFoundResult("No Trail Review is found");
                //return HttpNotFound();
                //throw new HttpException(404, "No Trail Review is found");
            }
            
            
            
        }

        // POST: TrailReviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrailReview trailReview)
        {
            try
            {
                // TODO: Add update logic here
                //var trailReview = _db.TrailReviews.Single(r => r.Id == id);
                //return RedirectToAction("Index");
                if (ModelState.IsValid)
                {
                    //_db.TrailReviews.AddOrUpdate(trailReview);
                    _db.Entry(trailReview).State = EntityState.Modified;

                    _db.SaveChanges();
                    return RedirectToAction("Index", new { id = trailReview.TrailId });
                }
                else
                {
                    return View(trailReview);
                }
            }
            catch
            {
                return View(trailReview);
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

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
