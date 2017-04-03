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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace BarsTest.Controllers
{
    public class ItemsController : Controller
    {
        //private BarsContext db = new BarsContext();

        UnitOfWork unitofwork = new UnitOfWork();

        // GET: Items
        public ActionResult Index()
        {
            //return View(db.Items.ToList());
            var items = unitofwork.Items.GetAll();
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {

            Item item = unitofwork.Items.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemCode,ItemDesc")] Item item)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Items.Create(item);

                /*string massage*/

                var save = unitofwork.Save();
               
                if (save!=null)
                {
                    ModelState.AddModelError("NotValid","Not unique");
                    return View(item);
                }

                //unitofwork.Save().IsValid;

                //    if (massage !="AllRight")
                //        {
                //            ModelState.AddModelError("NotValid", );
                //            return View(item);
                // }

                return RedirectToAction("Index");

            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {

            Item item = unitofwork.Items.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemCode,ItemDesc")] Item item)
        {
            if (ModelState.IsValid)
            {
                unitofwork.Items.Update(item);
                unitofwork.Save();
                //db.Entry(item).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            unitofwork.Items.Delete(id);

            unitofwork.Save();

            return RedirectToAction("Index");
        }

        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            gv.DataSource = unitofwork.Items.GetAll().ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Marklist.doc");
            Response.ContentType = "application/ms-word";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            unitofwork.Dispose();
            base.Dispose(disposing);
        }
    }
}
