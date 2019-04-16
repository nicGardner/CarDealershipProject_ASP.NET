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
    public class carModelsController : Controller
    {
        private Models.Database db = new Models.Database();

        // GET: models
        // loads carModels/index with a list of all car models
        public ActionResult Index()
        {
            var models = db.models.Include(m => m.vehicleType);
            return View(models.ToList());
        }

        // GET: models/Details/5
        // is never called, because there are no additional details to be displayed
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: models/Create
        // loads the page carModels/create, with a list of all vehicle types
        public ActionResult Create()
        {
            ViewBag.vehicleTypeId = new SelectList(db.vehicleTypes, "vehicleTypeId", "name");
            return View();
        }

        // POST: models/Create
        // validates, then enters the info from the form into the db
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modelId,engineSize,doors,colour,vehicleTypeId,name")] model model)
        {
            if (ModelState.IsValid)
            {
                db.models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vehicleTypeId = new SelectList(db.vehicleTypes, "vehicleTypeId", "name", model.vehicleTypeId);
            return View(model);
        }

        // GET: models/Edit/5
        // loads the carModels/edit page, with the model with the selected id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.vehicleTypeId = new SelectList(db.vehicleTypes, "vehicleTypeId", "name", model.vehicleTypeId);
            return View(model);
        }

        // POST: models/Edit/5
        // validates, then updates the entry in the db with the coresponding id 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modelId,engineSize,doors,colour,vehicleTypeId,name")] model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vehicleTypeId = new SelectList(db.vehicleTypes, "vehicleTypeId", "name", model.vehicleTypeId);
            return View(model);
        }

        // GET: models/Delete/5
        // loads the carModels/delete page with the model with the selected id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: models/Delete/5
        // deletes the entry from the db with the coresponding id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            model model = db.models.Find(id);
            db.models.Remove(model);
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
