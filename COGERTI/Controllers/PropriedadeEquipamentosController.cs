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
    public class PropriedadeEquipamentosController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: PropriedadeEquipamentos
        public ActionResult Index()
        {
            return View(db.PropriedadeEquipamentos.ToList());
        }

        // GET: PropriedadeEquipamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropriedadeEquipamento propriedadeEquipamento = db.PropriedadeEquipamentos.Find(id);
            if (propriedadeEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(propriedadeEquipamento);
        }

        // GET: PropriedadeEquipamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropriedadeEquipamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Lote,PedidoSapNo,ContratoNo,DataCompra,DataRecebimento,DataTerminoGarantia")] PropriedadeEquipamento propriedadeEquipamento)
        {
            if (ModelState.IsValid)
            {
                db.PropriedadeEquipamentos.Add(propriedadeEquipamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propriedadeEquipamento);
        }

        // GET: PropriedadeEquipamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropriedadeEquipamento propriedadeEquipamento = db.PropriedadeEquipamentos.Find(id);
            if (propriedadeEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(propriedadeEquipamento);
        }

        // POST: PropriedadeEquipamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Lote,PedidoSapNo,ContratoNo,DataCompra,DataRecebimento,DataTerminoGarantia")] PropriedadeEquipamento propriedadeEquipamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propriedadeEquipamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propriedadeEquipamento);
        }

        // GET: PropriedadeEquipamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropriedadeEquipamento propriedadeEquipamento = db.PropriedadeEquipamentos.Find(id);
            if (propriedadeEquipamento == null)
            {
                return HttpNotFound();
            }
            return View(propriedadeEquipamento);
        }

        // POST: PropriedadeEquipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropriedadeEquipamento propriedadeEquipamento = db.PropriedadeEquipamentos.Find(id);
            db.PropriedadeEquipamentos.Remove(propriedadeEquipamento);
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
