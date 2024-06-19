using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierService SupplierService { get; set; }



        public SupplierController(ISupplierService supplierService)
        {
                this.SupplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult Get()
        {

            var result = SupplierService.GetSuppliers();
            return new JsonResult(result);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = SupplierService.GetSuppliers();
            return new JsonResult(result);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
