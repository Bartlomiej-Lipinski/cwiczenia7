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

    public async Task<Product?> GetProduct(int id)
    {
        await using var connection = await GetConnection();
        var product = await connection.QueryAsync<Product>("select * from Product where IdProduct = @id", new {id});
        var getProducts = product as Product[] ?? product.ToArray();
        if (!getProducts.Any())
        {
            Results.NotFound("Product not found");
        }
        return getProducts.FirstOrDefault();
    }

    public async Task<Warehouse?> GetWerehouse(int id)
    {
        await using var connection = await GetConnection();
        var order = await connection.QueryAsync<Warehouse>("select * from Warehouse where IdWarehouse = @id", new {id});
        var orders = order as Warehouse[] ?? order.ToArray();
        if (!orders.Any())
        {
            Results.NotFound("Warehouse not found");
        }
        return orders.FirstOrDefault();
    }

    public async Task<ProductWarehouse?> GetProductWarehouse(int id)
    {
        await using var connection = await GetConnection();
        var productWarehouse = await connection.QueryAsync<ProductWarehouse>("select * from Product_Warehouse where IdOrder = @id", new {id});
        var productWarehouses = productWarehouse as ProductWarehouse[] ?? productWarehouse.ToArray();
        if (!productWarehouses.Any())
        {
            Results.NotFound("Product Warehouse not found");
        }
        return productWarehouses.FirstOrDefault();
    }

    public async Task<Order?> GetOrder(int id)
    {
        await using var connection = await GetConnection();
        IEnumerable<Order?> order = await connection.QueryAsync<Order>("select * from Order where IdOrder = @id", new {id});
        return order.FirstOrDefault();
    }

    public async Task<ProductWarehouse?> GetProductWerehouse(int id)
    {
        await using var connection = await GetConnection();
        var productWarehouse = await connection.QueryAsync<ProductWarehouse>("select * from Product_Warehouse where IdOrder = @id", new {id});
        var productWarehouses = productWarehouse as ProductWarehouse[] ?? productWarehouse.ToArray();
        if (!productWarehouses.Any())
        {
            Results.NotFound("Product Warehouse not found");
        }
        return productWarehouses.FirstOrDefault();
    }


    public async Task<int> Transaction(ProductWarehouse productWarehouse, getOrder getOrder)
    {
        productWarehouse.price *= productWarehouse.amount;
        await using var connection = await GetConnection();
        var transaction = await connection.BeginTransactionAsync();
        await UpdateOrderFulfilledAt(DateTime.Now, productWarehouse.idOrder);
        var updateFullfiledAt = await connection.ExecuteAsync("update Product_Warehouse set CreatedAt = @date", new {date = DateTime.Now}, transaction);
        var insertIntoProductWarehouse = await connection.ExecuteAsync("insert into Product_Warehouse (IdWarehouse,IdProduct, IdOrder, Amount, Price, CreatedAt) values (@warehouse,@product,@order, @amount, @price, @date)", new
        {
            date = DateTime.Now,
            price=productWarehouse.price,
            amount = productWarehouse.amount,
            order = productWarehouse.idOrder,
            product = productWarehouse.idProduct,
            warehouse = productWarehouse.idWarehouse
        }, transaction);
        return insertIntoProductWarehouse;
    }

    public async Task UpdateOrderFulfilledAt(DateTime date, int idOrder)
    {
        await using var connection = await GetConnection();
        var updateFullfiledAt = await connection.ExecuteAsync("update Order set FulfilledAt = @date where IdOrder = @id", new {date=DateTime.Now, id = idOrder});
    }
}

    
