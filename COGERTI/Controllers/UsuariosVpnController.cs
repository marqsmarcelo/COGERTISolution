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
    public class UsuariosVpnController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: UsuariosVpn
        public ActionResult Index()
        {
            var usuariosVpn = db.UsuariosVpn.Include(u => u.Funcionario).Include(u => u.LocalSite);
            return View(usuariosVpn.ToList());
        }

        // GET: UsuariosVpn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioVpn usuarioVpn = db.UsuariosVpn.Find(id);
            if (usuarioVpn == null)
            {
                return HttpNotFound();
            }
            return View(usuarioVpn);
        }

        // GET: UsuariosVpn/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome");
            return View();
        }

        // POST: UsuariosVpn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,Usuario")] UsuarioVpn usuarioVpn)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosVpn.Add(usuarioVpn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", usuarioVpn.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", usuarioVpn.LocalSiteId);
            return View(usuarioVpn);
        }

        // GET: UsuariosVpn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioVpn usuarioVpn = db.UsuariosVpn.Find(id);
            if (usuarioVpn == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", usuarioVpn.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", usuarioVpn.LocalSiteId);
            return View(usuarioVpn);
        }

        // POST: UsuariosVpn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,Usuario")] UsuarioVpn usuarioVpn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioVpn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", usuarioVpn.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", usuarioVpn.LocalSiteId);
            return View(usuarioVpn);
        }

        // GET: UsuariosVpn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioVpn usuarioVpn = db.UsuariosVpn.Find(id);
            if (usuarioVpn == null)
            {
                return HttpNotFound();
            }
            return View(usuarioVpn);
        }

        // POST: UsuariosVpn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioVpn usuarioVpn = db.UsuariosVpn.Find(id);
            db.UsuariosVpn.Remove(usuarioVpn);
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
