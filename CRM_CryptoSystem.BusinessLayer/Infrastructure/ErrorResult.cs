
using System.Text.Json;

namespace CRM_CryptoSystem.BusinessLayer.Infrastructure;

public class ErrorResult
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
