using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repo;

        public CartController(IProductRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult AddToCart(int ProductId,int quantity=1)
        {
            var product = repo.Get(ProductId); //id parametresini alıp tek satırlık bir yer döndürücek
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);
            }
            return RedirectToAction("Index"); //indexe geri döndür.
        }

        public IActionResult RemoveFromCart(int ProductId)
        {
            var product = repo.Get(ProductId);
            if (product!=null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
    }
}