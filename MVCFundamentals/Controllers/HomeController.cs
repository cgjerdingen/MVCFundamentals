using System;
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

        public ActionResult AutoCompleteTrailsSearch(string term)
        {
            var model = _db.Trails.Where(
                t => t.Name.ToLower().Contains(
                    term.ToLower()))
                .OrderByDescending(r => r.TrailReviews.Count())
                .Take(10)
                .Select(
                    trail => new
                    {
                        label = trail.Name

                    });
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Index(string searchTerm)
        {
            var model = _db.Trails.Where(
                t => searchTerm == null ||
                    t.Name.ToLower().Contains(
                        searchTerm.ToLower()))
                        .OrderByDescending(r => r.TrailReviews.Count())
                .Take(10)
                .Select(
                    trail => new TrailViewModel
                    {
                        Name = trail.Name,
                        City = trail.City,
                        State = trail.State,
                        CountOfReviews = trail.TrailReviews.Count
                    })
                .ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Trails", model);
            }
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