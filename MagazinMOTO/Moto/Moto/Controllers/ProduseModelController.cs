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
    public class ProduseModelController : Controller
    {
        private ProdusDbContext db = new ProdusDbContext();

        // GET: ProduseModel
        public ActionResult Index()
        {
            return View(db.Produse.ToList());
        }

        // GET: ProduseModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduseModel produseModel = db.Produse.Find(id);
            if (produseModel == null)
            {
                return HttpNotFound();
            }
            return View(produseModel);
        }

        // GET: ProduseModel/Create
        public ActionResult Create()
        {
            ProduseModel p=new ProduseModel();
            return View(p);
        }

        // POST: ProduseModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nume,descriere,cantitate,producator")] ProduseModel produseModel)
        {
            if (ModelState.IsValid)
            {
                //db.Produse.Add(produseModel);
                //db.SaveChanges();
                ProdData.SignUpUser(db, produseModel.id, produseModel.nume, produseModel.descriere, produseModel.cantitate, produseModel.producator);
                return RedirectToAction("Index");
            }

            return View(produseModel);
        }

        // GET: ProduseModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduseModel produseModel = db.Produse.Find(id);
            if (produseModel == null)
            {
                return HttpNotFound();
            }
            return View(produseModel);
        }

        // POST: ProduseModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nume,descriere,cantitate,producator")] ProduseModel produseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produseModel);
        }

        // GET: ProduseModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduseModel produseModel = db.Produse.Find(id);
            if (produseModel == null)
            {
                return HttpNotFound();
            }
            return View(produseModel);
        }

        // POST: ProduseModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProduseModel produseModel = db.Produse.Find(id);
            db.Produse.Remove(produseModel);
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
