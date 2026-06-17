namespace StationeryWeek3.Mvc.Models;

public class Stationery
{
    public int Id { get; set; }

    public string Code { get; set; } = "";

    public string Name { get; set; } = "";

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int MinStock { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public int BrandId { get; set; }

    public Brand? Brand { get; set; }
    public string SupplierCode { get; set; } = "";
}