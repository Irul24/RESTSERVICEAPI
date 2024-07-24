using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTSERVICEAPI.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTSERVICEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<produk>>> GetProduct()
        {
            if (_productContext.produk is null)
            {
                return NotFound();
            }
            return await _productContext.produk.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<produk>> GetProduct(int id)
        {
            if (_productContext.produk is null)
            {
                return NotFound();
            }
            var prod = await _productContext.produk.FindAsync(id);
            if (prod is null)
            {
                return NotFound();
            }
            return prod;
        }

        [HttpPost]
        public async Task<ActionResult<produk>> AddProduct(produk produk)
        {
            _productContext.produk.Add(produk);
            await _productContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = produk.id }, produk);
        }

        [HttpPut]
        public async Task<ActionResult<produk>> EditProduct(int id, produk produk)
        {
            if (id != produk.id)
            {
                return BadRequest();
            }
            _productContext.Entry(produk).State = EntityState.Modified;
            try
            {
                await _productContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!productExisting(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<produk>> DeleteProduct(int id)
        {
            if (_productContext.produk is null)
            {
                return NotFound();
            }
            var produk = await _productContext.produk.FindAsync(id);
            if (produk is null)
            {
                return NotFound();
            }
            _productContext.produk.Remove(produk);
            await _productContext.SaveChangesAsync();
            return NoContent();
        }


        private bool productExisting(int id)
        {
            return (_productContext.produk?.Any(produk => produk.id == id)).GetValueOrDefault();
        }





    }
}
