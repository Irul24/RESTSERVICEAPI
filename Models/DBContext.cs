using Microsoft.EntityFrameworkCore;
using RESTSERVICEAPI.Models;

namespace RESTSERVICEAPI.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions
        <ProductContext> options)
            : base(options)
        {
        }
        public DbSet<produk> produk { get; set; } = null;

    }
}