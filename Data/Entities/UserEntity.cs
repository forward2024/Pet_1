public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}