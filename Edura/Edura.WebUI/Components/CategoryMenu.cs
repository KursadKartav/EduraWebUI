using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class CategoryMenu:ViewComponent
    {
        private ICategoryRepository repo;
        public CategoryMenu(ICategoryRepository _repo)
        {
            repo = _repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repo.GetAllWithProductCount());

        }
    }
}
