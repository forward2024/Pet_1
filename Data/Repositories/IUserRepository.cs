public interface IUserRepository
{
    Task<UserEntity> GetByIdAsync(string id);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity> CreateAsync(UserEntity user);
    Task UpdateAsync(UserEntity user);
    Task DeleteAsync(string id);
}
