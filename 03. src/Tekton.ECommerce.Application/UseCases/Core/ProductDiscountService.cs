using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Tekton.ECommerce.Api.DistributedCache;
using Tekton.ECommerce.Dto.DistributedCache;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.IApplication.UseCases.Core;
using System.Linq;
using OP.FK_Framework.Dto.Response;

using Tekton.ECommerce.Dto.Core.ProductDiscount;

namespace Tekton.ECommerce.Application.UseCases.Core;

public class ProductDiscountService : GenericApplication, IProductDiscountService
{
    private readonly ICacheProviderFactory _cache;
    private readonly DistributedCacheConfiguration _cacheOptions;
    private readonly DistributedCacheEntryOptions _options;
    private const string Prefix = "tekton.core.productdiscount";


    public ProductDiscountService(IMapper mapper, ICacheProviderFactory cache, IOptions<DistributedCacheConfiguration> cacheOptions) : base(mapper)
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

    public async Task<BaseResponse<List<GetProductDiscountByProductIdResponseDto>>> GetAll()
    {
        var response = new BaseResponse<List<GetProductDiscountByProductIdResponseDto>>()
        {
            Code = "200",
            Data = [],
            Message = "",
            Success = true,
            Validations = null
        };

        var data = new List<GetProductDiscountByProductIdResponseDto>();
        string key = $"{Prefix}.all";
        var result = await _cache.GetStringCacheAsync<IEnumerable<GetProductDiscountByProductIdResponseDto>>(key);

        if (result is null || !result.Any())
        {
            data.Add(new GetProductDiscountByProductIdResponseDto { ProductId = 1, DiscountRate = 15 });
            data.Add(new GetProductDiscountByProductIdResponseDto { ProductId = 2, DiscountRate = 25 });
            data.Add(new GetProductDiscountByProductIdResponseDto { ProductId = 3, DiscountRate = 35 });
            data.Add(new GetProductDiscountByProductIdResponseDto { ProductId = 4, DiscountRate = 45 });
            data.Add(new GetProductDiscountByProductIdResponseDto { ProductId = 5, DiscountRate = 55 });
            
            await _cache.SetStringCacheAsync(key, data, _options);
        }
        else
            data = result.ToList();

        response.Data = data;

        return response;
    }
}