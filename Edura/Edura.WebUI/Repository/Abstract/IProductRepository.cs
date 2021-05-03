using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> GetLastTop5Product();
        //Aşağıdaki kodlara gerek kalmadı IGenericRepoyu miras aldığım için.
        //Product Get(int id);
        //IQueryable<Product> GetAll();
        //IQueryable<Product> Find(Expression<Func<Product, bool>> where);
        //void Add(Product entity);
        //void Delete(Product entity);
        //void Edit(Product entity);
        //void Save();
    }
}
