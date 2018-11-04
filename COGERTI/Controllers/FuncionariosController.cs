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
    public class FuncionariosController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.CentroDeCusto).Include(f => f.LocalSite).Include(f => f.StatusFuncionario);
            return View(funcionarios.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.CentroDeCustoId = new SelectList(db.CentrosDeCustos, "Id", "Nome");
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome");
            ViewBag.StatusFuncionarioId = new SelectList(db.StatusFuncionarios, "Id", "Descricao");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UPI,Nome,Sobrenome,UsuarioGad,LocalSiteId,StatusFuncionarioId,CentroDeCustoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroDeCustoId = new SelectList(db.CentrosDeCustos, "Id", "Nome", funcionario.CentroDeCustoId);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", funcionario.LocalSiteId);
            ViewBag.StatusFuncionarioId = new SelectList(db.StatusFuncionarios, "Id", "Descricao", funcionario.StatusFuncionarioId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroDeCustoId = new SelectList(db.CentrosDeCustos, "Id", "Nome", funcionario.CentroDeCustoId);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", funcionario.LocalSiteId);
            ViewBag.StatusFuncionarioId = new SelectList(db.StatusFuncionarios, "Id", "Descricao", funcionario.StatusFuncionarioId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UPI,Nome,Sobrenome,UsuarioGad,LocalSiteId,StatusFuncionarioId,CentroDeCustoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroDeCustoId = new SelectList(db.CentrosDeCustos, "Id", "Nome", funcionario.CentroDeCustoId);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", funcionario.LocalSiteId);
            ViewBag.StatusFuncionarioId = new SelectList(db.StatusFuncionarios, "Id", "Descricao", funcionario.StatusFuncionarioId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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
