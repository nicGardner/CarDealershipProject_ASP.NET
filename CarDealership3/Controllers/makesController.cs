using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealership3.Models;

namespace CarDealership3.Controllers
{
    public class makesController : Controller
    {
        private Models.Database db = new Models.Database();

        // GET: makes
        // loads the makes/index page with a list of all makes from the db
        public ActionResult Index()
        {
            return View(db.makes.ToList());
        }

        // GET: makes/Details/5
        // not called, because there is no additional relevant detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            make make = db.makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // GET: makes/Create
        // loads the makes/create page
        public ActionResult Create()
        {
            return View();
        }

        // POST: makes/Create
        // validates, then adds a new entry into the db with info from the form
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makeId,name")] make make)
        {
            if (ModelState.IsValid)
            {
                db.makes.Add(make);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(make);
        }

        // GET: makes/Edit/5
        // loads the makes/edit page with the make with the coresponding id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            make make = db.makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // POST: makes/Edit/5
        // validates, then updates the entry in the db with the coresponding id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makeId,name")] make make)
        {
            if (ModelState.IsValid)
            {
                db.Entry(make).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

        // GET: makes/Delete/5
        // loads the makes/delete page with the make with the coresponding id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            make make = db.makes.Find(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        // POST: makes/Delete/5
        // deletes the entry from the db with the coresponding id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            make make = db.makes.Find(id);
            db.makes.Remove(make);
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
