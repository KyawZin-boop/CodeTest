using CodeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers;

[Route("api/file")]
[ApiController]
public class FileController : Controller
{
    private readonly FileService _fileService;

    public FileController(FileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    [Route("upload-image")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var filePath = await _fileService.UploadImageAsync(file);
        return Json(filePath);
    }
}
