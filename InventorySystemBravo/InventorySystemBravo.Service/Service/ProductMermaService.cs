using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class ProductMermaService : IProductMermaService
{
    private readonly IProductMermaRepository _theProductMermaRepository;
    private readonly IMapper _theMapper;

    public ProductMermaService(IProductMermaRepository theProductMermaRepository, IMapper theMapper)
    {
        _theProductMermaRepository = theProductMermaRepository;
        _theMapper = theMapper;
    }

    public async Task<Response<Guid>> AddProductMerma(ProductMermaDTO theProductMerma)
    {
        var aProductMerma = new ProductMerma()
        {
            Reason = theProductMerma.Reason,
            ProductId = theProductMerma.ProductId,
            CreatedBy = theProductMerma.CreatedBy
        };
        
        await _theProductMermaRepository.AddProductMerma(aProductMerma);
        return new Response<Guid>(aProductMerma.Id);
    }

    public async Task<Response<ProductMermaModel>> GetProductMermaById(Guid theProductMermaId)
    {
        var aProductMerma = await _theProductMermaRepository.GetProductMermaById(theProductMermaId);
        var aResponse = _theMapper.Map<ProductMermaModel>(aProductMerma);

        return new Response<ProductMermaModel>(aResponse);
    }

    public async Task<Response<ProductMermaViewModel>> GetAllProductMerma()
    {
        var aProductMermaList = await _theProductMermaRepository.GetAllProductMerma();

        var aProductMermaViewModel = new ProductMermaViewModel();

        foreach (var aProductMermaItem in aProductMermaList)
        {
            var aMappedProductMerma = _theMapper.Map<ProductMermaModel>(aProductMermaItem);
            aProductMermaViewModel.ProductMerma.Add(aMappedProductMerma); 
        }

        return new Response<ProductMermaViewModel>(aProductMermaViewModel);
    } 
}