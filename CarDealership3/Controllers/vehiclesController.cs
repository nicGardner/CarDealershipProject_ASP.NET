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
    public class vehiclesController : Controller
    {
        private Models.Database db = new Models.Database();

        // GET: vehicles
        // loads the vehicles/index page with a list of vehicles from the db
        public ActionResult Index()
        {
            var vehicles = db.vehicles.Include(v => v.make).Include(v => v.model);
            return View(vehicles.ToList());
        }

        // GET: vehicles/Details/5
        // returns the vehicles/details page with the vehicle with the coresponding id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: vehicles/Create
        // loads the vehicles/create page with a list of makes and models from the db
        public ActionResult Create()
        {
            ViewBag.makeId = new SelectList(db.makes, "makeId", "name");
            ViewBag.modelId = new SelectList(db.models, "modelId", "fullName");
            return View();
        }

        // POST: vehicles/Create
        // validates, then adds a new entry to the db
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleId,makeId,modelId,year,price,cost,soldDate")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                // if the user entered no sold date, then there should be no cost either, so set cost to null
                if (vehicle.soldDate.Equals(null))
                {
                    vehicle.cost = null;
                }
                db.vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makeId = new SelectList(db.makes, "makeId", "name", vehicle.makeId);
            ViewBag.modelId = new SelectList(db.models, "modelId", "colour", vehicle.modelId);
            return View(vehicle);
        }

        // GET: vehicles/Edit/5
        // loads the vehicles/edit page with the vehicle with the coresponding id, and a list of makes and models from the db
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.makeId = new SelectList(db.makes, "makeId", "name", vehicle.makeId);
            ViewBag.modelId = new SelectList(db.models, "modelId", "fullName", vehicle.modelId);
            return View(vehicle);
        }

        // POST: vehicles/Edit/5
        // validates, then updates the db entry with the coresponding id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleId,makeId,modelId,year,price,cost,soldDate")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                // if the user entered no sold date, then there should be no cost either, so set cost to null
                if (vehicle.soldDate.Equals(null))
                {
                    vehicle.cost = null;
                }
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makeId = new SelectList(db.makes, "makeId", "name", vehicle.makeId);
            ViewBag.modelId = new SelectList(db.models, "modelId", "colour", vehicle.modelId);
            return View(vehicle);
        }

        // GET: vehicles/Delete/5
        // loads the vehicles/delete page with the vehicle with the coresponding id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: vehicles/Delete/5
        // validates, then deletes the db entry with the coresponding id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            db.vehicles.Remove(vehicle);
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
