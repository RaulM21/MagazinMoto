using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moto.Models;

namespace Moto.Controllers
{
    public class AngajatiModelController : Controller
    {
        private AngajatDbContext db = new AngajatDbContext();

        // GET: AngajatiModel
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: AngajatiModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AngajatiModel angajatiModel = db.Employees.Find(id);
            if (angajatiModel == null)
            {
                return HttpNotFound();
            }
            return View(angajatiModel);
        }

        // GET: AngajatiModel/Create
        public ActionResult Create()
        {
            AngajatiModel e= new AngajatiModel();
            return View(e);
        }

        // POST: AngajatiModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nume,prenume,functie")] AngajatiModel angajatiModel)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(angajatiModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(angajatiModel);
        }

        // GET: AngajatiModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AngajatiModel angajatiModel = db.Employees.Find(id);
            if (angajatiModel == null)
            {
                return HttpNotFound();
            }
            return View(angajatiModel);
        }

        // POST: AngajatiModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nume,prenume,functie")] AngajatiModel angajatiModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(angajatiModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(angajatiModel);
        }

        // GET: AngajatiModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AngajatiModel angajatiModel = db.Employees.Find(id);
            if (angajatiModel == null)
            {
                return HttpNotFound();
            }
            return View(angajatiModel);
        }

        // POST: AngajatiModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AngajatiModel angajatiModel = db.Employees.Find(id);
            db.Employees.Remove(angajatiModel);
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
