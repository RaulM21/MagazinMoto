using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moto.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Moto.Controllers
{
    public class UserModelController : Controller
    {
        private UtilizatorDbContext db = new UtilizatorDbContext();

        // GET: UserModel
        public ActionResult Index()
        {
            return View(db.Utilizatori.ToList());
        }

        // GET: UserModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.Utilizatori.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // GET: UserModel/Create
        public ActionResult Create()
        {
            UserModel u = new UserModel();
            return View(u);
        }

        // POST: UserModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nume,prenume,username,password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // db.Utilizatori.Add(userModel);
                //db.SaveChanges();
                Data dt = new Data();
                dt.SignUpUser(db, userModel.id, userModel.nume, userModel.prenume, userModel.username, userModel.password);
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: UserModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.Utilizatori.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: UserModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nume,prenume,username,password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        // GET: UserModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.Utilizatori.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: UserModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextWriterTraceListener LogInfo = new TextWriterTraceListener("C:\\Users\\Alex\\source\\repos\\Moto\\Moto\\Log.txt", "LogInfo");
            UserModel userModel = db.Utilizatori.Find(id);
            LogInfo.Write("Utilizatorul " + userModel.username + "a fost eliminat");
            LogInfo.Flush();
            Trace.Close();
            db.Utilizatori.Remove(userModel);
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
