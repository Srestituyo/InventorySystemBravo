namespace InventorySystemBravo.API.Extension;

public static class AppExtensions
{
    public static void UseErrorHandlerMiddleware(this IApplicationBuilder theAppBuilder)
    {
        theAppBuilder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}