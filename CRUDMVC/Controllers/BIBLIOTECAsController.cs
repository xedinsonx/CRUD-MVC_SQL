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
    public class BIBLIOTECAsController : Controller
    {
        private BIBLIOTECAEntities db = new BIBLIOTECAEntities();

        // GET: BIBLIOTECAs
        public ActionResult Index()
        {
            var bIBLIOTECA = db.BIBLIOTECA.Include(b => b.LIRO).Include(b => b.USUARIO);
            return View(bIBLIOTECA.ToList());
        }

        // GET: BIBLIOTECAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIBLIOTECA bIBLIOTECA = db.BIBLIOTECA.Find(id);
            if (bIBLIOTECA == null)
            {
                return HttpNotFound();
            }
            return View(bIBLIOTECA);
        }

        // GET: BIBLIOTECAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_LIBRO = new SelectList(db.LIRO, "ID", "NOMBRE");
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA");
            return View();
        }

        // POST: BIBLIOTECAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_USUARIO,ID_LIBRO")] BIBLIOTECA bIBLIOTECA)
        {
            if (ModelState.IsValid)
            {
                db.BIBLIOTECA.Add(bIBLIOTECA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRO = new SelectList(db.LIRO, "ID", "NOMBRE", bIBLIOTECA.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", bIBLIOTECA.NOMBRE_USUARIO);
            return View(bIBLIOTECA);
        }

        // GET: BIBLIOTECAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIBLIOTECA bIBLIOTECA = db.BIBLIOTECA.Find(id);
            if (bIBLIOTECA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRO = new SelectList(db.LIRO, "ID", "NOMBRE", bIBLIOTECA.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", bIBLIOTECA.NOMBRE_USUARIO);
            return View(bIBLIOTECA);
        }

        // POST: BIBLIOTECAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_USUARIO,ID_LIBRO")] BIBLIOTECA bIBLIOTECA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIBLIOTECA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRO = new SelectList(db.LIRO, "ID", "NOMBRE", bIBLIOTECA.ID_LIBRO);
            ViewBag.NOMBRE_USUARIO = new SelectList(db.USUARIO, "NOMBRE", "CONTRASEÑA", bIBLIOTECA.NOMBRE_USUARIO);
            return View(bIBLIOTECA);
        }

        // GET: BIBLIOTECAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIBLIOTECA bIBLIOTECA = db.BIBLIOTECA.Find(id);
            if (bIBLIOTECA == null)
            {
                return HttpNotFound();
            }
            return View(bIBLIOTECA);
        }

        // POST: BIBLIOTECAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BIBLIOTECA bIBLIOTECA = db.BIBLIOTECA.Find(id);
            db.BIBLIOTECA.Remove(bIBLIOTECA);
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
