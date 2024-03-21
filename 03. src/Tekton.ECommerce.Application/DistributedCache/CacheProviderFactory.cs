using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tekton.ECommerce.Api.DistributedCache;

public class CacheProviderFactory : ICacheProviderFactory
{
    private readonly IDistributedCache _cache;

    public CacheProviderFactory(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async ValueTask RemoveCacheAsync(string key)
    {
        await _cache.RemoveAsync(key).ConfigureAwait(continueOnCapturedContext: false);
    }

    public async ValueTask<T> GetStringCacheAsync<T>(string key) where T : class
    {
        string text = await _cache.GetStringAsync(key);
        return (text != null && !string.IsNullOrEmpty(text)) ? JsonSerializer.Deserialize<T>(text) : null;
    }

    public async ValueTask<T> GetCacheAsync<T>(string key) where T : class
    {
        byte[] array = await _cache.GetAsync(key);
        return (array != null && array != null) ? JsonSerializer.Deserialize<T>(array) : null;
    }

    public async ValueTask SetStringCacheAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
    {
        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), options).ConfigureAwait(continueOnCapturedContext: false);
    }

    public async ValueTask SetCacheAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
    {
        await _cache.SetAsync(key, JsonSerializer.SerializeToUtf8Bytes(value), options).ConfigureAwait(continueOnCapturedContext: false);
    }
}