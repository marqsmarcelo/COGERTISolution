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
    public class ComputadoresController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: Computadores
        public ActionResult Index()
        {
            var computadores = db.Computadores.Include(c => c.LocalSite).Include(c => c.Propriedade).Include(c => c.StatusEquipamento).Include(c => c.TipoComputador);
            return View(computadores.ToList());
        }

        // GET: Computadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadores.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }

        // GET: Computadores/Create
        public ActionResult Create()
        {
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome");
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote");
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao");
            ViewBag.TipoComputadorId = new SelectList(db.TiposComputadores, "Id", "Descricao");
            return View();
        }

        // POST: Computadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocalSiteId,SerialNo,Patrimonio,DataFabricacao,Marca,Modelo,PropriedadeId,StatusEquipamentoId,TipoComputadorId")] Computador computador)
        {
            if (ModelState.IsValid)
            {
                db.Computadores.Add(computador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", computador.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", computador.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", computador.StatusEquipamentoId);
            ViewBag.TipoComputadorId = new SelectList(db.TiposComputadores, "Id", "Descricao", computador.TipoComputadorId);
            return View(computador);
        }

        // GET: Computadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadores.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", computador.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", computador.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", computador.StatusEquipamentoId);
            ViewBag.TipoComputadorId = new SelectList(db.TiposComputadores, "Id", "Descricao", computador.TipoComputadorId);
            return View(computador);
        }

        // POST: Computadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocalSiteId,SerialNo,Patrimonio,DataFabricacao,Marca,Modelo,PropriedadeId,StatusEquipamentoId,TipoComputadorId")] Computador computador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", computador.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", computador.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", computador.StatusEquipamentoId);
            ViewBag.TipoComputadorId = new SelectList(db.TiposComputadores, "Id", "Descricao", computador.TipoComputadorId);
            return View(computador);
        }

        // GET: Computadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computador computador = db.Computadores.Find(id);
            if (computador == null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }

        // POST: Computadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computador computador = db.Computadores.Find(id);
            db.Computadores.Remove(computador);
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
