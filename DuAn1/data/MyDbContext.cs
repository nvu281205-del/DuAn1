using Microsoft.EntityFrameworkCore;
using DuAn1.model;
namespace DuAn1.data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options) { }
      public   DbSet<Product> Products { get; set; }
    }
}
