using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDMVC.Models;

namespace CRUDMVC.Controllers
{
    public class LIROesController : Controller
    {
        private BIBLIOTECAEntities db = new BIBLIOTECAEntities();

        // GET: LIROes
        public ActionResult Index()
        {
            return View(db.LIRO.ToList());
        }

        // GET: LIROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIRO lIRO = db.LIRO.Find(id);
            if (lIRO == null)
            {
                return HttpNotFound();
            }
            return View(lIRO);
        }

        // GET: LIROes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LIROes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,AUTOR,FECHA")] LIRO lIRO)
        {
            if (ModelState.IsValid)
            {
                db.LIRO.Add(lIRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIRO);
        }

        // GET: LIROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIRO lIRO = db.LIRO.Find(id);
            if (lIRO == null)
            {
                return HttpNotFound();
            }
            return View(lIRO);
        }

        // POST: LIROes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,AUTOR,FECHA")] LIRO lIRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIRO);
        }

        // GET: LIROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIRO lIRO = db.LIRO.Find(id);
            if (lIRO == null)
            {
                return HttpNotFound();
            }
            return View(lIRO);
        }

        // POST: LIROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIRO lIRO = db.LIRO.Find(id);
            db.LIRO.Remove(lIRO);
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
