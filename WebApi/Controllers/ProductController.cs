using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Business;
using WebApi.Domain;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.Get(id);
            if (product != null)
                return new ObjectResult(product);
            else
                return NotFound();
        }

        [HttpPost]
        public Result Post([FromBody]Product product)
        {
            return _service.Insert(product);
        }

        [HttpPut]
        public Result Put([FromBody]Product product)
        {
            return _service.Update(product);
        }

        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
