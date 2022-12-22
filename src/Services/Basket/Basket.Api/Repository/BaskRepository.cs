using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public class BaskRepository : IBaskRepository
    {
        private readonly IDistributedCache _redisCache;

        public BaskRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _redisCache.GetStringAsync(username);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasker(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
        
        }
    }
}
