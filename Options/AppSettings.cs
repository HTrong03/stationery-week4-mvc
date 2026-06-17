namespace StationeryWeek3.Mvc.Options;

public class AppSettings
{
    public string AppName { get; set; } = "";

    public string SupportEmail { get; set; } = "";

    public int LowStockThreshold { get; set; }
}