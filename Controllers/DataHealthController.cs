using Microsoft.AspNetCore.Mvc;
using StationeryWeek3.Mvc.Services;

namespace StationeryWeek3.Mvc.Controllers;

public class DataHealthController : Controller
{
    private readonly IStationeryService _service;

    public DataHealthController(
        IStationeryService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var model =
            _service.GetDataHealth();

        return View(model);
    }
}