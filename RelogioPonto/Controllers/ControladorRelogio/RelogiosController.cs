using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelogioPonto.Models;

namespace RelogioPonto.Controllers.ControladorRelogio
{
    public class RelogiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Relogios
        public ActionResult Index()
        {
            return View(db.Relogios.ToList());
        }

        // GET: Relogios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relogio relogio = db.Relogios.Find(id);
            if (relogio == null)
            {
                return HttpNotFound();
            }
            return View(relogio);
        }

        // GET: Relogios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relogios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,StatusPapel,Login,Senha,Ip")] Relogio relogio)
        {
            if (ModelState.IsValid)
            {
                db.Relogios.Add(relogio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relogio);
        }

        // GET: Relogios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relogio relogio = db.Relogios.Find(id);
            if (relogio == null)
            {
                return HttpNotFound();
            }
            return View(relogio);
        }

        // POST: Relogios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,StatusPapel,Login,Senha,Ip")] Relogio relogio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relogio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relogio);
        }

        // GET: Relogios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relogio relogio = db.Relogios.Find(id);
            if (relogio == null)
            {
                return HttpNotFound();
            }
            return View(relogio);
        }

        // POST: Relogios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relogio relogio = db.Relogios.Find(id);
            db.Relogios.Remove(relogio);
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
