namespace Tekton.ECommerce.Dto.DistributedCache;

public class DistributedCacheConfiguration
{
    public double CacheExpirationMinutes { get; set; }

    public double CacheInactiveExpirationMinutes { get; set; }

    public string Instance { get; set; }

    public string ConnectionString { get; set; }

    public string Password { get; set; }
}
