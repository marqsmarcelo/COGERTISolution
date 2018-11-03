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
    public class AssociacaoRecursosController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: AssociacaoRecursos
        public ActionResult Index()
        {
            var associacaoRecursos = db.AssociacaoRecursos.Include(a => a.Funcionario).Include(a => a.Recurso);
            return View(associacaoRecursos.ToList());
        }

        // GET: AssociacaoRecursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociacaoRecurso associacaoRecurso = db.AssociacaoRecursos.Find(id);
            if (associacaoRecurso == null)
            {
                return HttpNotFound();
            }
            return View(associacaoRecurso);
        }

        // GET: AssociacaoRecursos/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Id");
            return View();
        }

        // POST: AssociacaoRecursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FuncionarioUPI,RecursoId,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade")] AssociacaoRecurso associacaoRecurso)
        {
            if (ModelState.IsValid)
            {
                db.AssociacaoRecursos.Add(associacaoRecurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", associacaoRecurso.FuncionarioUPI);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Id", associacaoRecurso.RecursoId);
            return View(associacaoRecurso);
        }

        // GET: AssociacaoRecursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociacaoRecurso associacaoRecurso = db.AssociacaoRecursos.Find(id);
            if (associacaoRecurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", associacaoRecurso.FuncionarioUPI);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Id", associacaoRecurso.RecursoId);
            return View(associacaoRecurso);
        }

        // POST: AssociacaoRecursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FuncionarioUPI,RecursoId,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade")] AssociacaoRecurso associacaoRecurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associacaoRecurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", associacaoRecurso.FuncionarioUPI);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Id", associacaoRecurso.RecursoId);
            return View(associacaoRecurso);
        }

        // GET: AssociacaoRecursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociacaoRecurso associacaoRecurso = db.AssociacaoRecursos.Find(id);
            if (associacaoRecurso == null)
            {
                return HttpNotFound();
            }
            return View(associacaoRecurso);
        }

        // POST: AssociacaoRecursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociacaoRecurso associacaoRecurso = db.AssociacaoRecursos.Find(id);
            db.AssociacaoRecursos.Remove(associacaoRecurso);
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
