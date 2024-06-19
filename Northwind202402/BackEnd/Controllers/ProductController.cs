using BackEnd.Model;

using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductService ProductService;

        public ProductController(IProductService productService)
        {
                ProductService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult Get()
        {
            List<ProductModel> result = ProductService.GetProducts();

            return new JsonResult(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ProductModel result = ProductService.GetProduct(id);

            return new JsonResult(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductModel product)
        {

            var result = ProductService.Add(product);

            return new JsonResult(result);

        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public ActionResult Put([FromBody] ProductModel product)
        {

            var result = ProductService.Update(product);

            return new JsonResult(result);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = ProductService.Delete(id);

            return new JsonResult(result);
        }
    }
}
