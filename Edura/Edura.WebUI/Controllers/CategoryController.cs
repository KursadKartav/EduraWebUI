using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repo;
        public CategoryController(ICategoryRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            var cat = repo.GetByName("Electronics");
            return View(cat);
        }
    }
}