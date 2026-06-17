using System.ComponentModel.DataAnnotations;

namespace StationeryWeek3.Mvc.ViewModels;

public class StationeryCreateViewModel
{
    [Required(ErrorMessage = "Mã không được để trống")]
    public string Code { get; set; } = "";

    [Required(ErrorMessage = "Tên không được để trống")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Loại không được để trống")]
    public string Category { get; set; } = "";

    [Required(ErrorMessage = "Thương hiệu không được để trống")]
    public string Brand { get; set; } = "";

    [Range(1, 999999999,
        ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }

    [Range(0, 999999,
        ErrorMessage = "Số lượng không hợp lệ")]
    public int Quantity { get; set; }

    [Range(0, 999999,
        ErrorMessage = "MinStock không hợp lệ")]
    public int MinStock { get; set; }
}