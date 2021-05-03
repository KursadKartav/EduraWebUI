using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        int SaveChanges(); //savechangesler otomatik count atar ve bu değeri 1 den başlatır. bunu yaparsam düzelir gibi bir şey

    }
}
