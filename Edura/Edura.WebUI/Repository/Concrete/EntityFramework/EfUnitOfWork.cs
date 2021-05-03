using Edura.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitofWork
    {
        private readonly EduraContext dbContext;
        public EfUnitOfWork(EduraContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("dbContext can not be null"); //?? if else gibi çalışıyor.
        }
        private IProductRepository _products;
        private ICategoryRepository _categories; //bunlar fieldlarım

        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EfProductRepository(dbContext));
            }
        }
        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(dbContext));
            }
        }
        //public IProductRepository Product => throw new NotImplementedException();

        //public ICategoryRepository Category => throw new NotImplementedException(); //bunlar eskidendi yukarda yenilerini oluşturmuş olduk.Bunu her yerde dbContext kullanmak yerine bu classı açıp IUnit interfacesinden miras alıp burdan her yere dağıttık.

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
