using Microsoft.EntityFrameworkCore;
using StationeryWeek3.Mvc.Data;
using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Repositories;

public class StockIssueRepository
    : IStockIssueRepository
{
    private readonly AppDbContext _db;

    public StockIssueRepository(
        AppDbContext db)
    {
        _db = db;
    }

    public void CreateIssue(
        int stationeryId,
        int quantity)
    {
        using var transaction =
            _db.Database.BeginTransaction();

        try
        {
            var stationery =
                _db.Stationeries
                    .FirstOrDefault(x =>
                        x.Id == stationeryId);

            if (stationery == null)
            {
                throw new Exception(
                    "Stationery not found.");
            }

            if (stationery.Quantity < quantity)
            {
                throw new Exception(
                    "Not enough stock.");
            }

            var issue = new StockIssue
            {
                CreatedAt = DateTime.Now
            };

            _db.StockIssues.Add(issue);

            _db.SaveChanges();

            var item =
                new StockIssueItem
                {
                    StockIssueId = issue.Id,
                    StationeryId = stationery.Id,
                    Quantity = quantity
                };

            _db.StockIssueItems.Add(item);

            stationery.Quantity -= quantity;

            stationery.LastUpdatedAt =
                DateTime.Now;

            _db.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public List<StockIssue> GetAll()
    {
        return _db.StockIssues
            .Include(x => x.Items)
            .ThenInclude(x => x.Stationery)
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .ToList();
    }
}