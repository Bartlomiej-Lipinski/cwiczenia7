using System.Data;
using System.Data.SqlClient;
using cwiczenia7.DTO;
using cwiczenia7.Model;
using Dapper;
namespace cwiczenia7.Services;

public class DbService(IConfiguration configuration) : IDbService
{
    private async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(configuration.GetConnectionString("Default"));
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<GetProduct?> GetProduct(int id)
    {
        await using var connection = await GetConnection();
        var product = await connection.QueryAsync<GetProduct>("select * from Product where IdProduct = @id", new {id});
        var getProducts = product as GetProduct[] ?? product.ToArray();
        if (!getProducts.Any())
        {
            Results.NotFound("Product not found");
        }
        return getProducts.FirstOrDefault();
    }

    public async Task<GetWarehouse> GetWarehouse(int id)
    {
        await using var connection = await GetConnection();
        var order = await connection.QueryAsync<GetOrder>("select * from Warehouse where IdWarehouse = @id", new {id});
        
    }
}

    
