using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        IProductHelper ProductHelper;
        ICategoryHelper CategoryHelper;
        ISupplierHelper SupplierHelper;


        public ProductController(IProductHelper productHelper, ICategoryHelper categoryHelper, ISupplierHelper supplierHelper)
        {
                this.ProductHelper = productHelper;
            this.CategoryHelper = categoryHelper;   
            this.SupplierHelper = supplierHelper;
        }


        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> lista = ProductHelper.GetAll();

            foreach (var item in lista)
            {
                item.Category = CategoryHelper.GetCategory((int)item.CategoryId);
            }


            return View(lista);
           
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ProductViewModel product = new ProductViewModel();
            product.Suppliers = SupplierHelper.GetAll();
            product.Categories = CategoryHelper.GetCategories();

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                ProductHelper.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = ProductHelper.GetById(id);
            product.Suppliers = SupplierHelper.GetAll();
            product.Categories = CategoryHelper.GetCategories();

            return View(product);
        }

        // POST: ProductController/Edit/5
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                ProductHelper.EdiProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = ProductHelper.GetById(id);

            return View(product);
        }


        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                ProductHelper.DeleteProduct(product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
