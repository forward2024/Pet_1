namespace Data;

public class MongoDBContext
{
    private readonly IMongoDatabase database;

    public MongoDBContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return database.GetCollection<T>(name);
    }
}