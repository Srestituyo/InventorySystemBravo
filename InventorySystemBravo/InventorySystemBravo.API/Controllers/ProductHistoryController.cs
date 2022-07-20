using InventorySystemBravo.Domain.Entities;
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
    public async Task<ProductHistory> GetProductHistoryById(Guid theProductHistoryId)
    {
        var aProductHistory = await _theProductHistoryService.GetProductHistoryById(theProductHistoryId);
        return aProductHistory;
    }

    [HttpGet]
    public async Task<List<ProductHistory>> GetAllProductHistory()
    {
        var aProductHistoryList = await _theProductHistoryService.GetAllProductHistory();
        return aProductHistoryList;
    }

    [HttpPost]
    public async Task AddProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryService.AddProductHistory(theProductHistory);
    }

    [HttpPut]
    public async Task UpdateProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryService.UpdateProductHistory(theProductHistory);
    }

    [HttpDelete]
    public async Task RemoveProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryService.RemoveProductHistory(theProductHistory);
    }
}