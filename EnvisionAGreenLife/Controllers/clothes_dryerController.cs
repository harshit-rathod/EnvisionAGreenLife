﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvisionAGreenLife.Models;
using MvcBreadCrumbs;
using EnvisionAGreenLife.ViewModel;
using PagedList;

namespace EnvisionAGreenLife.Controllers
{
    [BreadCrumb]
    public class clothes_dryerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_dryer
        [BreadCrumb(Clear = true, Label = "Clothes Dryer")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter, string Ratings, string currentRatings)
        {
            decimal rating;
            if (!String.IsNullOrEmpty(Ratings))
            {
                rating = decimal.Parse(Ratings);
            }
            else
            if (!String.IsNullOrEmpty(currentRatings))
            {
                rating = decimal.Parse(currentRatings);
            }
            else
            {
                rating = -1;
            }
            var results = from x in db.clothes_dryer
                          select x;
            int pagesize = 9, pageindex = 1;
            CdList temp = new CdList();
            if (searchString != null || Ratings != null)
            {
                page = 1;
            }
            else
            {
                Ratings = currentRatings;
                searchString = currentFilter;
            }

            // Showing data based on the search query string and the star rating selected from the dropdown.

            ViewData["CurrentRatings"] = Ratings;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString) && rating != -1)
            {
                results = results.Where(s => s.Brand.Contains(searchString) && s.New_Star < (rating + 1) && s.New_Star >= rating);
            }
            else
            if (!String.IsNullOrEmpty(searchString) && rating == -1)
            {
                results = results.Where(s => s.Brand.Contains(searchString));
            }
            else
            if (String.IsNullOrEmpty(searchString) && rating != -1)
            {
                results = results.Where(s => s.New_Star < (rating + 1) && s.New_Star >= rating);

            }
            else
            {
                results = results.Where(x => x.Type_Id == 1);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Clothes_dryers = list.ToPagedList(pageindex, pagesize);

            // showing the navigation map using the bread crumbs.

            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add("", "Clothes Dryers");

            //adding the values in dropdown list

            List<SelectListItem> Ratings_level = new List<SelectListItem>();
            Ratings_level.Add(new SelectListItem() { Text = "All Ratings", Value = "-1" });
            Ratings_level.Add(new SelectListItem() { Text = "1 Star", Value = "1" });
            Ratings_level.Add(new SelectListItem() { Text = "2 Star", Value = "2" });
            Ratings_level.Add(new SelectListItem() { Text = "3 Star", Value = "3" });
            Ratings_level.Add(new SelectListItem() { Text = "4 Star", Value = "4" });
            Ratings_level.Add(new SelectListItem() { Text = "5 Star", Value = "5" });
            this.ViewBag.Ratings = new SelectList(Ratings_level, "Value", "Text", currentRatings);
            return View(temp);
        }
        // GET: clothes_dryer/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            if (clothes_dryer == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "clothes_dryer"), "Clothes Dryer");
            BreadCrumb.Add("", clothes_dryer.Model_No);

            // Smiliar products display logic

            var results = from x in db.clothes_dryer
                          select x;
            var list = results.Where(x => x.Brand.Contains(clothes_dryer.Brand)).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(clothes_dryer);
        }

        // GET: Top recommendations
        [HttpGet]
        public ActionResult TopRecommendations()
        {

            var results = from x in db.clothes_dryer
                          select x;
            int pagesize = 9, pageindex = 1;
            CdList temp = new CdList();
            results = results.Where(x => x.New_Star >= 5).OrderBy(x => Guid.NewGuid()).Take(9);
            var list = results.ToList();
            temp.Clothes_dryers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "clothes_dryer"), "Clothes Dryer");
            BreadCrumb.Add("", "Top Recommendations");
            List<SelectListItem> Ratings_level = new List<SelectListItem>();
            Ratings_level.Add(new SelectListItem() { Text = "All Ratings", Value = "-1" });
            Ratings_level.Add(new SelectListItem() { Text = "1 Star", Value = "1" });
            Ratings_level.Add(new SelectListItem() { Text = "2 Star", Value = "2" });
            Ratings_level.Add(new SelectListItem() { Text = "3 Star", Value = "3" });
            Ratings_level.Add(new SelectListItem() { Text = "4 Star", Value = "4" });
            Ratings_level.Add(new SelectListItem() { Text = "5 Star", Value = "5" });
            this.ViewBag.Ratings = new SelectList(Ratings_level, "Value", "Text");
            return View(temp);
        }
    }
}
