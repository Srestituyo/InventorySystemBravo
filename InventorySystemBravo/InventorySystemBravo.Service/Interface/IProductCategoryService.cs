using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IProductCategoryService
{
    Task<Response<Guid>> AddProductCategory(ProductCategoryDTO theProductCategory);
    
    Task<Response<ProductCategoryModel>> GetProductCategoryById(Guid theProductCategoryId);

    Task<Response<ProductCategoryViewModel>> GetAllProductCategory();

    Task<Response<Guid>> UpdateProductCategory(Guid theProductCategoryId, ProductCategoryDTO theProductCategory);

    Task<Response<Guid>> RemoveProductCategory(Guid theProductCategoryId);
}