using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Tekton.ECommerce.Api.DistributedCache;

public interface ICacheProviderFactory
{
    ValueTask<T> GetStringCacheAsync<T>(string key) where T : class;

    ValueTask<T> GetCacheAsync<T>(string key) where T : class;

    ValueTask SetStringCacheAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;

    ValueTask SetCacheAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;

    ValueTask RemoveCacheAsync(string key);
}
