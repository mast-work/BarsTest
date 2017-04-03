using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarsTest.DAL;
using BarsTest.Models;

namespace BarsTest.Controllers
{
    public class SuppsController : Controller
    {
        UnitOfWork unitofwork = new UnitOfWork();

        // GET: Supps
        public ActionResult Index()
        {
            return View(unitofwork.Supps.GetAll());
        }

        // GET: Supps/Details/5
        public ActionResult Details(int id)
        {
            Supp supp = unitofwork.Supps.Get(id);
            if (supp == null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }

        // GET: Supps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supps/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuppCode,SuppName")] Supp supp)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Supps.Create(supp);
                unitofwork.Save();
                return RedirectToAction("Index");
            }

            return View(supp);
        }

        // GET: Supps/Edit/5
        public ActionResult Edit(int id)
        {

            Supp supp = unitofwork.Supps.Get(id);
            unitofwork.Save();
            if (supp == null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }

        // POST: Supps/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuppCode,SuppName")] Supp supp)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Supps.Update(supp);/* .Entry(supp).State = EntityState.Modified;*/
                unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(supp);
        }

        // GET: Supps/Delete/5
        public ActionResult Delete(int id)
        {
            Supp supp = unitofwork.Supps.Get(id);
            unitofwork.Save();
            if (supp == null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }


        protected override void Dispose(bool disposing)
        {
            unitofwork.Dispose();
            base.Dispose(disposing);
        }
    }
}
