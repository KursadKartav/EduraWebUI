using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 2; //her sayfada en fazla 2 ürün olsun 
        private IProductRepository repo;
        public ProductController(IProductRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category,int page = 1)
        {
            var products = repo.GetAll(); //bütün producklarımı alıyorum

            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(i => i.ProductCategories) //producttan categorye direk ulaşamıyorum önce procate sonra cate o yüzden theninclude
                    .ThenInclude(i => i.Category)
                    .Where(i=>i.ProductCategories.Any(x=>x.Category.CategoryName==category));
            }
            var count = products.Count();
            products=products.Skip((page-1)*PageSize).Take(PageSize); 

            return View(
                new ProductListModel() 
                {
                    Products=products, //bütün product bilgimi döndürüyorum.
                    PagingInfo=new PagingInfo()
                    {
                        CurrentPage=page,
                        ItemsPerPage=PageSize,
                        TotalItems=count
                    }
                });
        }

        public IActionResult Details(int id)
        {
            return View(repo.GetAll().Where(i=>i.ProductId==id)
                .Include(i=>i.Images)
                .Include(i=>i.Attributes)
                .Include(i=>i.ProductCategories)
                .ThenInclude(i=>i.Category)
                .Select(i=>new ProductDetailsModel() {
                    Product=i,
                    ProductImages=i.Images,
                    ProductAttributes=i.Attributes,
                    Categories=i.ProductCategories.Select(a=>a.Category).ToList()
                })
                .FirstOrDefault());
        }
    }
}