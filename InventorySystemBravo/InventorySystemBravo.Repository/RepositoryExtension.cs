using System.Reflection;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystemBravo.Repository;

public static class RepositoryExtension
{
    public static void AddRepositoryLayer(this IServiceCollection theServiceCollection)
    {
        theServiceCollection.AddScoped<IBrandCatalogRepository, BrandCatalogRepository>();
        theServiceCollection.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        theServiceCollection.AddScoped<IProductHistoryRepository, ProductHistoryRepository>();
        theServiceCollection.AddScoped<IProductMermaRepository, ProductMermaRepository>();
        theServiceCollection.AddScoped<IUserRepository, UserRepository>();
        theServiceCollection.AddScoped<IProductRepository, ProductRepository>();
    }
}