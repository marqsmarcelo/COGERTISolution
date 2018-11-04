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
    public class LocalSitesController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: LocalSites
        public ActionResult Index()
        {
            return View(db.LocalSites.ToList());
        }

        // GET: LocalSites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalSite localSite = db.LocalSites.Find(id);
            if (localSite == null)
            {
                return HttpNotFound();
            }
            return View(localSite);
        }

        // GET: LocalSites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sigla,UF")] LocalSite localSite)
        {
            if (ModelState.IsValid)
            {
                db.LocalSites.Add(localSite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localSite);
        }

        // GET: LocalSites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalSite localSite = db.LocalSites.Find(id);
            if (localSite == null)
            {
                return HttpNotFound();
            }
            return View(localSite);
        }

        // POST: LocalSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sigla,UF")] LocalSite localSite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localSite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localSite);
        }

        // GET: LocalSites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalSite localSite = db.LocalSites.Find(id);
            if (localSite == null)
            {
                return HttpNotFound();
            }
            return View(localSite);
        }

        // POST: LocalSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalSite localSite = db.LocalSites.Find(id);
            db.LocalSites.Remove(localSite);
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
