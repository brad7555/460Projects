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
using Newtonsoft.Json;

namespace Lab8.Controllers
{
    public class GraphController : Controller
    {
        private sportscontext db = new sportscontext();

        // GET: graph
        /**/
        public ActionResult Index(Athlete athlete)
        {
            var athletes = db.Athletes.Include(a => a.Team);
            var team = from a in db.Athletes
                       where a.TID == athlete.TID
                       select a.Name;

            ViewBag.team = team;

            var events = from e in db.Events select e.Type;
            ViewBag.events = events;


            return View();
        }

        //GraphMath
        public ActionResult GraphMath()
        {
            string athleteName = Request.QueryString["athchoice"];
            string eventType = Request.QueryString["evchoice"];


            // join athlete table, results table, and event table
            // where Athlete.name == athleteName and where Event.Name == eventType
            // Athlete joins Results with AID and Results joins Event by Name
            

            /*var gModel = db.Results.Join(db.Athletes.Where(a => a.Name == athleteName),
               r => r.AID, a => a.ID,
               (r,a) => new {r, a }).Join(db.Events.Where(e => e.Type == eventType), 
               ra => ra.r.EID, e => e.ID, 
               (ra, e) => new { ra, e }).Join(db.LocationDetails, rae => rae.ra.r.LID, l => l.ID, 
               (rae, l) => new {rae, l }).Select(m => new graphModel
               { 
               
                   eventDate = m.l.Date, 
                   eventName = m.rae.e.Type ,
                   Result1 = m.rae.ra.r.RaceTime
               
               }).ToList();*/

            var gModel = db.Results.Join(db.Athletes.Where(a => a.Name == athleteName),
               r => r.AID, a => a.ID,
               (r, a) => new { r, a }).Join(db.Events.Where(e => e.Type == eventType),
               ra => ra.r.EID, e => e.ID,
               (ra, e) => new { ra, e }).Join(db.LocationDetails, rae => rae.ra.r.LID, l => l.ID,
               (rae, l) => new { rae, l }).Select(m => new graphModel
               {

                   eventDate = m.l.Date,
                   eventName = m.rae.e.Type,
                   Result1 = m.rae.ra.r.RaceTime

               }).ToList();

            string jsonString = JsonConvert.SerializeObject(gModel, Formatting.Indented);
            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }



        // GET: graph/Create
        public ActionResult Create()
        {
            ViewBag.TID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: graph/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Athlete athlete)
        {
            

            ViewBag.TID = new SelectList(db.Teams, "ID", "Name", athlete.TID);
            return RedirectToAction("Index",athlete);
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
