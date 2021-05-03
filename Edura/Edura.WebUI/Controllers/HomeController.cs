using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Repository.Concrete.EntityFramework;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repo;//artık newleyerek değil alana özel sınıflar oluşturuyorum.
        //repo bir field oluşturup içine property yolluyorum, bağlılık oluşturdum.
        private IUnitofWork uow;
        public HomeController(IUnitofWork _uow,IProductRepository _repo)
        {
            repo = _repo;
            uow = _uow;
        }
        public IActionResult Index()
        {
            //return View(repo.Product); eskiden böyleydi biz efproductrepository de oluşturduğumuz metodlardan sonra böyle oldu
            //return View(repo.GetAll()); /Unitofworkten sonra eskisine gerek kalmadı bu oldu.
            //return View(repo.GetAll());
            return View(uow.Products.GetAll());
        }
        public IActionResult Create()
        {
            var prd = new Product() { ProductName = "Yeni Ürün", Price = 100 };
            uow.Products.Add(prd);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
