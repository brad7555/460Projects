using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab8.Models;
using Lab8.Models.DAL;

namespace Lab8.Controllers
{
    public class LocationDetailsController : Controller
    {
        private sportscontext db = new sportscontext();

        // GET: LocationDetails
        public ActionResult Index()
        {
            return View(db.LocationDetails.ToList());
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Place")] LocationDetail locationDetail)
        {
            if (ModelState.IsValid)
            {
                db.LocationDetails.Add(locationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationDetail);
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
