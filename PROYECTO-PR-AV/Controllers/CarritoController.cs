using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROYECTO_PR_AV.Models;
using Microsoft.AspNet.Identity;

namespace PROYECTO_PR_AV.Controllers
{
    public class CarritoController : Controller
    {
        private ProyectoGimnasioEntities db = new ProyectoGimnasioEntities();
        // GET: Carrito

        public static List<Producto> listaProductos = new List<Producto>();
        public static Array array;
        public ActionResult Index()
        {
            return View();
        }

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
            return RedirectToAction("VerCarrito");
        }

        public ActionResult VerCarrito()
        {
            ViewBag.successMessage = TempData["SuccessMessage"] as string;

            ViewBag.productos = array;
            return View();
        }
    }
}