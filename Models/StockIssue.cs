namespace StationeryWeek3.Mvc.Models;

public class StockIssue
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.Now;

    public ICollection<StockIssueItem> Items
        { get; set; } = new List<StockIssueItem>();
}