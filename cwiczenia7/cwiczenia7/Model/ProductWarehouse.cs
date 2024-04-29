namespace cwiczenia7.Model;

public class ProductWarehouse
{
    public int idProductWarehouse { get; set; }
    public int idWarehouse { get; set; }
    public int idProduct { get; set; }
    public int idOrder { get; set; }
    public int amount { get; set; }
    public float price { get; set; }
    public DateTime createdAt { get; set; }
}