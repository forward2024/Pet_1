public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<UserModel> GetByIdAsync(string id)
    {
        var userEntity = await this.userRepository.GetByIdAsync(id);
        if (userEntity == null) return null;

        return new UserModel
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            PasswordHash = userEntity.PasswordHash
        };
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        var users = await this.userRepository.GetAllAsync();
        var userModels = new List<UserModel>();

        foreach (var user in users)
        {
            userModels.Add(new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash
            });
        }

        return userModels;
    }

    public async Task<UserModel> CreateAsync(UserModel userModel)
    {
        var userEntity = new UserEntity
        {
            Username = userModel.Username,
            PasswordHash = userModel.PasswordHash
        };

        var createdUser = await this.userRepository.CreateAsync(userEntity);

        return new UserModel
        {
            Id = createdUser.Id,
            Username = createdUser.Username,
            PasswordHash = createdUser.PasswordHash
        };
    }

    public async Task UpdateAsync(UserModel userModel)
    {
        var userEntity = new UserEntity
        {
            Id = userModel.Id,
            Username = userModel.Username,
            PasswordHash = userModel.PasswordHash
        };

        await this.userRepository.UpdateAsync(userEntity);
    }

    public async Task DeleteAsync(string id)
    {
        await this.userRepository.DeleteAsync(id);
    }
}