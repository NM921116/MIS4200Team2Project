using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Team2Project.DAL;
using MIS4200Team2Project.Models;

namespace MIS4200Team2Project.Controllers
{
    public class ReccomendationsController : Controller
    {
        private MIS4200Team2Context db = new MIS4200Team2Context();

        // GET: Reccomendations
        public ActionResult Index()
        {
            var recomendation = db.Recomendation.Include(r => r.Employee).Include(r => r.Recognition).Include(r => r.Recognizer);
            return View(recomendation.ToList());
        }

        // GET: Reccomendations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reccomendation reccomendation = db.Recomendation.Find(id);
            if (reccomendation == null)
            {
                return HttpNotFound();
            }
            return View(reccomendation);
        }

        // GET: Reccomendations/Create
        public ActionResult Create()
        {
            ViewBag.employeeId = new SelectList(db.profile, "profileID", "lastName");
            ViewBag.recognitionId = new SelectList(db.profile, "profileID", "lastName");
            ViewBag.recognizerId = new SelectList(db.profile, "profileID", "lastName");
            return View();
        }

        // POST: Reccomendations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReccomendationId,employeeId,recognizerId,recognitionId,awardDate,description")] Reccomendation reccomendation)
        {
            if (ModelState.IsValid)
            {
                reccomendation.ReccomendationId = Guid.NewGuid();
                db.Recomendation.Add(reccomendation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeId = new SelectList(db.profile, "profileID", "lastName", reccomendation.employeeId);
            ViewBag.recognitionId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognitionId);
            ViewBag.recognizerId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognizerId);
            return View(reccomendation);
        }

        // GET: Reccomendations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reccomendation reccomendation = db.Recomendation.Find(id);
            if (reccomendation == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeId = new SelectList(db.profile, "profileID", "lastName", reccomendation.employeeId);
            ViewBag.recognitionId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognitionId);
            ViewBag.recognizerId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognizerId);
            return View(reccomendation);
        }

        // POST: Reccomendations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReccomendationId,employeeId,recognizerId,recognitionId,awardDate,description")] Reccomendation reccomendation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reccomendation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeId = new SelectList(db.profile, "profileID", "lastName", reccomendation.employeeId);
            ViewBag.recognitionId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognitionId);
            ViewBag.recognizerId = new SelectList(db.profile, "profileID", "lastName", reccomendation.recognizerId);
            return View(reccomendation);
        }

        // GET: Reccomendations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reccomendation reccomendation = db.Recomendation.Find(id);
            if (reccomendation == null)
            {
                return HttpNotFound();
            }
            return View(reccomendation);
        }

        // POST: Reccomendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reccomendation reccomendation = db.Recomendation.Find(id);
            db.Recomendation.Remove(reccomendation);
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
