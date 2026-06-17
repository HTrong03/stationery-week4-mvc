using StationeryWeek3.Mvc.Models;
using StationeryWeek3.Mvc.ViewModels;

namespace StationeryWeek3.Mvc.Services;

public interface IStationeryService
{
    List<Stationery> GetAll();

    List<Stationery> GetAllReadOnly();

    Stationery? GetById(int id);

    void Add(Stationery item);

    StationeryStatsViewModel GetStats();

    DataHealthViewModel GetDataHealth();

    List<Stationery> GetLowStockItems();

    List<Stationery> Filter(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice);
}