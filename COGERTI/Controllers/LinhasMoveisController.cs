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
    public class LinhasMoveisController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: LinhasMoveis
        public ActionResult Index()
        {
            var linhasMoveis = db.LinhasMoveis.Include(l => l.Funcionario).Include(l => l.LocalSite).Include(l => l.CodigoDdd).Include(l => l.TipoLinha).Include(l => l.TipoPlanoMovel);
            return View(linhasMoveis.ToList());
        }

        // GET: LinhasMoveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaMovel linhaMovel = db.LinhasMoveis.Find(id);
            if (linhaMovel == null)
            {
                return HttpNotFound();
            }
            return View(linhaMovel);
        }

        // GET: LinhasMoveis/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome");
            ViewBag.CodigoDddId = new SelectList(db.CodigosDdd, "Id", "DddCodigo");
            ViewBag.TipoLinhaId = new SelectList(db.TiposLinhas, "Id", "Descricao");
            ViewBag.TipoPlanoMovelId = new SelectList(db.TiposPlanosMoveis, "Id", "Descricao");
            return View();
        }

        // POST: LinhasMoveis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,LinhaNo,ChipId,CodigoDddId,TipoLinhaId,TipoPlanoMovelId")] LinhaMovel linhaMovel)
        {
            if (ModelState.IsValid)
            {
                db.LinhasMoveis.Add(linhaMovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", linhaMovel.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", linhaMovel.LocalSiteId);
            ViewBag.CodigoDddId = new SelectList(db.CodigosDdd, "Id", "DddCodigo", linhaMovel.CodigoDddId);
            ViewBag.TipoLinhaId = new SelectList(db.TiposLinhas, "Id", "Descricao", linhaMovel.TipoLinhaId);
            ViewBag.TipoPlanoMovelId = new SelectList(db.TiposPlanosMoveis, "Id", "Descricao", linhaMovel.TipoPlanoMovelId);
            return View(linhaMovel);
        }

        // GET: LinhasMoveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaMovel linhaMovel = db.LinhasMoveis.Find(id);
            if (linhaMovel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", linhaMovel.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", linhaMovel.LocalSiteId);
            ViewBag.CodigoDddId = new SelectList(db.CodigosDdd, "Id", "DddCodigo", linhaMovel.CodigoDddId);
            ViewBag.TipoLinhaId = new SelectList(db.TiposLinhas, "Id", "Descricao", linhaMovel.TipoLinhaId);
            ViewBag.TipoPlanoMovelId = new SelectList(db.TiposPlanosMoveis, "Id", "Descricao", linhaMovel.TipoPlanoMovelId);
            return View(linhaMovel);
        }

        // POST: LinhasMoveis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,LinhaNo,ChipId,CodigoDddId,TipoLinhaId,TipoPlanoMovelId")] LinhaMovel linhaMovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhaMovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", linhaMovel.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", linhaMovel.LocalSiteId);
            ViewBag.CodigoDddId = new SelectList(db.CodigosDdd, "Id", "DddCodigo", linhaMovel.CodigoDddId);
            ViewBag.TipoLinhaId = new SelectList(db.TiposLinhas, "Id", "Descricao", linhaMovel.TipoLinhaId);
            ViewBag.TipoPlanoMovelId = new SelectList(db.TiposPlanosMoveis, "Id", "Descricao", linhaMovel.TipoPlanoMovelId);
            return View(linhaMovel);
        }

        // GET: LinhasMoveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaMovel linhaMovel = db.LinhasMoveis.Find(id);
            if (linhaMovel == null)
            {
                return HttpNotFound();
            }
            return View(linhaMovel);
        }

        // POST: LinhasMoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhaMovel linhaMovel = db.LinhasMoveis.Find(id);
            db.LinhasMoveis.Remove(linhaMovel);
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
