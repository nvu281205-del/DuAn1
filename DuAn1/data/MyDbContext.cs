using Microsoft.EntityFrameworkCore;
using DuAn1.model;
namespace DuAn1.data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) : base(options) { }
      public   DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, NameProduct = "Galaxy Fold7", Description = "Điện thoại màn hình gập" },
        new Product { Id = 2, NameProduct = "iPhone 17", Description = "Điện thoại Apple mới nhất" },
        new Product { Id = 3, NameProduct = "Xiaomi 15", Description = "Điện thoại giá rẻ cấu hình cao" },
        new Product { Id = 4, NameProduct = "RedMagic 10 Pro", Description = "Điện thoại gaming mạnh mẽ" },
        new Product { Id = 5, NameProduct = "Oppo Find X7", Description = "Điện thoại camera ẩn dưới màn hình" },
        new Product { Id = 6, NameProduct = "Vivo Nex 6", Description = "Điện thoại màn hình tràn viền" },
        new Product { Id = 7, NameProduct = "Huawei Mate 60", Description = "Điện thoại flagship của Huawei" },
        new Product { Id = 8, NameProduct = "Realme GT Neo 6", Description = "Điện thoại hiệu năng cao giá rẻ" }
            );
        }
    }

    }
