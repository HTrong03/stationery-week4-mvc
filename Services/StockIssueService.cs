using StationeryWeek3.Mvc.Models;
using StationeryWeek3.Mvc.Repositories;

namespace StationeryWeek3.Mvc.Services;

public class StockIssueService
    : IStockIssueService
{
    private readonly IStockIssueRepository _repository;

    public StockIssueService(
        IStockIssueRepository repository)
    {
        _repository = repository;
    }

    public void CreateIssue(
        int stationeryId,
        int quantity)
    {
        _repository.CreateIssue(
            stationeryId,
            quantity);
    }

    public List<StockIssue> GetAll()
    {
        return _repository.GetAll();
    }
}