using Microsoft.AspNetCore.Mvc;
using DuAn1.data;
using DuAn1.model;
using Microsoft.EntityFrameworkCore;
namespace DuAn1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var products = await _context.Products.FindAsync(id);
            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Product product)
        {
            var eProduct = await _context.Products.FindAsync(id);
            if (eProduct != null)
                return NotFound();
            eProduct.NameProduct = product.NameProduct;
            eProduct.Description = product.Description;
            await _context.SaveChangesAsync();
            return Ok(eProduct);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Product product)
        { 
            var dProduct = await _context.Products.FindAsync(id);
            if (dProduct == null)
                return NotFound();
             _context.Remove(dProduct);
            await _context.SaveChangesAsync();
            return Ok(dProduct);
        }

    }
}
