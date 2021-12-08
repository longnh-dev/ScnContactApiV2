using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ScnContactApiV2.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;
        

        public MongoDbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient("mongodb+srv://hlongmongodb:&&Longdeptrai1@cluster0.om9we.mongodb.net/ScnContactApiV2?retryWrites=true&w=majority");
            if (client != null)
                _database = client.GetDatabase("Contact");
        }

        public IMongoCollection<Contact> Contacts
        {
            get
            {
                return _database.GetCollection<Contact>("Contact");
            }
        }

    }
}