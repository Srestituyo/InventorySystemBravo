using System.Reflection;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystemBravo.Service;

public static class ServiceExtension
{
    public static void AddServiceLayer(this IServiceCollection theServiceCollection)
    {
        theServiceCollection.AddScoped<IBrandCatalogService, BrandCatalogService>();
        theServiceCollection.AddScoped<IProductCategoryService, ProductCategoryService>();
        theServiceCollection.AddScoped<IProductHistoryService, ProductHistoryService>();
        theServiceCollection.AddScoped<IProductMermaService, ProductMermaService>();
        theServiceCollection.AddScoped<IUserService, UserService>();
        theServiceCollection.AddScoped<IProductService, ProductService>();
        theServiceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

    }
}