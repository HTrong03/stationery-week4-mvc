using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Repositories;

public interface IStationeryRepository
{
    int GetStationeryCount();

    int GetCategoryCount();

    int GetBrandCount();

    List<Stationery> GetAll();

    List<Stationery> GetAllReadOnly();

    Stationery? GetById(int id);

    void Add(Stationery stationery);

    void SaveChanges();

    List<Stationery> Filter(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice);
}