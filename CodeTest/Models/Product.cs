using CodeTest.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace CodeTest.Models;

public class Product : Common
{
    [Key]
    public Guid ProductID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}

public class AddProductRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}

public class UpdateProductRequest
{
    public Guid ProductID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}
