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
    public class CentrosDeCustosController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: CentrosDeCustos
        public ActionResult Index()
        {
            var centrosDeCustos = db.CentrosDeCustos.Include(c => c.CoordenadorCC).Include(c => c.GestorCC);
            return View(centrosDeCustos.ToList());
        }

        // GET: CentrosDeCustos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroDeCusto centroDeCusto = db.CentrosDeCustos.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // GET: CentrosDeCustos/Create
        public ActionResult Create()
        {
            ViewBag.CoordenadorUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            ViewBag.GestorUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            return View();
        }

        // POST: CentrosDeCustos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CoordenadorUPI,GestorUPI")] CentroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                db.CentrosDeCustos.Add(centroDeCusto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoordenadorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.CoordenadorUPI);
            ViewBag.GestorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.GestorUPI);
            return View(centroDeCusto);
        }

        // GET: CentrosDeCustos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroDeCusto centroDeCusto = db.CentrosDeCustos.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoordenadorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.CoordenadorUPI);
            ViewBag.GestorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.GestorUPI);
            return View(centroDeCusto);
        }

        // POST: CentrosDeCustos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CoordenadorUPI,GestorUPI")] CentroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroDeCusto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoordenadorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.CoordenadorUPI);
            ViewBag.GestorUPI = new SelectList(db.Funcionarios, "UPI", "Nome", centroDeCusto.GestorUPI);
            return View(centroDeCusto);
        }

        // GET: CentrosDeCustos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroDeCusto centroDeCusto = db.CentrosDeCustos.Find(id);
            if (centroDeCusto == null)
            {
                return HttpNotFound();
            }
            return View(centroDeCusto);
        }

        // POST: CentrosDeCustos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroDeCusto centroDeCusto = db.CentrosDeCustos.Find(id);
            db.CentrosDeCustos.Remove(centroDeCusto);
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
