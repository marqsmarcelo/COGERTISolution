using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COGERTI.Models;

namespace COGERTI.Controllers
{
    public class CodigosDddController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: CodigosDdd
        public ActionResult Index()
        {
            return View(db.CodigosDdd.ToList());
        }

        // GET: CodigosDdd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoDdd codigoDdd = db.CodigosDdd.Find(id);
            if (codigoDdd == null)
            {
                return HttpNotFound();
            }
            return View(codigoDdd);
        }

        // GET: CodigosDdd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodigosDdd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DddCodigo,UF,Regiao")] CodigoDdd codigoDdd)
        {
            if (ModelState.IsValid)
            {
                db.CodigosDdd.Add(codigoDdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codigoDdd);
        }

        // GET: CodigosDdd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoDdd codigoDdd = db.CodigosDdd.Find(id);
            if (codigoDdd == null)
            {
                return HttpNotFound();
            }
            return View(codigoDdd);
        }

        // POST: CodigosDdd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DddCodigo,UF,Regiao")] CodigoDdd codigoDdd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codigoDdd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codigoDdd);
        }

        // GET: CodigosDdd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoDdd codigoDdd = db.CodigosDdd.Find(id);
            if (codigoDdd == null)
            {
                return HttpNotFound();
            }
            return View(codigoDdd);
        }

        // POST: CodigosDdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodigoDdd codigoDdd = db.CodigosDdd.Find(id);
            db.CodigosDdd.Remove(codigoDdd);
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
