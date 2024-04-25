namespace cwiczenia7.Endpoints;

public static class WareHouseEndPoint
{
    public static void RegisterWarehouseEndpoints(this WebApplication app)
    {
        app.MapGet("/warehouse/{id}", (int id) =>
        {
            
        });

        app.MapPost("/warehouse", (WarehouseDTO warehouse) =>
        {
            return Results.Ok($"Warehouse {warehouse.Id} created");
        });

        app.MapPut("/warehouse/{id}", (int id, WarehouseDTO warehouse) =>
        {
            return Results.Ok($"Warehouse {id} updated");
        });

        app.MapDelete("/warehouse/{id}", (int id) =>
        {
            return Results.Ok($"Warehouse {id} deleted");
        });
    }
}