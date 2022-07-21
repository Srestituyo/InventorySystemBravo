using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IProductService
{
    Task<Response<Guid>> AddProduct(ProductDTO theProduct);
    
    Task<Response<ProductModel>> GetProductById(Guid theProductId);

    Task<Response<ProductViewModel>> GetAllProduct();

    Task<Response<Guid>> UpdateProduct(Guid theProductId, ProductDTO theProduct);

    Task<Response<Guid>> RemoveProduct(Guid theProductId);
}