using Microsoft.EntityFrameworkCore;
using StationeryWeek3.Mvc.Data;
using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Repositories;

public class StationeryRepository : IStationeryRepository
{
    private readonly AppDbContext _db;

    public StationeryRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<Stationery> GetAll()
    {
        return _db.Stationeries
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .ToList();
    }

    public List<Stationery> GetAllReadOnly()
    {
        return _db.Stationeries
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .AsNoTracking()
            .ToList();
    }

    public Stationery? GetById(int id)
    {
        return _db.Stationeries
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Add(Stationery stationery)
    {
        _db.Stationeries.Add(stationery);
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
    }

    public int GetStationeryCount()
    {
        return _db.Stationeries.Count();
    }

    public int GetCategoryCount()
    {
        return _db.Categories.Count();
    }

    public int GetBrandCount()
    {
        return _db.Brands.Count();
    }

    public List<Stationery> Filter(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice)
    {
        var query = _db.Stationeries
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .AsNoTracking()
            .AsQueryable();

        if (categoryId.HasValue)
        {
            query = query.Where(x =>
                x.CategoryId == categoryId.Value);
        }

        if (minPrice.HasValue)
        {
            query = query.Where(x =>
                x.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(x =>
                x.Price <= maxPrice.Value);
        }

        return query.ToList();
    }
}