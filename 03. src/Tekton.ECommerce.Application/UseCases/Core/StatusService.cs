using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Tekton.ECommerce.Api.DistributedCache;
using Tekton.ECommerce.Dto.DistributedCache;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Core.Status;
using Tekton.ECommerce.IApplication.UseCases.Core;
using System.Linq;
using OP.FK_Framework.Dto.Response;
using Tekton.ECommerce.Dto.Core.Core;

namespace Tekton.ECommerce.Application.UseCases.Core;

public class StatusService : GenericApplication, IStatusService
{
    private readonly ICacheProviderFactory _cache;
    private readonly DistributedCacheConfiguration _cacheOptions;
    private readonly DistributedCacheEntryOptions _options;
    private const string Prefix = "tekton.core.status";


    public StatusService(IMapper mapper, ICacheProviderFactory cache, IOptions<DistributedCacheConfiguration> cacheOptions) : base(mapper)
    {
        
        _cache = cache;
        _cacheOptions = cacheOptions.Value;
        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(Double.TryParse(_cacheOptions.CacheExpirationMinutes.ToString(),
                                                out var absoluteExpirationRelativeToNow) ? absoluteExpirationRelativeToNow : 5),
            SlidingExpiration = TimeSpan.FromMinutes(Double.TryParse(_cacheOptions.CacheInactiveExpirationMinutes.ToString(),
                                                out var slidingExpiration) ? slidingExpiration : 1)
        };
    }

    public async Task<BaseResponse<List<GetStatusAllResponse>>> GetAll()
    {
        var response = new BaseResponse<List<GetStatusAllResponse>>()
        {
            Code = "200",
            Data = [],
            Message = "",
            Success = true,
            Validations = null
        };

        var data = new List<GetStatusAllResponse>();
        string key = $"{Prefix}.all";
        var result = await _cache.GetStringCacheAsync<IEnumerable<GetStatusAllResponse>>(key);

        if (result is null || !result.Any())
        {
            data.Add(new GetStatusAllResponse { StatusId = 1, StatusName = "Activo" });
            data.Add(new GetStatusAllResponse { StatusId = 0, StatusName = "Inactivo" });

            await _cache.SetStringCacheAsync(key, data, _options);
        }
        else
            data = result.ToList();

        response.Data = data;

        return response;
    }
}