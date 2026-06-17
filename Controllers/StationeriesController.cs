using Microsoft.AspNetCore.Mvc;
using StationeryWeek3.Mvc.Models;
using StationeryWeek3.Mvc.Services;
using StationeryWeek3.Mvc.ViewModels;

namespace StationeryWeek3.Mvc.Controllers;

public class StationeriesController : Controller
{
    private readonly IStationeryService _service;

    public StationeriesController(
        IStationeryService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var items = _service.GetAll()
            .Select(x => new StationeryListItemViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Category = x.Category?.Name ?? "",
                Brand = x.Brand?.Name ?? "",
                Price = x.Price,
                Quantity = x.Quantity,
                MinStock = x.MinStock,

                StockStatus = _service.GetStockStatus(x)
            })
            .ToList();

        return View(items); 
    }

    public IActionResult Detail(int id)
    {
        var item = _service.GetById(id);

        if (item == null)
            return NotFound($"Không tìm thấy văn phòng phẩm có id = {id}");

        var viewModel = new StationeryDetailViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category?.Name ?? "",
            Brand = item.Brand?.Name ?? "",
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock,
            LastUpdatedAt = item.LastUpdatedAt
        };

        return View(viewModel);
    }

    public IActionResult Stats()
    {
        return View(_service.GetStats());
    }

    public IActionResult Welcome()
    {
        return Content("Welcome to Mini Stationery Store Catalog MVC");
    }

    public IActionResult StationeryJson()
    {
        return Json(_service.GetAll());
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("404 Demo");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StationeryCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var item = new Stationery
        {
            Code = model.Code,
            Name = model.Name,

            CategoryId = 1,
            BrandId = 1,

            Price = model.Price,
            Quantity = model.Quantity,
            MinStock = model.MinStock,
            LastUpdatedAt = DateTime.Now
        };

        _service.Add(item);

        TempData["Success"] =
            "Đã thêm văn phòng phẩm thành công.";

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Search(
        string? keyword,
        string? category,
        decimal? minPrice)
    {
        var items = _service.GetAll();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            items = items.Where(x =>
                x.Name.Contains(
                    keyword,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            items = items.Where(x =>
                x.Category != null &&
                x.Category.Name.Contains(
                    category,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (minPrice.HasValue)
        {
            items = items.Where(x =>
                x.Price >= minPrice.Value)
                .ToList();
        }

        var result = items
            .Select(x => new StationeryListItemViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Category = x.Category?.Name ?? "",
                Brand = x.Brand?.Name ?? "",
                Price = x.Price,
                Quantity = x.Quantity,
                MinStock = x.MinStock
            })
            .ToList();

        return View(result);
    }

    private static StationeryListItemViewModel ToListItemViewModel(
    Stationery item)
    {
        return new StationeryListItemViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category?.Name ?? "",
            Brand = item.Brand?.Name ?? "",
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock,

        };
    }

    private static StationeryDetailViewModel ToDetailViewModel(
        Stationery item)
    {
        return new StationeryDetailViewModel
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Category = item.Category?.Name ?? "",
            Brand = item.Brand?.Name ?? "",
            Price = item.Price,
            Quantity = item.Quantity,
            MinStock = item.MinStock,
            LastUpdatedAt = item.LastUpdatedAt
        };
    }

    public IActionResult DataHealth()
    {
        var vm = _service.GetDataHealth();

        return View(vm);
    }

    public IActionResult Filter(
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice)
    {
        var result =
            _service.Filter(
                categoryId,
                minPrice,
                maxPrice);

        return View(result);
    }
    public IActionResult CreateProduct()
    {
        return View();
    }
}