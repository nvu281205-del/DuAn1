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
           
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

          
            if (string.IsNullOrEmpty(connectionString))
            {
                var basePath = Directory.GetCurrentDirectory();  
                var projectPath = Path.Combine(basePath, @"..\..\..");

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
