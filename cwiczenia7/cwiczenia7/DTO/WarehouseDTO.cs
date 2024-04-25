namespace cwiczenia7.DTO;

public record GetOrder(int ProductId, int WareHouseId, int Amount, DateTime CreatedAt);
public record GetProduct(int Id);
public abstract record GetWarehouse(int Id);
public record ProductWerehouse(int IdProductWarehouse,int IdWarehouse,int IdProduct,int IdOrder,int Amount,float Price,DateTime CreatedAt);
public record UpdateFullfiledAt(DateTime Date);

