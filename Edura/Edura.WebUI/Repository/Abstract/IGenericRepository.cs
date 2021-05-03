using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IGenericRepository<Q> where Q:class
    {
        Q Get(int id);
        IQueryable<Q> GetAll();
        IQueryable<Q> Find(Expression<Func<Q, bool>> where);
        void Add(Q entity);
        void Delete(Q entity);
        void Edit(Q entity);
        void Save();
    }
}
