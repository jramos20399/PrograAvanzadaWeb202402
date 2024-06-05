using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            return _categoryService.Get();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryModel Get(int id)
        {
            return _categoryService.Get(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public CategoryModel Post([FromBody] CategoryModel category)
        {
            _categoryService.Add(category);
            return category;

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public CategoryModel Put([FromBody] CategoryModel category)
        {
            _categoryService.Update(category);
            return category;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryModel category = new CategoryModel { CategoryId = id };
            _categoryService.Remove(category);

        }
    }
}
