using Edura.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EduraContext : DbContext
    {
        public EduraContext(DbContextOptions<EduraContext>options):base (options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductAttribute> Attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //override onmodel creatingi seç otomatik gelir.
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk => new { pk.ProductId, pk.CategoryId });  //pk primarykey
        }
    }
   
}
