using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Tekton.ECommerce.Api.DistributedCache;
using Tekton.ECommerce.Dto.DistributedCache;
using Tekton.ECommerce.IApplication.UseCases.Security.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Security.User;
using System.Linq;
using OP.FK_Framework.Dto.Response;

namespace Tekton.ECommerce.Application.UseCases.Security;

public class UserService : GenericApplication, IUserService
{
    private readonly ICacheProviderFactory _cache;
    private readonly DistributedCacheConfiguration _cacheOptions;
    private readonly DistributedCacheEntryOptions _options;
    private const string Prefix = "tekton.security.user";

    public UserService(IMapper mapper, ICacheProviderFactory cache, IOptions<DistributedCacheConfiguration> cacheOptions) : base(mapper)
    {

        _cache = cache;
        _cacheOptions = cacheOptions.Value;
        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(double.TryParse(_cacheOptions.CacheExpirationMinutes.ToString(),
                                                out var absoluteExpirationRelativeToNow) ? absoluteExpirationRelativeToNow : 5),
            SlidingExpiration = TimeSpan.FromMinutes(double.TryParse(_cacheOptions.CacheInactiveExpirationMinutes.ToString(),
                                                out var slidingExpiration) ? slidingExpiration : 1)
        };
    }

    public async Task<BaseResponse<List<GetUserAllResponse>>> GetAll()
    {
        var response = new BaseResponse<List<GetUserAllResponse>>()
        {
            Code = "200",
            Data = [],
            Message = "",
            Success = true,
            Validations = null
        };

        var data = new List<GetUserAllResponse>();
        string key = $"{Prefix}.all";
        var result = await _cache.GetStringCacheAsync<IEnumerable<GetUserAllResponse>>(key);

        if (result is null || !result.Any())
        {
            data.Add(new GetUserAllResponse { OwnerId = 777, UserId = 1, UserName = "Master", Password = "m4st3R", IsActive = true });
            data.Add(new GetUserAllResponse { OwnerId = 777, UserId = 2, UserName = "Test", Password = "t3sT", IsActive = true });
            data.Add(new GetUserAllResponse { OwnerId = 777, UserId = 3, UserName = "Dark", Password = "D4rK", IsActive = false });

            await _cache.SetStringCacheAsync(key, data, _options);
        }
        else
            data = result.ToList();

        response.Data = data;

        return response;
    }
}