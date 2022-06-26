using MongoDB.Bson;
using MongoDB.Driver;
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

        public void InsertProducts(string table, List<Product> records)
        {
            var collection = db.GetCollection<Product>("Products");
            collection.InsertMany(records);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var collection = db.GetCollection<Product>("Products");
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public List<Product> GetUpdatedProducts()
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Gt("AuditInfo.Version", 1);
            return collection.Find(filter).Sort(Builders<Product>.Sort.Descending("AuditInfo.Version")).ToList();
        }

        public async Task UpdateProductName(Guid id, string name)
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var update = Builders<Product>.Update
                .Set(x => x.Name, name)
                .Inc(x => x.AuditInfo.Version, 1);

            var personUpdateResult = await collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var collection = db.GetCollection<Product>("Products");
            var filter = Builders<Product>.Filter.Eq("Id", id);
            await collection.DeleteOneAsync(filter);
        }
    }
}
