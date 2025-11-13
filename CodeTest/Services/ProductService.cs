using CodeTest.AppSettings;
using CodeTest.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CodeTest.Services;

public class ProductService
{
    private readonly string _conn = AppDbContext._connBuilder.ConnectionString;
    private readonly IDbConnection _dbConnection;

    public ProductService()
    {
        _dbConnection = new SqlConnection(_conn);
    }

    public async Task<IEnumerable<Product>?> GetAllProducts()
    {
        try
        {
            var products = await _dbConnection.QueryAsync<Product>("Select * from Product Order by CreatedAt DESC");

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while retrieving products.", ex);    
        }
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        try
        {
            string query = "SELECT * FROM Product WHERE ProductID = @ProductID";

            var product = await _dbConnection.QueryFirstOrDefaultAsync<Product>(
                query,
                new { ProductID = id }
            );

            return product;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while retrieving product.", ex);
        }
    }

    public async Task<bool> CreateProduct(AddProductRequest request)
    {
        try
        {
            string query = @"INSERT INTO [dbo].[Product]
                           ([Name]
                           ,[Description]
                           ,[Price]
                           ,[Quantity]
                           ,[ImageUrl]
                           ,[CreatedAt]
                           ,[UpdatedAt])
                     VALUES
                           (@Name
                           ,@Description
                           ,@Price
                           ,@Quantity
                           ,@ImageUrl
                           ,@CreatedAt
                           ,@UpdatedAt)";

            var parameters = new
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                ImageUrl = request.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _dbConnection.ExecuteAsync(query, parameters);

            return result > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while creating product.", ex);
        }
    }

    public async Task<bool> UpdateProduct(UpdateProductRequest request)
    {
        try
        {
            string query = @"UPDATE [dbo].[Product]
                        SET [Name] = @Name
                           ,[Description] = @Description
                           ,[Price] = @Price
                           ,[Quantity] = @Quantity
                           ,[ImageUrl] = @ImageUrl
                           ,[UpdatedAt] = @UpdatedAt
                        WHERE [ProductID] = @ProductID";

            var parameters = new
            {
                ProductID = request.ProductID,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                ImageUrl = request.ImageUrl,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _dbConnection.ExecuteAsync(query, parameters);

            return result > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating product.", ex);
        }
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        try
        {
            string selectQuery = "SELECT * FROM Product WHERE ProductID = @ProductID";

            var product = await _dbConnection.QueryFirstOrDefaultAsync<Product>(
                selectQuery,
                new { ProductID = id }
            );

            if (product == null) throw new Exception("Product not found.");

            var deleteQuery = $"Delete from Product Where ProductID = @ProductID";
            var result = await _dbConnection.ExecuteAsync(deleteQuery, new { ProductID = id });

            return result > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occured while deleting product.", ex);
        }
    }
}
