using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Repositories;

public interface IStockIssueRepository
{
    void CreateIssue(
        int stationeryId,
        int quantity);

    List<StockIssue> GetAll();
}