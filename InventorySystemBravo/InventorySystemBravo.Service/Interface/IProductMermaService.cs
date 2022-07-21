using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IProductMermaService
{
    Task<Response<Guid>> AddProductMerma(ProductMermaDTO theProductMerma);
    
    Task<Response<ProductMermaModel>> GetProductMermaById(Guid theProductMermaId);

    Task<Response<ProductMermaViewModel>> GetAllProductMerma(); 
}