using CodeTest.Models;
using CodeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [Route("create-product")]
    public async Task<IActionResult> CreateProduct(AddProductRequest request)
    {
        await _productService.CreateProduct(request);
        return Ok();
    }

    [HttpGet]
    [Route("get-product/{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _productService.GetProductById(id);
        return Json(product);
    }

    [HttpPost]
    [Route("update-product")]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        await _productService.UpdateProduct(request);
        return Ok();
    }

    [HttpDelete]
    [Route("delete-product/{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _productService.DeleteProduct(id);
        return Ok();
    }
}
