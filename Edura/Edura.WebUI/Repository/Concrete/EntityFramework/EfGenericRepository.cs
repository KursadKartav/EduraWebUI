using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfGenericRepository<Q> : IGenericRepository<Q> where Q : class
    {
        protected readonly DbContext context;
        public EfGenericRepository(DbContext ctx) //category ve producttan ikisinden hangisini yazarsam olmuyor o yüzden ikisini de barındıran DbContexti yazıyorum o otomatik karar veriyor.
        {
            context = ctx;
        }
        public void Add(Q entity)
        {
            context.Set<Q>().Add(entity); // Set<A> içindeki nesneye göre kur demek.
            //context.Category.Add(entity); o yüzden bu tarzda yazmadım.Hata verirdi.
        }

        public void Delete(Q entity)
        {
            context.Set<Q>().Remove(entity);
        }

        public void Edit(Q entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Q> Find(Expression<Func<Q, bool>> where)
        {
            return context.Set<Q>().Where(where);
        }

        public Q Get(int id)
        {
            return context.Set<Q>().Find(id);
        }

        public IQueryable<Q> GetAll()
        {
            return context.Set<Q>();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
