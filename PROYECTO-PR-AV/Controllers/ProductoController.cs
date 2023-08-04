using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROYECTO_PR_AV.Models;

namespace PROYECTO_PR_AV.Controllers
{
    
    public class ProductoController : Controller
    {
        private ProyectoGimnasioEntities db = new ProyectoGimnasioEntities();
        // GET: Producto
        public static List<Producto> listaProductos = new List<Producto>();
        public static Array array;
        public ActionResult Index()
        {
            List<Producto> productos = db.Productoes.ToList();
            return View(productos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public ActionResult Edit(int id)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public ActionResult Details(int id)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        public ActionResult Delete(int id)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            db.Productoes.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Carrito----------------------------------
        public ActionResult AgregarAlCarrito(int id)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                listaProductos.Add(producto);
                
                TempData["SuccessMessage"] = "El producto ha sido agregado al carrito";
            }
            array = listaProductos.ToArray();
            return RedirectToAction("Index");
        }

        public ActionResult VerCarrito()
        {
            ViewBag.successMessage = TempData["SuccessMessage"] as string;
            
            ViewBag.productos = array;
            return View();
        }

        
    }
}