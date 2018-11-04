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
    public class AparelhosCelularesController : Controller
    {
        private RecursosDB db = new RecursosDB();

        // GET: AparelhosCelulares
        public ActionResult Index()
        {
            var aparelhosCelulares = db.AparelhosCelulares.Include(a => a.Funcionario).Include(a => a.LocalSite).Include(a => a.Propriedade).Include(a => a.StatusEquipamento).Include(a => a.TipoAparelhoCelular);
            return View(aparelhosCelulares.ToList());
        }

        // GET: AparelhosCelulares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AparelhoCelular aparelhoCelular = db.AparelhosCelulares.Find(id);
            if (aparelhoCelular == null)
            {
                return HttpNotFound();
            }
            return View(aparelhoCelular);
        }

        // GET: AparelhosCelulares/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome");
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome");
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote");
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao");
            ViewBag.TipoAparelhoCelularId = new SelectList(db.TiposAparelhosCelulares, "Id", "Descricao");
            return View();
        }

        // POST: AparelhosCelulares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,SerialNo,Patrimonio,DataFabricacao,Marca,Modelo,PropriedadeId,StatusEquipamentoId,IMEI1,IMEI2,TipoAparelhoCelularId")] AparelhoCelular aparelhoCelular)
        {
            if (ModelState.IsValid)
            {
                db.AparelhosCelulares.Add(aparelhoCelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", aparelhoCelular.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", aparelhoCelular.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", aparelhoCelular.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", aparelhoCelular.StatusEquipamentoId);
            ViewBag.TipoAparelhoCelularId = new SelectList(db.TiposAparelhosCelulares, "Id", "Descricao", aparelhoCelular.TipoAparelhoCelularId);
            return View(aparelhoCelular);
        }

        // GET: AparelhosCelulares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AparelhoCelular aparelhoCelular = db.AparelhosCelulares.Find(id);
            if (aparelhoCelular == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", aparelhoCelular.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", aparelhoCelular.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", aparelhoCelular.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", aparelhoCelular.StatusEquipamentoId);
            ViewBag.TipoAparelhoCelularId = new SelectList(db.TiposAparelhosCelulares, "Id", "Descricao", aparelhoCelular.TipoAparelhoCelularId);
            return View(aparelhoCelular);
        }

        // POST: AparelhosCelulares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LocalSiteId,FuncionarioUPI,DataAssociacao,DataLiberacao,MotivoLiberacao,TermoResponsabilidade,SerialNo,Patrimonio,DataFabricacao,Marca,Modelo,PropriedadeId,StatusEquipamentoId,IMEI1,IMEI2,TipoAparelhoCelularId")] AparelhoCelular aparelhoCelular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aparelhoCelular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioUPI = new SelectList(db.Funcionarios, "UPI", "Nome", aparelhoCelular.FuncionarioUPI);
            ViewBag.LocalSiteId = new SelectList(db.LocalSites, "Id", "Nome", aparelhoCelular.LocalSiteId);
            ViewBag.PropriedadeId = new SelectList(db.PropriedadeEquipamentos, "Id", "Lote", aparelhoCelular.PropriedadeId);
            ViewBag.StatusEquipamentoId = new SelectList(db.StatusEquipamentos, "Id", "Descricao", aparelhoCelular.StatusEquipamentoId);
            ViewBag.TipoAparelhoCelularId = new SelectList(db.TiposAparelhosCelulares, "Id", "Descricao", aparelhoCelular.TipoAparelhoCelularId);
            return View(aparelhoCelular);
        }

        // GET: AparelhosCelulares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AparelhoCelular aparelhoCelular = db.AparelhosCelulares.Find(id);
            if (aparelhoCelular == null)
            {
                return HttpNotFound();
            }
            return View(aparelhoCelular);
        }

        // POST: AparelhosCelulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AparelhoCelular aparelhoCelular = db.AparelhosCelulares.Find(id);
            db.AparelhosCelulares.Remove(aparelhoCelular);
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
