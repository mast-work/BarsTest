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
    public class DeliveriesController : Controller
    {
        UnitOfWork unitofwork = new UnitOfWork();

        // GET: Deliveries
        public ActionResult Index()
        {
            
            return View(unitofwork.Deliveryes.GetAll());
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int id)
        {


            Delivery delivery = unitofwork.Deliveryes.Get(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item,Supp,DateDelivery")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Deliveryes.Create(delivery);
                unitofwork.Save();
                return RedirectToAction("Index");
            }

            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int id)
        {

            Delivery delivery = unitofwork.Deliveryes.Get(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item,Supp,DateDelivery")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Deliveryes.Update(delivery); //Entry(delivery).State = EntityState.Modified;
                unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int id)
        {

            unitofwork.Deliveryes.Delete(id);
            unitofwork.Save();

            return RedirectToAction("Index");//View(delivery);
        }

        protected override void Dispose(bool disposing)
        {
            unitofwork.Dispose();
            base.Dispose(disposing);
        }
    }
}
