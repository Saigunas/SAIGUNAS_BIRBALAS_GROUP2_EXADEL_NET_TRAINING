using MongoDB.Bson;
using MongoDB.Driver;
using Task13.GlobalErrorHandler;
using Task13.Models;

namespace Task13
{
    public class ProductRepository
    {
        private IMongoDatabase db;

        public ProductRepository(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertProducts(List<Product> records)
        {
            var collection = db.GetCollection<Product>("Products");
            foreach (var record in records)
            {
                record.AuditInfo.CreatedOn = DateTime.Now;
            }
            collection.InsertMany(records);
        }

        public async Task<string> GetProductsAsync()
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Empty;
            var projection = Builders<Product>.Projection
                .Include(x => x.Name)
                .Include(x => x.Id);

            var projectionResults = await collection.Find(filter)
                .Project(projection)
                .ToListAsync();

            return projectionResults.ToJson();
        }

        public List<Product> GetUpdatedProducts()
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Gt(x => x.AuditInfo.Version, 1);
            return collection.Find(filter).Sort(Builders<Product>.Sort.Descending("AuditInfo.Version")).ToList();
        }

        public async Task UpdateProductName(Guid id, string name)
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var update = Builders<Product>.Update
                .Set(x => x.Name, name)
                .Inc(x => x.AuditInfo.Version, 1);

            await collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProductsWithoutFeaturesAsync()
        {
            var collection = db.GetCollection<Product>("Products");

            var filterNoArray = Builders<Product>.Filter.Eq(x => x.Features, null);
            var filterEmptyArray = Builders<Product>.Filter.Size("Features", 0);

            var filter = Builders<Product>.Filter.Or(filterEmptyArray, filterNoArray);

            await collection.DeleteManyAsync(filter);
        }
    }
}
