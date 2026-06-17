using Microsoft.AspNetCore.Mvc;
using StationeryWeek3.Mvc.Services;
using StationeryWeek3.Mvc.ViewModels;

namespace StationeryWeek3.Mvc.Controllers;

public class StockIssuesController
    : Controller
{
    private readonly IStockIssueService _service;

    public StockIssuesController(
        IStockIssueService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(
        CreateIssueViewModel model)
    {
        try
        {
            _service.CreateIssue(
                model.StationeryId,
                model.Quantity);

            TempData["Success"] =
                "Xuất kho thành công.";

            return RedirectToAction(
                nameof(History));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(
                "",
                ex.Message);

            return View(model);
        }
    }

    public IActionResult History()
    {
        return View(
            _service.GetAll());
    }
}