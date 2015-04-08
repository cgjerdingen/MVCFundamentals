﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFundamentals.Models;

namespace MVCFundamentals.Controllers
{
    public class HomeController : Controller
    {
        RateMyTrail _db = new RateMyTrail();
        public ActionResult Index()
        {
            var model = _db.Trails.OrderByDescending(r => r.TrailReviews.Count()).Take(10).Select(trail => new TrailViewModel { Name = trail.Name, City = trail.City, State = trail.State, CountOfReviews = trail.TrailReviews.Count}).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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