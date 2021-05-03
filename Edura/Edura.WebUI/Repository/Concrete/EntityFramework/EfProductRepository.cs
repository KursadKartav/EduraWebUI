using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : /*IGenericRepository<Product>*/  EfGenericRepository<Product>,IProductRepository
    {
        public EfProductRepository(EduraContext context):base(context)
        {

        }
        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }

        public List<Product> GetLastTop5Product()
        {
            return EduraContext.Products.OrderByDescending(x => x.ProductId).Take(5).ToList();
        }

        //private EduraContext context; //edura contextin başlıklarını aldı örneğin ad soyad

        //public EfProductRepository(EduraContext ctx) //burası da onların içeriğini getiriyor mesela ahmet mehmet
        //{
        //    context = ctx;
        //}

        //public void Add(Product entity)
        //{
        //    context.Products.Add(entity);
        //}

        //public void Delete(Product entity)
        //{
        //    context.Products.Remove(entity);
        //}

        //public void Edit(Product entity)
        //{
        //    context.Entry<Product>(entity).State = EntityState.Modified;
        //}

        //public IQueryable<Product> Find(Expression<Func<Product, bool>> where)
        //{
        //    return context.Products.Where(where);
        //}

        //public Product Get(int id)
        //{
        //    return context.Products.FirstOrDefault(x => x.ProductId == id);
        //}

        //public IQueryable<Product> GetAll()
        //{
        //    return context.Products;
        //}

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        ////public IQueryable<Product> Products => context.Products; //Products sınıfının içerisindeki verileri alıp listeleyecek.
    }
}
