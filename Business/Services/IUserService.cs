public interface IUserService
{
    Task<UserModel> GetByIdAsync(string id);
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserModel> CreateAsync(UserModel userModel);
    Task UpdateAsync(UserModel userModel);
    Task DeleteAsync(string id);
}
