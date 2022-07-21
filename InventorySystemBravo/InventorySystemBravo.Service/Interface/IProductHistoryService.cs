using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IProductHistoryService
{
    Task<Response<Guid>> AddProductHistory(ProductHistoryDTO theProductHistory);
    
    Task<Response<ProductHistoryModel>> GetProductHistoryById(Guid theProductHistoryId);

    Task<Response<ProductHistoryViewModel>> GetAllProductHistory(); 
}