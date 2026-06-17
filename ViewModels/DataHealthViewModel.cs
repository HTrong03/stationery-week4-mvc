namespace StationeryWeek3.Mvc.ViewModels;

public class DataHealthViewModel
{
    public int TotalStationeries { get; set; }

    public int TotalCategories { get; set; }

    public int TotalBrands { get; set; }

    public bool DatabaseConnected { get; set; }

    public bool SeedDataAvailable { get; set; }

    public bool AsNoTrackingImplemented { get; set; }

    public bool TrackingImplemented { get; set; }

    public bool TransactionImplemented { get; set; }

    public int LowStockCount { get; set; }
}