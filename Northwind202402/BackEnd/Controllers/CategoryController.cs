using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
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
        ILogger<CategoryController> _logger;


        public CategoryController(ICategoryService categoryService,
               ILogger<CategoryController> logger     )
        {
            this._categoryService = categoryService;
            this._logger = logger;
        }

        // GET: api/<CategoryController>
        [Authorize]
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            try
            {
                _logger.LogDebug("INGRESO A GETALL");
                return _categoryService.Get();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
           
          
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
