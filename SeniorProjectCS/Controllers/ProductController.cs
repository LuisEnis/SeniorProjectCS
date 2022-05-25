using SeniorProjectCS.Models;
using SeniorProjectCS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace SeniorProjectCS.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext _context;

        public ProductController()
        {
            _context = new StoreContext();
        }

        public ActionResult Create()
        {
            var _categories = _context.Categories.ToList();
            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
                Categories = _categories
            };
            viewModel.Product.Id = 0;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            if (!ModelState.IsValid)
                return View("Create", product);

            if (product.Id > 0)
                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Products.Add(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (_product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Product = _product,
                Categories = _context.Categories.ToList()
            };

            return View("Create", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (_product == null)
                return HttpNotFound();

            _context.Products.Remove(_product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Product
        public ActionResult Index(string searched, decimal? searched2, int? catId)
        {
            //Because of the foreign key that the product table has we have to use the include there which is different from other times we have done this(this is called eager loading)
            var products = _context.Products.Include(c => c.Category).ToList();
            if (catId != null)
            {
                products = products.Where(p => p.CategoryId == catId).ToList();
            }

            if (searched != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(searched.ToLower())).ToList();
            }

            if(searched2 != null)
            {
                products = products.Where(p => p.Price<=searched2).ToList();
            }
            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}