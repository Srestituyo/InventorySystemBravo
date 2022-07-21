using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductHistoryController : ControllerBase
{
    private readonly IProductHistoryService _theProductHistoryService;

    public ProductHistoryController(IProductHistoryService theProductHistoryService)
    {
        _theProductHistoryService = theProductHistoryService;
    }

    [HttpGet("{theProductHistoryId}")]
    public async Task<IActionResult> GetProductHistoryById(Guid theProductHistoryId)
    {
        var aProductHistory = await _theProductHistoryService.GetProductHistoryById(theProductHistoryId);
        return Ok(aProductHistory);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductHistory()
    {
        var aProductHistoryList = await _theProductHistoryService.GetAllProductHistory();
        return Ok(aProductHistoryList);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductHistory(ProductHistoryDTO theProductHistory)
    {
        var aResult = await _theProductHistoryService.AddProductHistory(theProductHistory);
        return Ok(aResult);
    }
 
}