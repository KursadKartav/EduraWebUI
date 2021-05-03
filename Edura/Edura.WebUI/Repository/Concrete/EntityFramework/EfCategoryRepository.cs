using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository /*IGenericRepository<Category>*/
    {

        public EfCategoryRepository(EduraContext context):base(context)
        {

        }
        public EduraContext EduraContext
        {
            get { return context as EduraContext; }
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(i => new CategoryModel()
            {
                CategoryId=i.CategoryId,
                CategoryName=i.CategoryName,
                Count=i.ProductCategories.Count()

            });

        }

        public Category GetByName(string name)
        {
            return EduraContext.Categories.Where(x => x.CategoryName == name).FirstOrDefault();
        }
        //Yukarıda yazdığım kodlar //category ve producttan ikisinden hangisini yazarsam olmuyor o yüzden ikisini de barındıran DbContexti yazıyorum o otomatik karar veriyor. Bu da orayla bağlantımı kuruyor.

        //    private EduraContext context;
        //    public EfCategoryRepository(EduraContext ctx)
        //    {
        //        context = ctx;
        //    }
        //    public void Add(Category entity)
        //    {
        //        context.Categories.Add(entity);
        //    }

        //    public void Delete(Category entity)
        //    {
        //        context.Categories.Remove(entity);
        //    }

        //    public void Edit(Category entity)
        //    {
        //        context.Entry<Category>(entity).State = EntityState.Modified;
        //    }

        //    public IQueryable<Category> Find(Expression<Func<Category, bool>> where)
        //    {
        //        return context.Categories.Where(where);
        //    }

        //    public Category Get(int id)
        //    {
        //        return context.Categories.FirstOrDefault(x => x.CategoryId == id);
        //    }

        //    public IQueryable<Category> GetAll()
        //    {
        //        return context.Categories;
        //    }

        //    public void Save()
        //    {
        //        context.SaveChanges();
        //    }
    }
}
