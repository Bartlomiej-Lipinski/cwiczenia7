namespace cwiczenia7.DTO;

public record getOrder(int ProductId, int WareHouseId, int Amount, DateTime CreatedAt);
public record GetProduct(int Id);
public record GetWarehouse(int Id);
public record ProductWerehouse(int IdProductWarehouse,int IdWarehouse,int IdProduct,int IdOrder,int Amount,float Price,DateTime CreatedAt);
public record UpdateFullfiledAt(DateTime Date);

