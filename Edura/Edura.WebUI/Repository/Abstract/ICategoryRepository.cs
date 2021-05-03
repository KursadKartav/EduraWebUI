using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetByName(string name);
        //yorum satırına almamın sebebi IGenericReponun içinde oluşturdum gerek kalmadı burda yazmaya.
        //Category Get(int id);
        //IQueryable<Category> GetAll();
        //IQueryable<Category> Find(Expression<Func<Category, bool>> where);
        //void Add(Category entity);
        //void Delete(Category entity);
        //void Edit(Category entity);
        //void Save();
        IEnumerable<CategoryModel> GetAllWithProductCount();
    }
}
