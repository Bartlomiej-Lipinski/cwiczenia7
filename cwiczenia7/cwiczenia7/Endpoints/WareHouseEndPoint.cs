using cwiczenia7.DTO;
using cwiczenia7.Services;

namespace cwiczenia7.Endpoints;

public static class WareHouseEndPoint
{
    public static void RegisterWarehouseEndpoints(this WebApplication app)
    {
        app.MapPost("/warehouse", (getOrder order,IDbService dbService) =>
        {
            var warehouse =order.WareHouseId;
            var wh =dbService.GetWerehouse(warehouse);
            if (wh is null)
            {
                Results.BadRequest("Warehouse not found");
            }
            var product = order.ProductId;
            var p = dbService.GetProduct(product);
            if (p is null)
            {
                Results.BadRequest("Product not found");
            }

            var o =dbService.GetOrder(order.ProductId);
            if (o is null)
            {
                Results.BadRequest("Order Already exists");
            }
            
            return Results.Ok($"Warehouse {warehouse} created");
        });
    }
}