using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name ="Elma",Quantity=8},
            new Product { Id = 2, Name ="Erik",Quantity =15},
            new Product { Id = 3, Name ="Üzüm",Quantity=28}
        };
        [HttpGet("{productId}")]
        [Authorize(Policy = "ReadProduct")]
        public IActionResult GetProductNameById(int productId)
        {
            return Ok(products.Find(f => f.Id == productId));
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
