using cwiczenia7.DTO;
using cwiczenia7.Model;

namespace cwiczenia7.Services;

public interface IDbService
{
    Task<Product?> GetProduct(int id);
    Task<Warehouse?> GetWerehouse(int id);
    Task<ProductWarehouse?> GetProductWarehouse(int id);
    Task<Order?> GetOrder(int id);
    Task<ProductWarehouse?> GetProductWerehouse(int id);
    Task<int> Transaction(ProductWarehouse productWarehouse, getOrder getOrder);
    Task UpdateOrderFulfilledAt(DateTime date, int idOrder);
}