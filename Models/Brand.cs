namespace StationeryWeek3.Mvc.Models;

public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public ICollection<Stationery> Stationeries
        { get; set; } = new List<Stationery>();
}