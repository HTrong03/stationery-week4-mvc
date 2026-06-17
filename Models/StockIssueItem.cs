namespace StationeryWeek3.Mvc.Models;

public class StockIssueItem
{
    public int Id { get; set; }

    public int StockIssueId { get; set; }

    public StockIssue? StockIssue { get; set; }

    public int StationeryId { get; set; }

    public Stationery? Stationery { get; set; }

    public int Quantity { get; set; }
}