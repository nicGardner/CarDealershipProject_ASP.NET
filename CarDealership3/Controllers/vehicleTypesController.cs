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
    public class vehicleTypesController : Controller
    {
        private Models.Database db = new Models.Database();

        // GET: vehicleTypes
        // loads the vehicleTypes/index page with a list of vehicle types from the db
        public ActionResult Index()
        {
            return View(db.vehicleTypes.ToList());
        }

        // GET: vehicleTypes/Details/5
        // never called because there are no additional relevant details to show
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleType vehicleType = db.vehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // GET: vehicleTypes/Create
        // loads the vehicleTypes/create page
        public ActionResult Create()
        {
            return View();
        }

        // POST: vehicleTypes/Create
        // validates, then adds to the db with info from the form
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleTypeId,name")] vehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                db.vehicleTypes.Add(vehicleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleType);
        }

        // GET: vehicleTypes/Edit/5
        // loads the vehicleTypes/edit page with the vehicle with the coresponding id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleType vehicleType = db.vehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: vehicleTypes/Edit/5
        // validates, then updates the db entry with the coresponding id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleTypeId,name")] vehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleType);
        }

        // GET: vehicleTypes/Delete/5
        // loads the vehicleTypes/delete page with the vehicleType with the coresponding id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicleType vehicleType = db.vehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: vehicleTypes/Delete/5
        // deletes the entry from the db with the coresponding id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleType vehicleType = db.vehicleTypes.Find(id);
            db.vehicleTypes.Remove(vehicleType);
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
