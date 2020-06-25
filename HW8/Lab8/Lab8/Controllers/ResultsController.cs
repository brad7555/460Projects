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
    public class ResultsController : Controller
    {
        private sportscontext db = new sportscontext();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Athlete).Include(r => r.Event).Include(r => r.LocationDetail);
            return View(results.ToList());
        }

       

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name");
            ViewBag.EID = new SelectList(db.Events, "ID", "Type");
            ViewBag.LID = new SelectList(db.LocationDetails, "ID", "Place");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RaceTime,AID,EID,LID")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name", result.AID);
            ViewBag.EID = new SelectList(db.Events, "ID", "Type", result.EID);
            ViewBag.LID = new SelectList(db.LocationDetails, "ID", "Place", result.LID);
            return View(result);
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
