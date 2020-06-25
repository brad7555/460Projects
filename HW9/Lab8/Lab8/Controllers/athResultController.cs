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
using Lab8.Models.ViewModels; 

namespace Lab8.Controllers
{
    public class athResultController : Controller
    {
        private sportscontext db = new sportscontext();

        // GET: athResult
        /*Getting the result. result holds the AID that was selected by the user from the athResult*/
        public ActionResult Index(Result result)
        {
            /*matching the results AID with the matching AID inside of the Results table. Then join the Results 
             with Events and LocationDetails to populate the athleteResult ViewModel*/
            var results = db.Events.Join(db.Results.Where(r => r.AID == result.AID),
                e => e.ID, r => r.EID, (e, r) => new { e, r }).Join(db.LocationDetails, er => er.r.LID,
                l => l.ID, (er, l) => new { er, l }).Select(m => new athleteResultModel
                {
                    eventName = m.er.e.Type, 
                    eventDate = m.l.Date,
                    eventLocation = m.l.Place, 
                    athleteResult = m.er.r.RaceTime


                });
            /*Querying the dates from the results table*/
            var dates = from r in results select r;
            dates = dates.OrderByDescending(d => d.eventDate);
            /*Querying the Athletes db to get the athlete name. matching the a.ID (athlete table ID) with the result.AID */
            var athName = (from a in db.Athletes where a.ID == result.AID select a.Name).FirstOrDefault();
            ViewBag.AthName = athName;


            return View(dates.ToList());



           
        }


        // GET: athResult/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name");
            
            return View();
        }

        // POST: athResult/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Result result)
        {
           

            ViewBag.AID = new SelectList(db.Athletes, "ID", "Name", result.AID);
           /*Redirecting to thee Index Page on action*/
            return RedirectToAction("Index", result);
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
