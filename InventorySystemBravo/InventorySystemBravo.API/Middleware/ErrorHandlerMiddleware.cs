using System.Net;
using System.Text.Json;
using InventorySystemBravo.Service.Wrapper;
using InventorySystemBravo.Service.Extension;
namespace InventorySystemBravo.API.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate theNext)
    {
        _next = theNext;
    }

    public async Task Invoke(HttpContext theContext)
    {
        try
        {
            await _next(theContext);
        }
        catch (Exception error)
        {
            var aResponse = theContext.Response;
            aResponse.ContentType = "application/json";
            var aReponseModel = new Response<string>()
            {
                Succeeded = false,
                Message = error?.Message
            };
            
            
            switch (error)
            {
                case ApiException e:
                    //Custom Application error api
                    aResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    //Not  found error
                    aResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    //unhandle error
                    aResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var aResult = JsonSerializer.Serialize(aReponseModel);
            await aResponse.WriteAsync(aResult);

        }
    }
}