using System.Globalization;

namespace InventorySystemBravo.Service.Extension;


public class ApiException:  Exception
{
    public ApiException() : base()
    {
    }

    public ApiException(string theMessage) : base(theMessage)
    {
    }

    public ApiException(string theMessage, params Object[] args) : base(String.Format(CultureInfo.CurrentCulture,
        theMessage, args))
    {
        
    }
}