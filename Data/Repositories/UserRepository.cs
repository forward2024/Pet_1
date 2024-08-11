public class UserRepository : IUserRepository
{
    private readonly MongoDBContext context;

    public UserRepository(MongoDBContext context)
    {
        this.context = context;
    }

    public async Task<UserEntity> GetByIdAsync(string id)
    {
        return await this.context.GetCollection<UserEntity>("Users").Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await this.context.GetCollection<UserEntity>("Users").Find(_ => true).ToListAsync();
    }

    public async Task<UserEntity> CreateAsync(UserEntity user)
    {
        await this.context.GetCollection<UserEntity>("Users").InsertOneAsync(user);
        return user;
    }

    public async Task UpdateAsync(UserEntity user)
    {
        await this.context.GetCollection<UserEntity>("Users").ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    public async Task DeleteAsync(string id)
    {
        await this.context.GetCollection<UserEntity>("Users").DeleteOneAsync(x => x.Id == id);
    }
}