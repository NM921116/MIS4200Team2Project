using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200Team2Project.DAL;
using MIS4200Team2Project.Models;

namespace MIS4200Team2Project.Controllers
{
    public class NewProfileController : Controller
    {
        private MIS4200Team2Context db = new MIS4200Team2Context();

        // GET: NewProfile
        public ActionResult Index()
        {
            return View(db.profile.ToList());
        }

        // GET: NewProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Guid profileID;
                Guid.TryParse(User.Identity.GetUserId(), out profileID);
                id = profileID;
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: NewProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileID,lastName,firstName,Date,phone,email,position,operatingGroup,city,state,bio,buildingImage,role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //profile.profileID = Guid.NewGuid();
                Guid profileID;
                Guid.TryParse(User.Identity.GetUserId(), out profileID);
                profile.profileID = profileID;
                db.profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: NewProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: NewProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileID,lastName,firstName,Date,phone,email,position,operatingGroup,city,state,bio,buildingImage,role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: NewProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: NewProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.profile.Find(id);
            db.profile.Remove(profile);
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
