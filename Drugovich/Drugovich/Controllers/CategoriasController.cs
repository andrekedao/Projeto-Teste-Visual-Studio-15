using Drugovich.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Net;
using Drugovich.Contexts;

namespace Drugovich.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext ctx = new EFContext();

        private static IList<Categoria> categorias = new List<Categoria>()
     {
         new Categoria()
         {
             CategoriaId = 1,
             Nome = "Motor"
         },
         new Categoria()
         {
             CategoriaId = 2,
             Nome = "Arrefecimento"
         },
         new Categoria()
         {
             CategoriaId = 3,
             Nome = "Caixa de Mudancas"
         },
         new Categoria()
         {
             CategoriaId = 4,
             Nome = "Freios"
         },
         new Categoria()
         {
             CategoriaId = 5,
             Nome = "Eixo Traseiro"
         }
     };
        
        // GET Categorias
        public ActionResult Index()
        {
            return View(ctx.Categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = ctx.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = ctx.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = ctx.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = ctx.Categorias.Find(id);
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}