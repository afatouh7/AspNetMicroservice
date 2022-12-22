using CatalogApi.Entites;
using MongoDB.Driver;

namespace CatalogApi.Data
{
    public interface ICatalogContext
    { 
        IMongoCollection<Product> Products { get; }

    }
}
