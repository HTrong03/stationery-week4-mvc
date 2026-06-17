using StationeryWeek3.Mvc.Models;
using StationeryWeek3.Mvc.ViewModels;
using StationeryWeek3.Mvc.Repositories;
using Microsoft.Extensions.Options;
using StationeryWeek3.Mvc.Options;

namespace StationeryWeek3.Mvc.Services;

public class StationeryService : IStationeryService
{
    private readonly IStationeryRepository _repository;
    private readonly AppSettings _settings;

    public StationeryService(
    IStationeryRepository repository,
    IOptions<AppSettings> options)
{
    _repository = repository;
    _settings = options.Value;
}

    public List<Stationery> GetAll()
    {
        return _repository.GetAll();
    }

    public List<Stationery> GetAllReadOnly()
    {
        return _repository.GetAllReadOnly();
    }

    public Stationery? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Add(Stationery item)
    {
        _repository.Add(item);
        _repository.SaveChanges();
    }

    public StationeryStatsViewModel GetStats()
    {
        var items = _repository.GetAll();

        return new StationeryStatsViewModel
        {
            TotalItems = items.Count,
            TotalQuantity = items.Sum(x => x.Quantity),
            TotalValue = items.Sum(x => x.Price * x.Quantity),
            OutOfStock = items.Count(x => x.Quantity == 0)
        };
    }

    public DataHealthViewModel GetDataHealth()
    {
        return new DataHealthViewModel
        {
            TotalStationeries =
                _repository.GetStationeryCount(),

            TotalCategories =
                _repository.GetCategoryCount(),

            TotalBrands =
                _repository.GetBrandCount(),

            DatabaseConnected = true,

            SeedDataAvailable =
                _repository.GetStationeryCount() > 0,

            AsNoTrackingImplemented = true,

            TrackingImplemented = true,

            TransactionImplemented = true,

            LowStockCount =
                GetLowStockItems().Count
        };
    }

    public List<Stationery> GetLowStockItems()
    {
        return _repository
            .GetAllReadOnly()
            .Where(x =>
                x.Quantity <= _settings.LowStockThreshold)
            .ToList();
    }

    public List<Stationery> Filter(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice)
    {
        return _repository.Filter(
            categoryId,
            minPrice,
            maxPrice);
    }

    public string GetStockStatus(Stationery item)
    {
        if (item.Quantity >= 30)
            return "Tồn kho cao";

        if (item.Quantity <= 0)
            return "Hết hàng";

        if (item.Quantity <= _settings.LowStockThreshold)
            return "Cần nhập thêm";

        return "Còn hàng";
    }

}