using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class ProductHistoryService : IProductHistoryService
{
    private readonly IProductHistoryRepository _theProductHistoryRepository;
    private readonly IMapper _theMapper;

    public ProductHistoryService(IProductHistoryRepository theProductHistoryRepository, IMapper theMapper)
    {
        _theProductHistoryRepository = theProductHistoryRepository;
        _theMapper = theMapper; 
    }

    public async Task<Response<Guid>> AddProductHistory(ProductHistoryDTO theProductHistory)
    {
        var aNewProductHistory = new ProductHistory()
        {
            Action = theProductHistory.Action,
            ProductId = theProductHistory.ProductId
        };
        await _theProductHistoryRepository.AddProductHistory(aNewProductHistory);
        return new Response<Guid>(aNewProductHistory.Id);
    }

    public async Task<Response<ProductHistoryModel>> GetProductHistoryById(Guid theProductHistoryId)
    {
        var aProductHistory = await _theProductHistoryRepository.GetProductHistoryById(theProductHistoryId);
        var aResponse = _theMapper.Map<ProductHistoryModel>(aProductHistory);
        return new Response<ProductHistoryModel>(aResponse);
    }

    public async Task<Response<ProductHistoryViewModel>> GetAllProductHistory()
    {
        var aProductHistoryList = await _theProductHistoryRepository.GetAllProductHistory();

        var aProductHistoryViewModel = new ProductHistoryViewModel();

        foreach (var aProductHistoryItem in aProductHistoryList)
        {
            var aMappedProductHistory = _theMapper.Map<ProductHistoryModel>(aProductHistoryItem);
            aProductHistoryViewModel.ProductHistory.Add(aMappedProductHistory);
        }

        return new Response<ProductHistoryViewModel>(aProductHistoryViewModel);
    } 
}