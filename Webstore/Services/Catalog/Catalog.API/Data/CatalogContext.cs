using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext() {

            var client = new MongoClient("mongodb://localhost:27017");//povezujemo se sa mongom
            var database = client.GetDatabase("CatalogDB");//uzmi bazu sa ovim imenom

            Products = database.GetCollection<Product>("Products");
            CatalogContextSeed.seedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
