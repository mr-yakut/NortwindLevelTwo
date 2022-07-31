using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        public ICartService _cartService;
        public ICartSessionHelper _cartSessionHelper;
        public IProductService _productService;

        public CartController(ICartService cartService, 
            ICartSessionHelper cartSessionHelper, 
            IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }
        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key: "cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart(key: "cart", cart);

            TempData.Add("message",product.ProductName + " ürünü sepete eklendi!");

            return RedirectToAction("Index", controllerName: "Product");
        }
        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart(key: "cart")
            };
            return View(model);
        }

        public IActionResult RemoveFromCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key: "cart");

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart(key: "cart", cart);

            TempData.Add("message", product.ProductName + " ürünü sepettten kaldırıldı!");

            return RedirectToAction("Index", controllerName: "Cart");
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View();
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message","Siparişiniz başarıyla tamamlandı!");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", controllerName: "Cart");
        }
    }
}
