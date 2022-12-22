using Basket.Api.Entities;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public interface IBaskRepository
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> UpdateBasker(ShoppingCart basket);
        Task DeleteBasket(string username); 


    }
}
