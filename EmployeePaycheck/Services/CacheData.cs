using System.Text.Json.Serialization;
using EmployeePaycheck.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;

namespace VerifierInsuranceCompany.Services;

public class CacheData
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
    [JsonPropertyName("expiry")]
    public string Expiry { get; set; } = string.Empty;
    [JsonPropertyName("payload")]
    public string Payload { get; set; } = string.Empty;
    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;
    [JsonPropertyName("employeeClaims")]
    public EmployeeClaims Employee { get; set; } = new EmployeeClaims();

    public static void AddToCache(string key, IDistributedCache cache, CacheData cacheData)
    {
        var cacheExpirationInHours = 1;
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(cacheExpirationInHours));
        cache.SetString(key, System.Text.Json.JsonSerializer.Serialize(cacheData), options);
    }

    public static CacheData? GetFromCache(string key, IDistributedCache cache)
    {
        var item = cache.GetString(key);
        if (item != null)
        {
            return System.Text.Json.JsonSerializer.Deserialize<CacheData>(item);
        }

        return null;
    }

    public static void RemoveFromCache(string key, IDistributedCache cache)
    {
        var item = cache.GetString(key);
        if (item != null)
        {
            cache.Remove(key);
        }
    }
}
