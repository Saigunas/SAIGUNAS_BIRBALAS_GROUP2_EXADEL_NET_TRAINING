﻿using Microsoft.AspNetCore.Mvc;
using Task13.Models;

namespace Task13.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        ProductRepository db = new ProductRepository("TestDb");

        [HttpPost]
        public IActionResult CreateProducts(List<Product> products)
        {
            db.InsertProducts("Products", products);
            return CreatedAtRoute(GetProducts(), products);
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<List<Product>> GetProducts()
        {
            var products = await db.GetProductsAsync();
            return products;
        }

        [HttpGet(Name = "GetUpdatedProducts")]
        public List<Product> GetUpdatedProducts()
        {
            var products = db.GetUpdatedProducts();
            return products;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateName(Guid id, [FromBody] string name)
        {
            await db.UpdateProductName(id, name);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await db.DeleteProductAsync(id);
            return new NoContentResult();
        }
    }
}
