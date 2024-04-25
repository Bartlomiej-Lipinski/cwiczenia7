using cwiczenia7.DTO;

namespace cwiczenia7.Services;

public interface IDbService
{
    Task<GetProduct?> GetProduct(int id);
    Task<UpdateFullfiledAt> UpdateFullfiledAt(DateTime date);
    Task<GetOrder> GetOrder(GetOrder request);
    Task<ProductWerehouse> GetProductWerehouse(int id);
}