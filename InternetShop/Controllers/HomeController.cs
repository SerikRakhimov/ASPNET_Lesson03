using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Список продуктов";

            using (var context = new Context())
            {
                ViewBag.Products = context.Products.ToList();
            }

            return View();
        }

        public ActionResult Product(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            using (var context = new Context())
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Product = product;
            }

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (product == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);

            }

            using (var context = new Context())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            return RedirectToAction("Products");
        }

        public ActionResult EditProduct()
        {
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            Product product = null;

            if (id == null)
            {
                return HttpNotFound();
            }

            using (var context = new Context())
            {
                product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Product = product;
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            Product prod;
            if (product == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            using (var context = new Context())
            {

                prod = context.Products.Find(product.Id);
                if (prod != null)
                {
                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Products");
        }

        public ActionResult DeleteProduct()
        {
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult DeleteProduct(int? id)
        {
            Product product = null;

            if (id == null)
            {
                return HttpNotFound();
            }

            using (var context = new Context())
            {
                product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Product = product;
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            Product prod;
            if (product == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            using (var context = new Context())
            {

                prod = context.Products.Find(product.Id);
                if (prod != null)
                {
                    context.Products.Remove(prod);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Products");
        }

    }
}