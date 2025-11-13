using System.Diagnostics;
using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View("Index", products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            try
            {
                var product = await _productService.GetProductById(id);

                if (product == null)
                {
                    TempData["Error"] = "Product not found.";
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
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
