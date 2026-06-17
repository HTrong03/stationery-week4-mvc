using StationeryWeek3.Mvc.Models;

namespace StationeryWeek3.Mvc.Services;

public interface IStockIssueService
{
    void CreateIssue(
        int stationeryId,
        int quantity);

    List<StockIssue> GetAll();
}