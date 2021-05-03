using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class FeaturedProducts:ViewComponent
    {
        private IProductRepository repo;
        public FeaturedProducts(IProductRepository _repo)
        {
            repo = _repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repo.GetAll().Where(i => i.IsApproved && i.IsFeatured).ToList());

        }
    }
}
