using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategoryHelper CategoryHelper;

        public CategoryController(ICategoryHelper categoryHelper)
        {
            CategoryHelper = categoryHelper;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            CategoryHelper.Token = HttpContext.Session.GetString("token");
            return View(CategoryHelper.GetCategories());
        }


        [Authorize(Roles = "SuperAdmin")]
        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            CategoryViewModel category = CategoryHelper.GetCategory(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            try
            {
                _= CategoryHelper.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryViewModel category = CategoryHelper.GetCategory(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                _ = CategoryHelper.Update(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryViewModel category = CategoryHelper.GetCategory(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {
                _ = CategoryHelper.Remove(category.CategoryId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
