using Drugovich.Contexts;
using Drugovich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Drugovich.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext ctx = new EFContext();

        // GET: Fabricantes
        public ActionResult Index()
        {
            var sql = "select * from Fabricantes order by Nome";
            return View(ctx.Fabricantes.SqlQuery(sql));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            ctx.Fabricantes.Add(fabricante);
            ctx.SaveChanges();
                       
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = ctx.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricante);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = ctx.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = ctx.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = ctx.Fabricantes.Find(id);
            ctx.Fabricantes.Remove(fabricante);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}