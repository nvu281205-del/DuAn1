using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DuAn1.data
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            // 1. Thử đọc biến môi trường
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            // 2. Nếu không có → đọc appsettings.json
            if (string.IsNullOrEmpty(connectionString))
            {
                var basePath = Directory.GetCurrentDirectory();  // bin/Debug/net10.0
                var projectPath = Path.Combine(basePath, @"..\..\.."); // trở về folder gốc

                var config = new ConfigurationBuilder()
                    .SetBasePath(projectPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                connectionString = config.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string not set. Please set environment variable or appsettings.json");

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
